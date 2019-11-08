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
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                if (searchBy)
                {
                    command.CommandText = "select [dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Property].CityCounty, " +
                        "[dbo].[Property].HomeState, [dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription, " +
                        "isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice from [dbo].[Host] left join [dbo].[Property] on " +
                        "[dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] on [dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID " +
                        "where [dbo].[Property].Zip = @zip";

                    command.Parameters.AddWithValue("@zip", propertySearch);
                }
                else
                {
                    command.CommandText = "select [dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Property].CityCounty, [dbo].[Property].HomeState, " +
                        "[dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription, isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice from " +
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
                                
                                
                                double price = Convert.ToDouble(reader["MonthlyPrice"]);
                                
                                SearchResult result = new SearchResult(name, location, description, price);

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
        Response.Redirect("SearchResults.aspx");


    }









}