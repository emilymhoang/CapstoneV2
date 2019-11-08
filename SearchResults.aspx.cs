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
        Property.lstPropertySearchResults.Clear();



        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["CapstoneConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int house = Convert.ToInt32(reader["HouseNumber"]);
                                string street = (string)reader["Street"];
                                string city = (string)reader["CityCounty"];
                                string state = (string)reader["HomeState"];
                                string country = (string)reader["Country"];
                                int zip = Convert.ToInt32(reader["Zip"]);
                                double price = Convert.ToDouble(reader["PriceRange"]);
                                int rooms = (int)reader["NumberBedrooms"];
                                int availability = 1;
                                int host = (int)reader["HostID"];
                                int tenantID = (int)reader["TenantID"];


                                //Favorite fav = new Favorite(house, street, city, state, country, zip, price, rooms, availability, host, tenantID);

                                //Favorite.lstFavorites.Add(fav);
                            }

                        }
                        else
                        {
                            //no favs found
                        }

                    }
                }
                catch (SqlException t)
                {
                    string b = t.ToString();
                }

            }
        }

    }
    //protected void addFavorite(object sender, EventArgs e)
    //{
    //    using (SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
    //    {
    //        SqlCommand insert = new SqlCommand("INSERT INTO [Capstone].[dbo].[Favorite] (TenantID, HostID, PropertyID, RoomID, SearchDate, LastUpdatedBy, LastUpdated) VALUES (" +
    //            "@TenantID, @HostID, @PropertyID, @RoomID, @SearchDate, @LastUpdatedBy, @LastUpdated)", sc);
    //        insert.Parameters.AddWithValue("@TenantID", Session["tenantID"].ToString());
    //        insert.Parameters.AddWithValue("@HostID", );
    //        insert.Parameters.AddWithValue("@PropertyID", );
    //        insert.Parameters.AddWithValue("@RoomID", );
    //        insert.Parameters.AddWithValue("@SearchDate", DateTime.Now);
    //        insert.Parameters.AddWithValue("@LastUpdatedBy", Session["firstName"].ToString() + " " + Session["LastName"].ToString());
    //        insert.Parameters.AddWithValue("@LastUpdated", DateTime.Now);
    //        insert.ExecuteNonQuery();
    //    }

    }