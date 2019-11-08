using System;
using System.Collections.Generic;

using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditProfileTenant : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    int tenantID;
    protected void Page_Load(object sender, EventArgs e)
    {
        sc.Open();
        String username = Session["username"].ToString();

        SqlCommand insert = new SqlCommand("SELECT TenantID FROM [Capstone].[dbo].[Login] WHERE Username = @Username", sc);
        insert.Parameters.AddWithValue("@Username", username);
        insert.Connection = sc;
        tenantID = Convert.ToInt32(insert.ExecuteScalar());
        insert.ExecuteNonQuery();
        SqlCommand filter = new SqlCommand("SELECT Email, PhoneNumber, Firstname, MiddleName, LastName, BirthDate," +
                            "Gender, BackgroundCheckDate, BackgroundCheckResult, LastUpdatedBy, LastUpdated FROM [Capstone].[dbo].[Tenant] WHERE " +
                            "TenantID = " + tenantID, sc);

        SqlDataReader rdr = filter.ExecuteReader();
        while (rdr.Read())
        {
            firstNameTextbox.Text = rdr["FirstName"].ToString();
            lastNameTextbox.Text = rdr["LastName"].ToString();
            emailTextbox.Text = rdr["Email"].ToString();
            phoneNumberTextbox.Text = rdr["PhoneNumber"].ToString();
        }
        passwordTextbox.Text = "";


    }
    protected void saveChanges(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlCommand update = new System.Data.SqlClient.SqlCommand();
        System.Data.SqlClient.SqlCommand updateLogin = new System.Data.SqlClient.SqlCommand();

        update.Connection = sc;
        updateLogin.Connection = sc;

        //SqlCommand filter = new SqlCommand("SELECT Email, PhoneNumber, Firstname, MiddleName, LastName, BirthDate, Password," +
        //                    "Gender, BackgroundCheckDate, BackgroundCheckResult, LastUpdatedBy, LastUpdated, Username, ConfirmPassword FROM [Capstone].[dbo].[Tenant] WHERE" +
        //                    "TenantID = " + tenantID, sc);

        update.CommandText = "UPDATE [Capstone].[dbo].[Tenant] SET Email= @Email, PhoneNumber= @PhoneNumber, FirstName= @FirstName," +
            "LastName = @LastName WHERE TenantID = " + tenantID;

        updateLogin.CommandText = "UPDATE [Capstone].[dbo].[Login] SET Password = @Password WHERE TenantID = " + tenantID;

        update.Parameters.AddWithValue("@Email", emailTextbox.Text);
        update.Parameters.AddWithValue("@PhoneNumber", phoneNumberTextbox.Text);
        update.Parameters.AddWithValue("@FirstName", firstNameTextbox.Text);
        update.Parameters.AddWithValue("@LastName", lastNameTextbox.Text);
        updateLogin.Parameters.AddWithValue("@Password", passwordTextbox.Text);

        resultmessage.Text = "Profile is updated.";
        update.ExecuteNonQuery();
        Session["FirstName"] = firstNameTextbox.Text;
        Session["LastName"] = lastNameTextbox.Text;
        Session["PhoneNumber"] = phoneNumberTextbox.Text;
        sc.Close();
        
    }
}
