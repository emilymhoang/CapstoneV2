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
    protected void Page_Load(object sender, EventArgs e)
    {
        lvSearchResults.DataSource = SearchResult.lstSearchResults;
        lvSearchResults.DataBind();
    }

    protected void FavoritesButton(object sender, EventArgs e)
    {
        //var int = Session["tenantID"].ToString();
        if (Convert.ToInt32(Session["tenantID"]) >0)
        {
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;

                    Button btn = sender as Button;
                    ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
                    var index = item.DataItemIndex;
                    var roomID = SearchResult.lstSearchResults[index].resultID;

                    command.CommandText = "SELECT PropertyID, HostID FROM [Capstone].[dbo].[Property] WHERE PropertyID = (Select PropertyID FROM [Capstone].[dbo].[PropertyRoom] where RoomID = @RoomID)";
                    //command.CommandText = "SELECT FirstName, LastName from [Capstone].[dbo].[Tenant] WHERE TenantID = @TenantID";
                    command.Parameters.AddWithValue("@RoomID", roomID);
                    //command.Parameters.AddWithValue("@TenantID", Convert.ToInt32(Session["tenantID"]));
                    int propertyID = 0, hostID = 0;
                    //string firstName = "", lastName = "";
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    propertyID = Convert.ToInt32(reader["PropertyID"]);
                                    hostID = Convert.ToInt32(reader["HostID"]);
                                    //firstName = reader["FirstName"].ToString();
                                    //lastName = reader["LastName"].ToString();
                                }

                            }
                        }
                        SqlCommand favorite = new SqlCommand("INSERT INTO [Capstone].[dbo].[Favorite] (TenantID, PropertyID, RoomID, SearchDate, LastUpdatedBy, LastUpdated, HostID)" +
                        " values (@TenantID, @PropertyID, @RoomID, @SearchDate, @LastUpdatedBy, @LastUpdated, @HostID)", connection);
                        favorite.Parameters.AddWithValue("@TenantID", Session["tenantID"].ToString());
                        favorite.Parameters.AddWithValue("@PropertyID", propertyID);
                        favorite.Parameters.AddWithValue("@RoomID", roomID);
                        favorite.Parameters.AddWithValue("@HostID", hostID);
                        favorite.Parameters.AddWithValue("@SearchDate", DateTime.Now.ToString("yyyy-MM-dd"));
                        favorite.Parameters.AddWithValue("@LastUpdatedBy", "Emily");
                        favorite.Parameters.AddWithValue("@LastUpdated", DateTime.Now.ToString("yyyy-MM-dd") + DateTime.Now.ToString("hh:mm:ss"));
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

        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}