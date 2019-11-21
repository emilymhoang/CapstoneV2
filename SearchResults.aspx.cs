using System;
using System.Collections.Generic;

using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchResults : System.Web.UI.Page
{
    string privateEntrance;
    string kitchen;
    string privateBathroom;
    string furnish;
    string storage;
    string nonsmoker;
    private List<string> lstFilterCriteria = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            lvSearchResults.DataSource = SearchResult.lstSearchResults;
            lvSearchResults.DataBind();
        }
        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);




        //foreach (var item in SearchResult.lstSearchResults)
        //{
        //    ListViewItem itemm = (ListViewItem)(sender as Control).NamingContainer;
        //    var index = itemm.DataItemIndex;
        //    var roomID1 = SearchResult.lstSearchResults[index].resultID;

        //    Image imageEntrance = (Image)Page.FindControl("privateEntranceBadge");
        //    Image imageKitchen = (Image)Page.FindControl("kitchenBadge");
        //    Image imageBathroom = (Image)Page.FindControl("privateBathroomBadge");
        //    Image imageFurnish = (Image)Page.FindControl("furnishBadge");
        //    Image imageStorage = (Image)Page.FindControl("storageBadge");
        //    Image imageSmoker = (Image)Page.FindControl("smokerBadge");

        //    SqlCommand badge2 = new SqlCommand("SELECT PrivateEntrance, Kitchen, PrivateBathroom, Furnished, ClosetSpace, NonSmoker FROM [dbo].[BadgeProperty] WHERE RoomID = @roomID", connection);
        //    badge2.Parameters.AddWithValue("@roomID", roomID1);


        //    connection.Open();
        //    SqlDataReader rdr2 = badge2.ExecuteReader();

        //    while (rdr2.Read())
        //    {
        //        privateEntrance = HttpUtility.HtmlEncode(rdr2["privateEntrance"].ToString());
        //        kitchen = HttpUtility.HtmlEncode(rdr2["Kitchen"].ToString());
        //        privateBathroom = HttpUtility.HtmlEncode(rdr2["privateBathroom"].ToString());
        //        furnish = HttpUtility.HtmlEncode(rdr2["Furnished"].ToString());
        //        storage = HttpUtility.HtmlEncode(rdr2["ClosetSpace"].ToString());
        //        nonsmoker = HttpUtility.HtmlEncode(rdr2["NonSmoker"].ToString());
        //    }

        //    if (privateEntrance == "y")
        //    {
        //        imageEntrance.ImageUrl = "images/badges-04.png";
        //    }
        //    else
        //    {
        //        imageEntrance.Visible = false;
        //    }

        //    if (kitchen == "y")
        //    {
        //        imageKitchen.ImageUrl = "images/badges-06.png";

        //    }
        //    else
        //    {
        //        imageKitchen.Visible = false;
        //    }

        //    if (privateBathroom == "y")
        //    {
        //        imageBathroom.ImageUrl = "images/badges-07.png";

        //    }
        //    else
        //    {
        //        imageBathroom.Visible = false;
        //    }

        //    if (furnish == "y")
        //    {
        //        imageFurnish.ImageUrl = "images/badges-08.png";

        //    }
        //    else
        //    {
        //        imageFurnish.Visible = false;
        //    }

        //    if (storage == "y")
        //    {
        //        imageStorage.ImageUrl = "images/badges-09.png";

        //    }
        //    else
        //    {
        //        imageStorage.Visible = false;
        //    }

        //    if (nonsmoker == "y")
        //    {
        //        imageSmoker.ImageUrl = "images/badges-10.png";

        //    }
        //    else
        //    {
        //        imageSmoker.Visible = false;
        //    }
        //}
       
    }
    protected void search_Click(object sender, EventArgs e)
    {
        SearchResult.lstSearchResults.Clear();
        Favorite.lstFavorites.Clear();

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
    protected void FavoritesButton(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["tenantID"]) >0)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                    SqlCommand getName = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    Button btn = sender as Button;
                    ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
                    var index = item.DataItemIndex;
                    var roomID = SearchResult.lstSearchResults[index].resultID;

                    command.CommandText = "SELECT PropertyID, HostID FROM [dbo].[Property] WHERE PropertyID = (Select PropertyID FROM [dbo].[PropertyRoom] where RoomID = @RoomID)";
                    command.Parameters.AddWithValue("@RoomID", roomID);
                    int propertyID = 0, hostID = 0;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    propertyID = Convert.ToInt32(HttpUtility.HtmlEncode(reader["PropertyID"]));
                                    hostID = Convert.ToInt32(HttpUtility.HtmlEncode(reader["HostID"]));
                                }

                            }
                        }
                    getName.Connection = connection;
                    getName.CommandType = CommandType.Text;
                    getName.CommandText = "SELECT FirstName, LastName from [dbo].[Tenant] WHERE TenantID = @TenantID";
                    getName.Parameters.AddWithValue("@TenantID", Convert.ToInt32(Session["tenantID"]));
                    string firstName = "", lastName = "";

                    using (SqlDataReader reader = getName.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                firstName = HttpUtility.HtmlEncode(reader["FirstName"].ToString());
                                lastName = HttpUtility.HtmlEncode(reader["LastName"].ToString());
                            }

                        }
                    }

                    SqlCommand favorite = new SqlCommand("INSERT INTO [dbo].[Favorite] (TenantID, PropertyID, RoomID, SearchDate, LastUpdatedBy, LastUpdated, HostID)" +
                        " values (@TenantID, @PropertyID, @RoomID, @SearchDate, @LastUpdatedBy, @LastUpdated, @HostID)", connection);
                        favorite.Parameters.AddWithValue("@TenantID", Session["tenantID"].ToString());
                        favorite.Parameters.AddWithValue("@PropertyID", propertyID);
                        favorite.Parameters.AddWithValue("@RoomID", roomID);
                        favorite.Parameters.AddWithValue("@HostID", hostID);
                        favorite.Parameters.AddWithValue("@SearchDate", DateTime.Now);
                        favorite.Parameters.AddWithValue("@LastUpdatedBy", firstName + " " + lastName);
                        favorite.Parameters.AddWithValue("@LastUpdated", DateTime.Now);
                        favorite.ExecuteNonQuery();
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
        else
        {
            Response.Write("<script> alert('You need to login first.'); </script>");
            return;
        }
    }
    protected void profileButton(object sender, EventArgs e)
    {

        SearchResult.selectedReultFullAddress = string.Empty;
        Button btn = sender as Button;
        ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
        var index = item.DataItemIndex;
        Session["position"] = index;
        SearchResult.selectedReultFullAddress = SearchResult.lstSearchResults[index].resultFullAddress;
        Response.Redirect("PropertyDescription.aspx");
    }


    protected void btnFilterResults_Click(object sender, EventArgs e)
    {
        lstFilterCriteria.Clear();
        SearchResult.lstFilteredResults.Clear();

        //populating filtered list
        if (privateEntranceCheck.Checked)
        {
            lstFilterCriteria.Add("y");
        }
        else
        {
            lstFilterCriteria.Add("na");
        }
        if (kitchenCheck.Checked)
        {
            lstFilterCriteria.Add("y");
        }
        else
        {
            lstFilterCriteria.Add("na");
        }
        if (furnishedCheck.Checked)
        {
            lstFilterCriteria.Add("y");
        }
        else
        {
            lstFilterCriteria.Add("na");
        }
        if (closetCheck.Checked)
        {
            lstFilterCriteria.Add("y");
        }
        else
        {
            lstFilterCriteria.Add("na");
        }
        if (nonSmokerCheck.Checked)
        {
            lstFilterCriteria.Add("y");
        }
        else
        {
            lstFilterCriteria.Add("na");
        }
        if (privateBathroomCheck.Checked)
        {
            lstFilterCriteria.Add("y");
        }
        else
        {
            lstFilterCriteria.Add("na");
        }

        foreach (var result in SearchResult.lstSearchResults)
        {
            bool match = true;
            for (int i = 0; i < lstFilterCriteria.Count; i++)
            {
                if (lstFilterCriteria[i].Equals("na"))
                {
                    continue;
                } else if (!lstFilterCriteria[i].Equals(result.lstPropertyBadges[i]))
                {
                    match = false;
                    break;
                }
            }

            if(match == true)
            {
                SearchResult.lstFilteredResults.Add(result);
            }

        }

        lvSearchResults.DataSource = SearchResult.lstFilteredResults;
        lvSearchResults.DataBind();


    }
}