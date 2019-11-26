using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDashboard : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string strPreviousPage = "";
        if (Request.UrlReferrer != null)
        {
            strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
        }
        if (strPreviousPage == "")
        {
            Session["LoggedIn"] = "false";
            Response.Redirect("Login.aspx");
        }

        BackgroundCheckApplicant.lstBackgroundCheckApplicants.Clear();
        sc.Open();
        int accountID = Convert.ToInt32(Session["accountID"]);
        Response.Write(accountID);

        SqlCommand insert = new SqlCommand("SELECT AdminID FROM [dbo].[Login] WHERE AccountID = @AccountID", sc);
        insert.Parameters.AddWithValue("@AccountID", accountID);
        insert.Connection = sc;
        int adminID = Convert.ToInt32(insert.ExecuteScalar());
        insert.ExecuteNonQuery();
        Session["adminID"] = adminID;

        SqlCommand filter = new SqlCommand("SELECT FirstName, LastName FROM [dbo].[Admin] WHERE AdminID = @AdminID", sc);
        filter.Parameters.AddWithValue("@AdminID", adminID);
        SqlDataReader rdr = filter.ExecuteReader();
        while (rdr.Read())
        {
            //nameTextbox.Text = rdr["FirstName"].ToString() + " " + rdr["LastName"].ToString();
            dashboardTitle.Text = HttpUtility.HtmlEncode(rdr["FirstName"].ToString())+ "'s Admin Dashboard";
            //byte[] imgData = (byte[])rdr["imageV2"];
            //if (!(imgData == null))
            //{
            //    string img = Convert.ToBase64String(imgData, 0, imgData.Length);
            //    image1.ImageUrl = "data:image;base64," + img;
            //}
        }
        //usernameTextbox.Text = Session["username"].ToString();

        int adminIDRefresh = Convert.ToInt32(HttpUtility.HtmlEncode(Session["adminID"]));

        //host applicants
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT HostID, FirstName, LastName, PhoneNumber, Email, imageV2, BackgroundCheckResult FROM [dbo].[Host] WHERE lower(BackgroundCheckResult) = 'n'";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                String name = HttpUtility.HtmlEncode(reader["FirstName"].ToString()) + " " + HttpUtility.HtmlEncode(reader["LastName"].ToString());
                                String email = HttpUtility.HtmlEncode(reader["Email"].ToString());
                                String phone = HttpUtility.HtmlEncode(reader["PhoneNumber"].ToString());
                                String applicantType = "h";
                                int id = Convert.ToInt32(HttpUtility.HtmlEncode(reader["HostID"]));
                                string backgroundCheckResult = HttpUtility.HtmlEncode(reader["BackgroundCheckResult"].ToString().ToLower());
                                byte[] imgData = (byte[])reader["imageV2"];
                                string img = "";
                                if (!(imgData == null))
                                {
                                    img = Convert.ToBase64String(imgData, 0, imgData.Length);
                                    img = "data:image;base64," + img;
                                }

                                string backgroundCheckPhoto = "";
                                if (backgroundCheckResult == "n")
                                {
                                    backgroundCheckPhoto = "images/NC.png";
                                }
                                if (backgroundCheckResult == "y")
                                {
                                    backgroundCheckPhoto = "images/icons-07.png";
                                }
                                BackgroundCheckApplicant hostresult = new BackgroundCheckApplicant(id, name, phone, email, img, applicantType, backgroundCheckPhoto);

                                BackgroundCheckApplicant.lstBackgroundCheckApplicants.Add(hostresult);
                            }

                        }
                    }
                }
                catch (SqlException t)
                {
                    string b = t.ToString();
                }
                finally
                {
                    connection.Close();

                }
            }
        }

        //tenant applicants
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
               
                try
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT TenantID, FirstName, LastName, PhoneNumber, Email, imageV2, BackgroundCheckResult FROM [dbo].[Tenant] WHERE lower(BackgroundCheckResult) = 'n'";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                String name = HttpUtility.HtmlEncode(reader["FirstName"].ToString()) + " " + HttpUtility.HtmlEncode(reader["LastName"].ToString());
                                String email = HttpUtility.HtmlEncode(reader["Email"].ToString());
                                String phone = HttpUtility.HtmlEncode(reader["PhoneNumber"].ToString());
                                String applicantType = "t";
                                int id = Convert.ToInt32(HttpUtility.HtmlEncode(reader["TenantID"]));
                                string backgroundCheckResult = HttpUtility.HtmlEncode(reader["BackgroundCheckResult"].ToString().ToLower());
                                byte[] imgData = (byte[])reader["imageV2"];
                                string img = "";
                                if (!(imgData == null))
                                {
                                    img = Convert.ToBase64String(imgData, 0, imgData.Length);
                                    img = "data:image;base64," + img;
                                }

                                string backgroundCheckPhoto = "";
                                if (backgroundCheckResult == "n")
                                {
                                    backgroundCheckPhoto = "images/NC.png";
                                }
                                if (backgroundCheckResult == "y")
                                {
                                    backgroundCheckPhoto = "images/icons-07.png";
                                }
                                BackgroundCheckApplicant hostresult = new BackgroundCheckApplicant(id, name, phone, email, img, applicantType, backgroundCheckPhoto);

                                BackgroundCheckApplicant.lstBackgroundCheckApplicants.Add(hostresult);
                            }

                        }
                    }
                }
                catch (SqlException t)
                {
                    string b = t.ToString();
                }
                finally
                {
                    connection.Close();

                }
            }
        }
        showBackgroundResults();

        bool isEmpty = !BackgroundCheckApplicant.lstBackgroundCheckApplicants.Any();
        if (isEmpty)
        {
            backgroundChecklbl.Text = "No one needs background check approved.";
        }
    }

    protected void search_Click(object sender, EventArgs e)
    {
        SearchResult.lstSearchResults.Clear();

        bool searchBy;
        int a;
        string propertySearch = searchTextbox.Text;

        if (string.IsNullOrEmpty(propertySearch))
        {
            lblInvalidSearch.Text = "You must enter a city OR a zip!";
            return;
        }
        else
        {
            searchBy = Int32.TryParse(propertySearch, out a);
            if (a < 0)
            {
                lblInvalidSearch.Text = "Enter a valid zip.";
                return;
            }
            lblInvalidSearch.Text = String.Empty;
        }




        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                if (searchBy)
                {

                    command.CommandText = "select " +
                        "[dbo].[BadgeProperty].PrivateEntrance, [dbo].[BadgeProperty].Kitchen, [dbo].[BadgeProperty].PrivateBathroom, [dbo].[BadgeProperty].Furnished, [dbo].[BadgeProperty].ClosetSpace, [dbo].[BadgeProperty].NonSmoker, " +
                        "[dbo].[PropertyRoom].Image1, [dbo].[PropertyRoom].Image2, [dbo].[PropertyRoom].Image3, " +
                        "[dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Host].HostBio, [dbo].[Host].BackgroundCheckResult, [dbo].[Property].HouseNumber, [dbo].[Property].Street, [dbo].[Property].CityCounty, " +
                        "[dbo].[Property].HomeState, [dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription, isnull([dbo].[PropertyRoom].RoomDescription, 'No Room Bio') as RoomDescription, isnull([dbo].[PropertyRoom].RoomID, 0) as RoomID, " +
                        "isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice, BadgeProperty.PrivateEntrance, BadgeProperty.Kitchen, BadgeProperty.PrivateBathroom, BadgeProperty.Furnished, BadgeProperty.ClosetSpace, BadgeProperty.NonSmoker " +
                        "FROM [dbo].[Host] left join [dbo].[Property] on " +
                        "[dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] on [dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID " +
                        "left join [dbo].[BadgeProperty] on [dbo].[PropertyRoom].RoomID = [dbo].[BadgeProperty].RoomID " +
                        "where [dbo].[Property].Zip = @zip and lower([dbo].[PropertyRoom].Availability) = 'y'";

                    command.Parameters.AddWithValue("@zip", propertySearch);
                }
                else
                {
                    command.CommandText = "select " +
                            "[dbo].[BadgeProperty].PrivateEntrance, [dbo].[BadgeProperty].Kitchen, [dbo].[BadgeProperty].PrivateBathroom, [dbo].[BadgeProperty].Furnished, [dbo].[BadgeProperty].ClosetSpace, [dbo].[BadgeProperty].NonSmoker, " +
                            "[dbo].[PropertyRoom].Image1, [dbo].[PropertyRoom].Image2, [dbo].[PropertyRoom].Image3, " +
                            "[dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Host].HostBio, [dbo].[Host].BackgroundCheckResult, [dbo].[Property].HouseNumber, [dbo].[Property].Street, [dbo].[Property].CityCounty, " +
                            "[dbo].[Property].HomeState, [dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription, isnull([dbo].[PropertyRoom].RoomDescription, 'No Room Bio') as RoomDescription, isnull([dbo].[PropertyRoom].RoomID, 0) as RoomID, " +
                            "isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice, BadgeProperty.PrivateEntrance, BadgeProperty.Kitchen, BadgeProperty.PrivateBathroom, BadgeProperty.Furnished, BadgeProperty.ClosetSpace, BadgeProperty.NonSmoker " +
                            "FROM [dbo].[Host] left join [dbo].[Property] on " +
                            "[dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] on [dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID " +
                            "left join [dbo].[BadgeProperty] on [dbo].[PropertyRoom].RoomID = [dbo].[BadgeProperty].RoomID " +
                            "where [dbo].[Property].CityCounty = @city and lower([dbo].[PropertyRoom].Availability) = 'y' ";


                    command.Parameters.AddWithValue("@city", propertySearch);
                    //command.Parameters.AddWithValue("@default", Session["defaultPicture"]);
                }



                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                string name = HttpUtility.HtmlEncode((string)reader["FirstName"]) + " " + HttpUtility.HtmlEncode((string)reader["LastName"]);
                                string location = HttpUtility.HtmlEncode((string)reader["CityCounty"]) + ", " + HttpUtility.HtmlEncode((string)reader["HomeState"]) + " " + HttpUtility.HtmlEncode((string)reader["Zip"]);
                                string description = HttpUtility.HtmlEncode((string)reader["RoomDescription"]);
                                int id = Convert.ToInt32(HttpUtility.HtmlEncode(reader["RoomID"]));
                                string backgroundCheckResult = HttpUtility.HtmlEncode(reader["BackgroundCheckResult"].ToString().ToLower());
                                double price = Convert.ToDouble(HttpUtility.HtmlEncode(reader["MonthlyPrice"]));
                                string fullAddress = HttpUtility.HtmlEncode((string)reader["HouseNumber"]) + " " + HttpUtility.HtmlEncode((string)reader["Street"]) + ", " + HttpUtility.HtmlEncode((string)reader["CityCounty"]) + ", " + HttpUtility.HtmlEncode((string)reader["HomeState"]) + " " + HttpUtility.HtmlEncode((string)reader["Zip"]);
                                string propertyTitle = HttpUtility.HtmlEncode((string)reader["BriefDescription"]);
                                byte[] imgData1;
                                byte[] imgData2;
                                byte[] imgData3;
                                string hostBio = HttpUtility.HtmlEncode((string)reader["HostBio"]);

                                try
                                {
                                    imgData1 = (byte[])reader["Image1"];
                                }
                                catch
                                {
                                    imgData1 = (byte[])Session["defaultPicture"];
                                }

                                try
                                {
                                    imgData2 = (byte[])reader["Image2"];
                                }
                                catch
                                {
                                    imgData2 = (byte[])Session["defaultPicture"];
                                }

                                try
                                {
                                    imgData3 = (byte[])reader["Image3"];
                                }
                                catch
                                {
                                    imgData3 = (byte[])Session["defaultPicture"];
                                }



                                string image1 = "data:image;base64," + Convert.ToBase64String(imgData1, 0, imgData1.Length);
                                string image2 = "data:image;base64," + Convert.ToBase64String(imgData2, 0, imgData2.Length);
                                string image3 = "data:image;base64," + Convert.ToBase64String(imgData3, 0, imgData3.Length);

                                string backgroundCheckPhoto = "";
                                if (backgroundCheckResult == "n")
                                {
                                    backgroundCheckPhoto = "images/NC.png";
                                }
                                if (backgroundCheckResult == "y")
                                {
                                    backgroundCheckPhoto = "images/icons-07.png";
                                }

                                List<string> badges = new List<string>{HttpUtility.HtmlEncode((string)reader["PrivateEntrance"]), HttpUtility.HtmlEncode((string)reader["Kitchen"]),HttpUtility.HtmlEncode( (string)reader["Furnished"]),
                               HttpUtility.HtmlEncode((string)reader["ClosetSpace"]), HttpUtility.HtmlEncode((string)reader["NonSmoker"]),HttpUtility.HtmlEncode( (string)reader["PrivateBathroom"])};

                                SearchResult result = new SearchResult(id, name, location, propertyTitle, description, price, image1, image2, image3, backgroundCheckPhoto, badges, hostBio);

                                result.setFullAddress(fullAddress);

                                SearchResult.lstSearchResults.Add(result);
                            }

                        }
                        else
                        {
                            lblInvalidSearch.Text = "Search returned no properties";
                        }

                    }
                }
                catch (SqlException t)
                {
                    string b = t.ToString();
                }
                finally
                {
                    searchTextbox.Text = string.Empty;
                    connection.Close();

                }
            }
        }
            showResults();
        }

    protected void showResults()
    {
        lvSearchResultsAdmin.DataSource = SearchResult.lstSearchResults;
        lvSearchResultsAdmin.DataBind();
    }

    protected void showBackgroundResults()
    {
        lvBackgroundResults.DataSource = BackgroundCheckApplicant.lstBackgroundCheckApplicants;
        lvBackgroundResults.DataBind();
    }

    protected void hideProperties(object sender, EventArgs e)
    {
        Response.Write("<script> alert('Are you sure you want to delete this property?'); </script>");
        //var lcount = lvSearchResultsAdmin.SelectedIndex;

        Button btn = sender as Button;
        ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
        var index = item.DataItemIndex;
        var selectedPRid = SearchResult.lstSearchResults[index].resultID;

        //lvSearchResults.SelectedIndex;
        //lvSearchResults.Items[lcount].Selected = 1;

        SqlCommand delete = new SqlCommand("UPDATE [dbo].[PropertyRoom] SET Availability = 'N' WHERE RoomID = @RoomID", sc);
        delete.Parameters.AddWithValue("@RoomID", selectedPRid);
        delete.ExecuteNonQuery();
    }

    protected void approveApplicant(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
        var index = item.DataItemIndex;
        var spot = BackgroundCheckApplicant.lstBackgroundCheckApplicants[index].applicantType;
        if (spot == "h")
        {
            var userid = BackgroundCheckApplicant.lstBackgroundCheckApplicants[index].userid;
            SqlCommand approveh = new SqlCommand("UPDATE [dbo].[Host] SET BackgroundCheckResult = 'y' WHERE HostID = @HostID", sc);
            approveh.Parameters.AddWithValue("@HostID", userid);
            approveh.Connection = sc;
            approveh.ExecuteNonQuery();
        }
        else if (BackgroundCheckApplicant.lstBackgroundCheckApplicants[index].applicantType == "t")
        {
            var userid = BackgroundCheckApplicant.lstBackgroundCheckApplicants[index].userid;
            SqlCommand approvet = new SqlCommand("UPDATE [dbo].[Tenant] SET BackgroundCheckResult = 'y' WHERE TenantID = @TenantID", sc);
            approvet.Parameters.AddWithValue("@TenantID", userid);
            approvet.Connection = sc;
            approvet.ExecuteNonQuery();
        }
        Response.Redirect("AdminDashboard.aspx");
    }

    protected void rejectApplicant(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
        var index = item.DataItemIndex;
        var spot = BackgroundCheckApplicant.lstBackgroundCheckApplicants[index].applicantType;
        if (spot == "h")
        {
            var userid = BackgroundCheckApplicant.lstBackgroundCheckApplicants[index].userid;
            SqlCommand rejecth = new SqlCommand("UPDATE [dbo].[Host] SET BackgroundCheckResult = 'r' WHERE HostID = @HostID", sc);
            rejecth.Parameters.AddWithValue("@HostID", userid);
            rejecth.Connection = sc;
            rejecth.ExecuteNonQuery();
        }
        else if (BackgroundCheckApplicant.lstBackgroundCheckApplicants[index].applicantType == "t")
        {
            var userid = BackgroundCheckApplicant.lstBackgroundCheckApplicants[index].userid;
            SqlCommand rejectTen= new SqlCommand("UPDATE [dbo].[Tenant] SET BackgroundCheckResult = 'r' WHERE TenantID = @TenantID", sc);
            rejectTen.Parameters.AddWithValue("@TenantID", userid);
            rejectTen.Connection = sc;
            rejectTen.ExecuteNonQuery();
        }
        Response.Redirect("AdminDashboard.aspx");
    }

    protected void logout(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Index.aspx");
        SearchResult.lstSearchResults.Clear();
    }

    protected void viewProperty(object sender, EventArgs e)
    {

        SearchResult.selectedReultFullAddress = string.Empty;
        Button btn = sender as Button;
        ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
        var index = item.DataItemIndex;
        Session["position"] = index;
        SearchResult.selectedReultFullAddress = SearchResult.lstSearchResults[index].resultFullAddress;
        Response.Redirect("PropertyDescription.aspx");
    }

    protected void addAdmin_Click(object sender, EventArgs e)
    {

    }
}