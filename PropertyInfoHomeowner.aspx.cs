using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class PropertyInfoHomeowner : System.Web.UI.Page
{
    //Create database connection
    SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);

    int HostID;
    int HouseNumber;
    String Street;
    int Zip;
    String CityCounty;
    String HomeState;
    String Country;
    double MonthlyPrice;
    int NumberBedrooms;



    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void submitPropInfo(object sender, EventArgs e)
    {
        //property validation
        if (houseNumTextbox.Text.Length > 10)
        {
            propertyResult.Text = "House Number must be less than 10 numbers.";
            return;
        }
        if ((zipTextbox.Text.Length > 9) || (zipTextbox.Text.Length < 5))
        {
            zipValidator.Text = "Zipcode must be more than 5 numbers and less than 9 numbers.";
            return;
        }

        String houseNumNew = houseNumTextbox.Text;
        String streetNew = StreetTextbox.Text;
        Session["HouseNumber"] = houseNumNew;
        Session["Street"] = streetNew;
        Session["Zip"] = zipTextbox.Text;
        Session["CityCounty"] = cityTextbox.Text;
        Session["HomeState"] = DropDownListState.SelectedValue;
        


        sc.Open();
        SqlCommand propCheck = new SqlCommand("SELECT Count(*) FROM [dbo].[Property] WHERE HouseNumber = @HouseNumber AND Street = @Street", sc);

        propCheck.Parameters.AddWithValue("@HouseNumber", houseNumNew);
        propCheck.Parameters.AddWithValue("@Street", streetNew);
        propCheck.Connection = sc;
        int count = Convert.ToInt32(propCheck.ExecuteScalar());
        propCheck.ExecuteNonQuery();
        sc.Close();



        System.Data.SqlClient.SqlCommand insertProperty = new System.Data.SqlClient.SqlCommand();
        insertProperty.Connection = sc;
       
        if (count == 0)
        {
            Property newProp = new Property(HouseNumber, Street, CityCounty, HomeState, Country, Zip);
            //resultmessage.Text = "";
            insertProperty.CommandText = "INSERT INTO [dbo].[Property] (HouseNumber, Street, Zip, CityCounty, HomeState, Country," +
                                "MonthlyPrice, NumberBedrooms, LastUpdatedBy, LastUpdated, HostID) VALUES (@HouseNumber, @Street, @Zip, @CityCounty," +
                                "@HomeState, @Country, @MonthlyPrice, @NumberBedrooms, @LastUpdatedBy, @LastUpdated, @HostID); ";
            //insert into property database table
            insertProperty.Parameters.AddWithValue("@HouseNumber", houseNumNew);
            insertProperty.Parameters.AddWithValue("@Street", streetNew);
            insertProperty.Parameters.AddWithValue("@Zip", Session["Zip"].ToString());
            insertProperty.Parameters.AddWithValue("@CityCounty", Session["CityCounty"].ToString());
            insertProperty.Parameters.AddWithValue("@HomeState", Session["HomeState"].ToString());
            insertProperty.Parameters.AddWithValue("@Country", "US");
            insertProperty.Parameters.AddWithValue("@MonthlyPrice", "500");
            insertProperty.Parameters.AddWithValue("@NumberBedrooms", "1");
            insertProperty.Parameters.AddWithValue("@LastUpdatedBy", "Kessler");
            insertProperty.Parameters.AddWithValue("@LastUpdated", DateTime.Now);
            insertProperty.Parameters.AddWithValue("@HostID", Convert.ToInt32(Session["hostID"]));

            sc.Open();
            insertProperty.ExecuteNonQuery();
            

            sc.Close();
            Response.Redirect("PropertyRoomInfo.aspx");
        }
        else
        {
            propertyResult.Text = "Property already exists.";
        }
    }
}
