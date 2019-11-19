using System;
using System.Collections.Generic;

using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{

    //SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["CapstoneConnectionString"].ConnectionString);
    string furnished;
    string bathroom;
    string closet;
    string nonsmoker;
    string kitchen;
    string entrance;


    protected void Page_Load(object sender, EventArgs e)
    {

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
        } else
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
            if (furnishedCheck.Checked)
            {
                furnished = "y";
            }
            else
            {
                furnished = "n";
            }
            if (privateBathroomCheck.Checked)
            {
                bathroom = "y";
            }
            else
            {
                bathroom = "n";
            }
            if (closetCheck.Checked)
            {
                closet = "y";
            }
            else
            {
                closet = "n";
            }
            if (kitchenCheck.Checked)
            {
                kitchen = "y";
            }
            else
            {
                kitchen = "n";
            }
            if (nonSmokerCheck.Checked)
            {
                nonsmoker = "y";
            }
            else
            {
                nonsmoker = "n";
            }
            if (privateEntranceCheck.Checked)
            {
                entrance = "y";
            }
            else
            {
                entrance = "n";
            }
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                if (searchBy)
                {
                    
                        command.CommandText = "select " +
                            "[dbo].[PropertyRoom].Image1, [dbo].[PropertyRoom].Image2, [dbo].[PropertyRoom].Image3, " +
                            "[dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Host].BackgroundCheckResult, [dbo].[Property].HouseNumber, [dbo].[Property].Street, [dbo].[Property].CityCounty, " +
                            "[dbo].[Property].HomeState, [dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription,  isnull([dbo].[PropertyRoom].RoomID, 0) as RoomID, " +
                            "isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice, BadgeProperty.PrivateEntrance, BadgeProperty.Kitchen, BadgeProperty.PrivateBathroom, BadgeProperty.Furnished, BadgeProperty.ClosetSpace, BadgeProperty.NonSmoker " +
                            "FROM [dbo].[Host] left join [dbo].[Property] on " +
                            "[dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] on [dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID inner join [dbo].[BadgeProperty] on [dbo].[PropertyRoom].RoomID = [dbo].[BadgeProperty].RoomID " +
                            "where [dbo].[Property].Zip = @zip AND [dbo].[BadgeProperty].PrivateEntrance = @entrance AND [dbo].[BadgeProperty].Kitchen = @kitchen AND [dbo].[BadgeProperty].PrivateBathroom = @bathroom" +
                            " AND [dbo].[BadgeProperty].Furnished = @furnished AND [dbo].[BadgeProperty].ClosetSpace = @closet AND [dbo].[BadgeProperty].NonSmoker = @nonsmoker";

                        command.Parameters.AddWithValue("@zip", propertySearch);
                        command.Parameters.AddWithValue("@entrance", entrance);
                        command.Parameters.AddWithValue("@kitchen", furnished);
                        command.Parameters.AddWithValue("@bathroom", bathroom);
                        command.Parameters.AddWithValue("@furnished", furnished);
                        command.Parameters.AddWithValue("@closet", closet);
                        command.Parameters.AddWithValue("@nonsmoker", nonsmoker);
                }
                else
                {
                    command.CommandText = "select " +
                            "[dbo].[PropertyRoom].Image1, [dbo].[PropertyRoom].Image2, [dbo].[PropertyRoom].Image3, " +
                            "[dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Host].BackgroundCheckResult, [dbo].[Property].HouseNumber, [dbo].[Property].Street, [dbo].[Property].CityCounty, " +
                            "[dbo].[Property].HomeState, [dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription,  isnull([dbo].[PropertyRoom].RoomID, 0) as RoomID, " +
                            "isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice, BadgeProperty.PrivateEntrance, BadgeProperty.Kitchen, BadgeProperty.PrivateBathroom, BadgeProperty.Furnished, BadgeProperty.ClosetSpace, BadgeProperty.NonSmoker " +
                            "FROM [dbo].[Host] left join [dbo].[Property] on " +
                            "[dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] on [dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID inner join [dbo].[BadgeProperty] on [dbo].[PropertyRoom].RoomID = [dbo].[BadgeProperty].RoomID " +
                            "where [dbo].[Property].CityCounty = @city AND [dbo].[BadgeProperty].PrivateEntrance = @entrance AND [dbo].[BadgeProperty].Kitchen = @kitchen AND [dbo].[BadgeProperty].PrivateBathroom = @bathroom" +
                            " AND [dbo].[BadgeProperty].Furnished = @furnished AND [dbo].[BadgeProperty].ClosetSpace = @closet AND [dbo].[BadgeProperty].NonSmoker = @nonsmoker";


                    command.Parameters.AddWithValue("@city", propertySearch);
                    command.Parameters.AddWithValue("@entrance", entrance);
                    command.Parameters.AddWithValue("@kitchen", furnished);
                    command.Parameters.AddWithValue("@bathroom", bathroom);
                    command.Parameters.AddWithValue("@furnished", furnished);
                    command.Parameters.AddWithValue("@closet", closet);
                    command.Parameters.AddWithValue("@nonsmoker", nonsmoker);
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

                                string name = (string)reader["FirstName"] + " " + (string)reader["LastName"];
                                string location = (string)reader["CityCounty"] + ", " + (string)reader["HomeState"] + " " + (string)reader["Zip"];
                                
                                string description = (string)reader["BriefDescription"];
                                int id = Convert.ToInt32(reader["RoomID"]);
                                string backgroundCheckResult = reader["BackgroundCheckResult"].ToString().ToLower();
                                double price = Convert.ToDouble(reader["MonthlyPrice"]);
                                string fullAddress = (string)reader["HouseNumber"] + " " + (string)reader["Street"] + ", " + (string)reader["CityCounty"] + ", " +(string)reader["HomeState"] + " " + (string)reader["Zip"];
                                string propertyTitle = (string)reader["BriefDescription"];
                                byte[] imgData1;
                                byte[] imgData2;
                                byte[] imgData3;

                                try
                                {
                                    imgData1 = (byte[])reader["Image1"];
                                } catch
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
                                if(backgroundCheckResult == "y")
                                {
                                    backgroundCheckPhoto = "images/icons-07.png";
                                }


                                SearchResult result = new SearchResult(id, name, location, propertyTitle, description, price, image1, image2, image3, backgroundCheckPhoto);
                                result.setFullAddress(fullAddress);

                                SearchResult.lstSearchResults.Add(result);
                            }
                          
                        }
                        else
                        {
                            lblInvalidSearch.Text = "Search returned no properties";
                            return;
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
        Response.Redirect("SearchResults.aspx");


    }

 
}