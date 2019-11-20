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
            //if (furnishedCheck.Checked)
            //{
            //    furnished = "y";
            //}
            //else
            //{
            //    furnished = "n";
            //}
            //if (privateBathroomCheck.Checked)
            //{
            //    bathroom = "y";
            //}
            //else
            //{
            //    bathroom = "n";
            //}
            //if (closetCheck.Checked)
            //{
            //    closet = "y";
            //}
            //else
            //{
            //    closet = "n";
            //}
            //if (kitchenCheck.Checked)
            //{
            //    kitchen = "y";
            //}
            //else
            //{
            //    kitchen = "n";
            //}
            //if (nonSmokerCheck.Checked)
            //{
            //    nonsmoker = "y";
            //}
            //else
            //{
            //    nonsmoker = "n";
            //}
            //if (privateEntranceCheck.Checked)
            //{
            //    entrance = "y";
            //}
            //else
            //{
            //    entrance = "n";
            //}
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
                                string location = HttpUtility.HtmlEncode((string)reader["CityCounty"]) + ", " + HttpUtility.HtmlEncode((string)reader["HomeState"] )+ " " + HttpUtility.HtmlEncode((string)reader["Zip"]);
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