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

    private List<string> lstFilterCriteria = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            lvSearchResults.DataSource = SearchResult.lstSearchResults;
            lvSearchResults.DataBind();
        }
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
                                    propertyID = Convert.ToInt32(reader["PropertyID"]);
                                    hostID = Convert.ToInt32(reader["HostID"]);
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
                                firstName = reader["FirstName"].ToString();
                                lastName = reader["LastName"].ToString();
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