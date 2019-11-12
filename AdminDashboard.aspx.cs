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
        sc.Open();
        int accountID = Convert.ToInt32(Session["accountID"]);
        Response.Write(accountID);

        SqlCommand insert = new SqlCommand("SELECT AdminID FROM [Capstone].[dbo].[Login] WHERE AccountID = @AccountID", sc);
        insert.Parameters.AddWithValue("@AccountID", accountID);
        insert.Connection = sc;
        int adminID = Convert.ToInt32(insert.ExecuteScalar());
        insert.ExecuteNonQuery();
        Session["adminID"] = adminID;

        SqlCommand filter = new SqlCommand("SELECT FirstName, LastName FROM [Capstone].[dbo].[Admin] WHERE AdminID = @AdminID", sc);
        filter.Parameters.AddWithValue("@AdminID", adminID);
        SqlDataReader rdr = filter.ExecuteReader();
        while (rdr.Read())
        {
            nameTextbox.Text = rdr["FirstName"].ToString() + " " + rdr["LastName"].ToString();
            dashboardTitle.Text = rdr["FirstName"].ToString() + "'s Admin Dashboard";
            //byte[] imgData = (byte[])rdr["imageV2"];
            //if (!(imgData == null))
            //{
            //    string img = Convert.ToBase64String(imgData, 0, imgData.Length);
            //    image1.ImageUrl = "data:image;base64," + img;
            //}
        }
        usernameTextbox.Text = Session["username"].ToString();

        int adminIDRefresh = Convert.ToInt32(Session["adminID"]);

        //host applicants
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                int hostID = Convert.ToInt32(Session["hostID"]);
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT FirstName, LastName, PhoneNumber, Email, imageV2 FROM [Capstone].[dbo].[Host] WHERE lower(BackgroundCheckResult) = 'n'";
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                String name = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                                String email = reader["Email"].ToString();
                                String phone = reader["PhoneNumber"].ToString();
                                String applicantType = "h";
                                byte[] imgData = (byte[])reader["imageV2"];
                                string img = "";
                                if (!(imgData == null))
                                {
                                    img = Convert.ToBase64String(imgData, 0, imgData.Length);
                                    img = "data:image;base64," + img;
                                }
                                BackgroundCheckApplicant result = new BackgroundCheckApplicant(name, phone, email, img, applicantType);

                                BackgroundCheckApplicant.lstBackgroundCheckApplicants.Add(result);
                            }

                        }
                        else
                        {
                            lblInvalidSearch.Text = "No one needs background check approved.";
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

        //tenant applicants
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                int tenantID = Convert.ToInt32(Session["tenantID"]);
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT FirstName, LastName, PhoneNumber, Email, imageV2 FROM [Capstone].[dbo].[Tenant] WHERE lower(BackgroundCheckResult) = 'n'";
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                String name = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                                String email = reader["Email"].ToString();
                                String phone = reader["PhoneNumber"].ToString();
                                String applicantType = "t";
                                byte[] imgData = (byte[])reader["imageV2"];
                                string img = "";
                                if (!(imgData == null))
                                {
                                    img = Convert.ToBase64String(imgData, 0, imgData.Length);
                                    img = "data:image;base64," + img;
                                }
                                BackgroundCheckApplicant result = new BackgroundCheckApplicant(name, phone, email, img, applicantType);

                                BackgroundCheckApplicant.lstBackgroundCheckApplicants.Add(result);
                            }

                        }
                        else
                        {
                            lblInvalidSearch.Text = "No one needs background check approved.";
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
                        command.CommandText = "select [dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Property].CityCounty, " +
                            "[dbo].[Property].HomeState, [dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription,  [dbo].[PropertyRoom].RoomID, " +
                            "isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice from [dbo].[Host] left join [dbo].[Property] on " +
                            "[dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] on [dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID " +
                            "where [dbo].[Property].Zip = @zip";

                        command.Parameters.AddWithValue("@zip", propertySearch);
                    }
                    else
                    {
                        command.CommandText = "select [dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Property].CityCounty, [dbo].[Property].HomeState, " +
                            "[dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription, [dbo].[PropertyRoom].RoomID, " +
                            "isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice from " +
                            "[dbo].[Host] left join [dbo].[Property] on [dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] " +
                            "on [dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID where [dbo].[Property].CityCounty = @city";
                        command.Parameters.AddWithValue("@city", propertySearch);
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

                                    string name = (string)reader["FirstName"] + " " + (string)reader["LastName"];
                                    string location = (string)reader["CityCounty"] + ", " + (string)reader["HomeState"] + " " + (string)reader["Zip"];

                                    string description = (string)reader["BriefDescription"];


                                int id = Convert.ToInt32(reader["RoomID"]);

                                double price = Convert.ToDouble(reader["MonthlyPrice"]);

                                SearchResult result = new SearchResult(id, name, location, description, price);

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
        showBackgroundResults();
        }

    protected void showResults()
    {
        lvSearchResultsAdmin.DataSource = SearchResult.lstSearchResults;
        lvSearchResultsAdmin.DataBind();
    }

    protected void showBackgroundResults()
    {
        lvBackgroundResults.DataSource = SearchResult.lstSearchResults;
        lvBackgroundResults.DataBind();
    }

    protected void deleteProperty(object sender, EventArgs e)
    {

        //var lcount = lvSearchResultsAdmin.SelectedIndex;

        Button btn = sender as Button;
        ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
        var index = item.DataItemIndex;
        var selectedPRid = SearchResult.lstSearchResults[index].resultID;

        //lvSearchResults.SelectedIndex;
        //lvSearchResults.Items[lcount].Selected = 1;

        SqlCommand delete = new SqlCommand("DELETE FROM [Capstone].[dbo].[PropertyRoom] WHERE RoomID = @RoomID", sc);
        delete.Parameters.AddWithValue("@RoomID", selectedPRid);
        delete.Connection = sc;
        delete.ExecuteNonQuery();
    }

    protected void logout(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Index.aspx");
        SearchResult.lstSearchResults.Clear();
    }
}