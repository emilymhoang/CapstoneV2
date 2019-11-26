using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

//prop descrip
public partial class PropertyDescription : System.Web.UI.Page
{

    public string addressForMap;
    string privateEntrance;
    string kitchen;
    string privateBathroom;
    string furnish;
    string storage;
    string nonsmoker;
    protected void Page_Load(object sender, EventArgs e)
    {

        //var int = Session["tenantID"].ToString();
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                //grabbing host and property data
                int index = (int)Session["position"];

                var roomID1 = 0;

                bool holder = Favorite.lstFavorites.Count < 1;

                if (holder)
                {
                    var roomID = SearchResult.lstSearchResults[index].resultID;
                    lblHostName.Text = SearchResult.lstSearchResults[index].resultName;
                    lblPropName.Text = SearchResult.lstSearchResults[index].propertyTitle;
                    lblResultDesc.Text = SearchResult.lstSearchResults[index].resultDescription; //resultdescrip is short bio
                    lblResultLocation.Text = SearchResult.lstSearchResults[index].resultLocation;
                    lblResultPrice.Text = SearchResult.lstSearchResults[index].resultPrice;
                    lblHostBio.Text = SearchResult.lstSearchResults[index].hostBio; //find host bio
                    image1.ImageUrl = SearchResult.lstSearchResults[index].resultimage1;
                    image2.ImageUrl = SearchResult.lstSearchResults[index].resultimage2;
                    image3.ImageUrl = SearchResult.lstSearchResults[index].resultimage3;
                    imgbackgroundCheck.ImageUrl = SearchResult.lstSearchResults[index].backgroundCheckResult;
                    PropertyHeaderTextbox.Text = SearchResult.lstSearchResults[index].resultName + "'s Property";


                    //property room badges
                    int index1 = (int)Session["position"];
                    roomID1 = SearchResult.lstSearchResults[index1].resultID;
                    addressForMap = SearchResult.selectedReultFullAddress;
                }
                else
                {
                    var roomID = Favorite.lstFavorites[index].resultID;
                    lblHostName.Text = Favorite.lstFavorites[index].favName;
                    lblPropName.Text = Favorite.lstFavorites[index].propertyTitle;
                    lblResultDesc.Text = Favorite.lstFavorites[index].favDescription; //resultdescrip is short bio
                    lblResultLocation.Text = Favorite.lstFavorites[index].favLocation;
                    lblResultPrice.Text = Favorite.lstFavorites[index].favPrice;
                    lblHostBio.Text = Favorite.lstFavorites[index].hostBio; //find host bio
                    image1.ImageUrl = Favorite.lstFavorites[index].resultimage1;
                    image2.ImageUrl = Favorite.lstFavorites[index].resultimage2;
                    image3.ImageUrl = Favorite.lstFavorites[index].resultimage3;
                    imgbackgroundCheck.ImageUrl = Favorite.lstFavorites[index].backgroundCheckResult;
                    PropertyHeaderTextbox.Text = Favorite.lstFavorites[index].favName + "'s Property";


                    //property room badges
                    int index1 = (int)Session["position"];
                    roomID1 = Favorite.lstFavorites[index].resultID;
                    addressForMap = Favorite.selectedReultFullAddress;
                }

                SqlCommand badge2 = new SqlCommand("SELECT PrivateEntrance, Kitchen, PrivateBathroom, Furnished, ClosetSpace, NonSmoker FROM [dbo].[BadgeProperty] WHERE RoomID = @roomID", connection);
                badge2.Parameters.AddWithValue("@roomID", roomID1);

                connection.Open();
                SqlDataReader rdr2 = badge2.ExecuteReader();

                while (rdr2.Read())
                {
                    privateEntrance = HttpUtility.HtmlEncode(rdr2["privateEntrance"].ToString());
                    kitchen = HttpUtility.HtmlEncode(rdr2["Kitchen"].ToString());
                    privateBathroom = HttpUtility.HtmlEncode(rdr2["privateBathroom"].ToString());
                    furnish = HttpUtility.HtmlEncode(rdr2["Furnished"].ToString());
                    storage = HttpUtility.HtmlEncode(rdr2["ClosetSpace"].ToString());
                    nonsmoker = HttpUtility.HtmlEncode(rdr2["NonSmoker"].ToString());
                }

                if (privateEntrance == "y")
                {
                    privateEntranceBadge.ImageUrl = "images/badges-04.png";
                }
                else
                {
                    privateEntranceBadge.Visible = false;
                }

                if (kitchen == "y")
                {
                    kitchenBadge.ImageUrl = "images/badges-06.png";

                }
                else
                {
                    kitchenBadge.Visible = false;
                }

                if (privateBathroom == "y")
                {
                    privateBathroomBadge.ImageUrl = "images/badges-07.png";

                }
                else
                {
                    privateBathroomBadge.Visible = false;
                }

                if (furnish == "y")
                {
                    furnishBadge.ImageUrl = "images/badges-08.png";

                }
                else
                {
                    furnishBadge.Visible = false;
                }

                if (storage == "y")
                {
                    storageBadge.ImageUrl = "images/badges-09.png";

                }
                else
                {
                    storageBadge.Visible = false;
                }

                if (nonsmoker == "y")
                {
                    smokerBadge.ImageUrl = "images/badges-10.png";

                }
                else
                {
                    smokerBadge.Visible = false;
                }



                SqlCommand host = new SqlCommand("SELECT Property.HostID FROM Property INNER JOIN PropertyRoom ON Property.PropertyID = PropertyRoom.PropertyID WHERE RoomID = " + roomID1, connection);
                host.Connection = connection;
                int hostID = Convert.ToInt32(host.ExecuteScalar());
                hostIDforHH = hostID;

                host.ExecuteNonQuery();


                SqlCommand image = new SqlCommand("SELECT imageV2 FROM [dbo].[Host] WHERE HostID = " + hostID, connection);
                image.Connection = connection;
                byte[] ppImgData = (byte[])(image.ExecuteScalar());
                string ppImage = "data:image;base64," + Convert.ToBase64String(ppImgData, 0, ppImgData.Length);
                image7.ImageUrl = ppImage;

            }

        }

    }

    protected void FavoriteClick(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["tenantID"]) > 0)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
            {
                SqlCommand command = new SqlCommand();
                SqlCommand getName = new SqlCommand();

                command.Connection = connection;
                command.CommandType = CommandType.Text;

                int index = (int)Session["position"];
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
        if (!(Convert.ToInt32(Session["tenantID"]) > 0))
        {
            Response.Write("<script> alert('You need to login first.'); </script>");
            return;
        }
    }

    protected void goBack(object sender, EventArgs e)
    {
        Response.Redirect("SearchResults.aspx");
    }

   
}

