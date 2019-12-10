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
        //session clear to ensure exiting out of tab 
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

        //clear background check
        BackgroundCheckApplicant.lstBackgroundCheckApplicants.Clear();
        sc.Open();

        //get accountID to see which account (admin, tenant, or host) it is to populate dashboard
        int accountID = Convert.ToInt32(Session["accountID"]);

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
            dashboardTitle.Text = HttpUtility.HtmlEncode(rdr["FirstName"].ToString())+ "'s Admin Dashboard";
        }

        int adminIDRefresh = Convert.ToInt32(HttpUtility.HtmlEncode(Session["adminID"]));

        //populating host applicants for background check card
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
                                if (backgroundCheckResult == "r")
                                {
                                    backgroundCheckPhoto = "images/icons-08.png";
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

        //populating background check card with tenant applicants
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
        showBackgroundResults(); //call to populate background results

        //response if there are no background check applicants
        bool isEmpty = !BackgroundCheckApplicant.lstBackgroundCheckApplicants.Any();
        if (isEmpty)
        {
            backgroundChecklbl.Text = "No one needs background check approved.";
        }

    }

    protected void search_Click(object sender, EventArgs e)
    {
        SearchResult.lstSearchResults.Clear();

        //validation to see if theres an invalid input in search
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



        //search queries by city or zipcode
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
                        "[dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Host].ShowHost, [dbo].[Host].HostBio, [dbo].[Host].BackgroundCheckResult, [dbo].[Property].HouseNumber, [dbo].[Property].Street, [dbo].[Property].CityCounty, " +
                        "[dbo].[Property].HomeState, [dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription, isnull([dbo].[PropertyRoom].RoomDescription, 'No Room Bio') as RoomDescription, isnull([dbo].[PropertyRoom].RoomID, 0) as RoomID, " +
                        "isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice, BadgeProperty.PrivateEntrance, BadgeProperty.Kitchen, BadgeProperty.PrivateBathroom, BadgeProperty.Furnished, BadgeProperty.ClosetSpace, BadgeProperty.NonSmoker " +
                        "FROM [dbo].[Host] left join [dbo].[Property] on " +
                        "[dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] on [dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID " +
                        "left join [dbo].[BadgeProperty] on [dbo].[PropertyRoom].RoomID = [dbo].[BadgeProperty].RoomID " +
                        "where [dbo].[Property].Zip = @zip";

                    command.Parameters.AddWithValue("@zip", propertySearch);
                }
                else
                {
                    command.CommandText = "select " +
                            "[dbo].[BadgeProperty].PrivateEntrance, [dbo].[BadgeProperty].Kitchen, [dbo].[BadgeProperty].PrivateBathroom, [dbo].[BadgeProperty].Furnished, [dbo].[BadgeProperty].ClosetSpace, [dbo].[BadgeProperty].NonSmoker, " +
                            "[dbo].[PropertyRoom].Image1, [dbo].[PropertyRoom].Image2, [dbo].[PropertyRoom].Image3, " +
                            "[dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Host].ShowHost, [dbo].[Host].HostBio, [dbo].[Host].BackgroundCheckResult, [dbo].[Property].HouseNumber, [dbo].[Property].Street, [dbo].[Property].CityCounty, " +
                            "[dbo].[Property].HomeState, [dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription, isnull([dbo].[PropertyRoom].RoomDescription, 'No Room Bio') as RoomDescription, isnull([dbo].[PropertyRoom].RoomID, 0) as RoomID, " +
                            "isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice, BadgeProperty.PrivateEntrance, BadgeProperty.Kitchen, BadgeProperty.PrivateBathroom, BadgeProperty.Furnished, BadgeProperty.ClosetSpace, BadgeProperty.NonSmoker " +
                            "FROM [dbo].[Host] left join [dbo].[Property] on " +
                            "[dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] on [dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID " +
                            "left join [dbo].[BadgeProperty] on [dbo].[PropertyRoom].RoomID = [dbo].[BadgeProperty].RoomID " +
                            "where [dbo].[Property].CityCounty = @city";


                    command.Parameters.AddWithValue("@city", propertySearch);
                }


                //populate search results
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string showHost = HttpUtility.HtmlEncode((string)reader["ShowHost"]);
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

                                if (showHost == "n")
                                {
                                    showHost = "Host is currently hidden from search.";

                                }
                                else
                                {
                                    showHost = "";
                                }

                                List<string> badges = new List<string>{HttpUtility.HtmlEncode((string)reader["PrivateEntrance"]), HttpUtility.HtmlEncode((string)reader["Kitchen"]),HttpUtility.HtmlEncode( (string)reader["Furnished"]),
                               HttpUtility.HtmlEncode((string)reader["ClosetSpace"]), HttpUtility.HtmlEncode((string)reader["NonSmoker"]),HttpUtility.HtmlEncode( (string)reader["PrivateBathroom"])};

                                SearchResult result = new SearchResult(id, name, location, propertyTitle, description, price, image1, image2, image3, backgroundCheckPhoto, badges, hostBio, showHost);

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
        //bind results from database
        lvSearchResultsAdmin.DataSource = SearchResult.lstSearchResults;
        lvSearchResultsAdmin.DataBind();
    }

    protected void showBackgroundResults()
    {
        //bind results from database
        lvBackgroundResults.DataSource = BackgroundCheckApplicant.lstBackgroundCheckApplicants;
        lvBackgroundResults.DataBind();
    }

    protected void hideProperties(object sender, EventArgs e)
    {
        //get id from class and from list view to mark property room as unavailable
        Button btn = sender as Button;
        ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
        var index = item.DataItemIndex;
        var selectedPRid = SearchResult.lstSearchResults[index].resultID;

        if (btn.Text == "Mark as Unavailable")
        {
            Response.Write("<script> alert('Are you sure you want to hide this property?'); </script>");
            SqlCommand delete = new SqlCommand("UPDATE [dbo].[PropertyRoom] SET Availability = 'N' WHERE RoomID = @RoomID", sc);
            delete.Parameters.AddWithValue("@RoomID", selectedPRid);
            delete.ExecuteNonQuery();
            btn.Text = "Mark as Available";

        }
        else
        {
            SqlCommand undelete = new SqlCommand("UPDATE [dbo].[PropertyRoom] SET Availability = 'Y' WHERE RoomID = @RoomID", sc);
            undelete.Parameters.AddWithValue("@RoomID", selectedPRid);
            undelete.ExecuteNonQuery();
            btn.Text = "Mark as Unavailable";
        }

    }

    protected void approveApplicant(object sender, EventArgs e)
    {
        //get id from class and from list view to approve background check applicant
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
        //get id from class and from list view to reject background check applicant
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
        //get id from class and from list view to approve background check applicant
        Session.Abandon();
        Response.Redirect("Index.aspx");
        SearchResult.lstSearchResults.Clear();
    }

    protected void viewProperty(object sender, EventArgs e)
    {
        //get id from class to set an id into a session variable for property profile
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

    protected void hideHost(object sender, EventArgs e)
    {
        //get id from class and from list view to mark a host as unavailable
        Button btn = sender as Button;
        ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
        var index = item.DataItemIndex;
        var selectedPRid = SearchResult.lstSearchResults[index].resultID;
        SqlCommand getHost = new SqlCommand("SELECT HostID FROM [dbo].[Property] WHERE PropertyID = (SELECT PropertyID FROM[dbo].[PropertyRoom] WHERE RoomID = @RoomID)", sc);
        getHost.Parameters.AddWithValue("@RoomID", selectedPRid);
        int hostID = Convert.ToInt32(getHost.ExecuteScalar());
        getHost.ExecuteNonQuery();

        SqlCommand validation = new SqlCommand("SELECT ShowHost FROM [dbo].[Host] WHERE HostID = @HostID", sc);
        validation.Parameters.AddWithValue("@HostID", hostID);
        SqlDataReader rdr = validation.ExecuteReader();
        string showHostResult = "";
        while (rdr.Read())
        {
            showHostResult = rdr["ShowHost"].ToString();
        }

        if (showHostResult == "y")
        {            

            SqlCommand hidehost = new SqlCommand("UPDATE [dbo].[Host] SET ShowHost = 'n' WHERE HostID = @HostID", sc);
            hidehost.Parameters.AddWithValue("@HostID", hostID);
            hidehost.Connection = sc;
            hidehost.ExecuteNonQuery();
            //Response.Redirect("AdminDashboard.aspx");
            Response.Write("<script> alert('Host is now hidden.'); </script>");
            btn.Text = "Unhide Host";
        }
        else
        {
            SqlCommand unhidehost = new SqlCommand("UPDATE [dbo].[Host] SET ShowHost = 'y' WHERE HostID = @HostID", sc);
            unhidehost.Parameters.AddWithValue("@HostID", hostID);
            unhidehost.Connection = sc;
            unhidehost.ExecuteNonQuery();
            btn.Text = "Hide Host";
        }
    }


}