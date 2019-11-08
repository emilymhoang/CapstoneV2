using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class PropertyRoomInfo : System.Web.UI.Page
{    
    int PropertyID;
    
    double MonthlyPrice;
    int SquareFootage;
    int NumberBedrooms;

    SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submitPropRoom(object sender, EventArgs e)
    {
        sc.Open();
        SqlCommand insert = new SqlCommand("SELECT PropertyID FROM [Capstone].[dbo].[Property] WHERE HostID = @HostID", sc);
        insert.Parameters.AddWithValue("@HostID", Convert.ToInt32(Session["hostID"]));
        insert.Connection = sc;
        int propertyID = Convert.ToInt32(insert.ExecuteScalar());
        insert.ExecuteNonQuery();
        sc.Close();

        double monthlyPrice = Convert.ToDouble(monthlyPriceTextbox.Text);
        int sqFoot = Convert.ToInt32(squareFootageTextbox.Text);
        String avail = DropDownListAvailibility.SelectedValue;
        String display = displayTextbox.Text;
        
        PropertyRoom newRoom = new PropertyRoom(propertyID, monthlyPrice, sqFoot, avail, display);
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO [dbo].[PropertyRoom] ([PropertyID],[TenantID],[MonthlyPrice],[SquareFootage],[Availability],[BriefDescription],[LastUpdatedBy],[LastUpdated]) VALUES (@propid,@tenantid,@price,@sqft,@avail,@desc,@lub,@lu)";

                command.Parameters.AddWithValue("@propid", newRoom.propertyID);
                command.Parameters.AddWithValue("@tenantid", newRoom.tenantID);
                command.Parameters.AddWithValue("@price", newRoom.monthlyPrice);
                command.Parameters.AddWithValue("@sqft", newRoom.squareFootage);
                command.Parameters.AddWithValue("@avail", newRoom.availability);
                command.Parameters.AddWithValue("@desc", newRoom.briefDescription);
                command.Parameters.AddWithValue("@lub", "Kessler");
                command.Parameters.AddWithValue("@lu", DateTime.Now);


                try
                {
                    connection.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (Exception t)
                {
                    string f = t.ToString();
                }
                finally
                {
                    connection.Close();
                    Response.Redirect("CreateAccountSafetyHomeowner.aspx");
                }
            }
        }




    }

    protected void populate(object sender, EventArgs e)
    {
        monthlyPriceTextbox.Text = "800.00";
        squareFootageTextbox.Text = "500";
        displayTextbox.Text = "Basement bedroom near City with a balcony";
        rbFurnished.SelectedValue = "y";
        rbPets.SelectedValue = "y";
        rbPrivateBr.SelectedValue = "y";
        rbPrivateEntr.SelectedValue = "y";
        rbSmoke.SelectedValue = "n";
        rbStorage.SelectedValue = "y";

    }


}