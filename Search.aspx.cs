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
                        "[dbo].[Property].HomeState, [dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription,  isnull([dbo].[PropertyRoom].RoomID, 0) as RoomID, " +
                        "isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice from [dbo].[Host] left join [dbo].[Property] on " +
                        "[dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] on [dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID " +
                        "where [dbo].[Property].Zip = @zip";

                    command.Parameters.AddWithValue("@zip", propertySearch);
                }
                else
                {
                    command.CommandText = "select isnull([dbo].[PropertyRoom].Image1, 0), isnull([dbo].[PropertyRoom].Image2, 0)," +
                        " isnull([dbo].[PropertyRoom].Image3, 0)" +
                        ", [dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Property].CityCounty, [dbo].[Property].HomeState, " +
                        "[dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') as BriefDescription, isnull([dbo].[PropertyRoom].RoomID, 0) as RoomID, " +
                        "isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice from " +
                        "[dbo].[Host] left join [dbo].[Property] on [dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] " +
                        "on [dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID where [dbo].[Property].CityCounty = @city";

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

                                string name = (string)reader["FirstName"] + " " + (string)reader["LastName"];
                                string location = (string)reader["CityCounty"] + ", " + (string)reader["HomeState"] + " " + (string)reader["Zip"];
                                
                                string description = (string)reader["BriefDescription"];
                                int id = Convert.ToInt32(reader["RoomID"]);

                                double price = Convert.ToDouble(reader["MonthlyPrice"]);

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



                                SearchResult result = new SearchResult(id, name, location, description, price, image1, image2, image3);

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