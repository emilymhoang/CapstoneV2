using System;
using System.Collections.Generic;
using System.Configuration;
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

            SqlCommand insert = new SqlCommand("SELECT TenantID FROM [dbo].[Login] WHERE Username = @Username", sc);
            insert.Parameters.AddWithValue("@Username", username);
            insert.Connection = sc;
            tenantID = Convert.ToInt32(insert.ExecuteScalar());
            insert.ExecuteNonQuery();
            SqlCommand filter = new SqlCommand("SELECT Email, PhoneNumber, Firstname, MiddleName, LastName, BirthDate," +
                                "Gender, BackgroundCheckDate, BackgroundCheckResult, LastUpdatedBy, LastUpdated FROM [dbo].[Tenant] WHERE " +
                                "TenantID = " + tenantID, sc);
        if (IsPostBack == false)
        {
            SqlDataReader rdr = filter.ExecuteReader();

            while (rdr.Read())
            {
                HttpUtility.HtmlEncode(firstNameTextbox.Text = rdr["FirstName"].ToString());
                HttpUtility.HtmlEncode(lastNameTextbox.Text = rdr["LastName"].ToString());
                HttpUtility.HtmlEncode(emailTextbox.Text = rdr["Email"].ToString());
                HttpUtility.HtmlEncode(phoneNumberTextbox.Text = rdr["PhoneNumber"].ToString());
            }
            passwordTextbox.Text = "";
        }


    }
    protected void saveChanges(object sender, EventArgs e)
    {
        using (SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand update = new SqlCommand())
            {
                try
                {
                    update.Connection = sc;
                    update.CommandText = "UPDATE [dbo].[Tenant] SET Email= @Email, PhoneNumber= @PhoneNumber, FirstName= @FirstName," +
                    "LastName = @LastName WHERE TenantID = " + tenantID;
                    update.Parameters.AddWithValue("@Email", emailTextbox.Text);
                    update.Parameters.AddWithValue("@PhoneNumber", phoneNumberTextbox.Text);
                    update.Parameters.AddWithValue("@FirstName", firstNameTextbox.Text);
                    update.Parameters.AddWithValue("@LastName", lastNameTextbox.Text);
                    sc.Open();

                    //email stuff
                    String emailNew = emailTextbox.Text;
                    Session["Email"] = emailNew;
                    SqlCommand emailCheck = new SqlCommand("SELECT Count(*) FROM [dbo].[Tenant] WHERE lower(email) = @Email", sc);
                    emailCheck.Parameters.AddWithValue("@Email", emailNew);
                    emailCheck.Connection = sc;
                    int count = Convert.ToInt32(emailCheck.ExecuteScalar());
                    emailCheck.ExecuteNonQuery();

                    if (count <= 1)
                    {

                    Session["email"] = emailTextbox.Text;
                    update.ExecuteNonQuery();
                    resultmessage.Text = "Profile is updated.";
                    Session["FirstName"] = firstNameTextbox.Text;
                    Session["LastName"] = lastNameTextbox.Text;
                    Session["PhoneNumber"] = phoneNumberTextbox.Text;

                    }
                    else
                    {
                        resultmessage.Text = "Email already exists.";
                    }
                    
                }
                catch (Exception t)
                {
                    string f = t.ToString();
                }
                finally
                {
                    sc.Close();

                }

            }
          
            using (SqlCommand updateLogin = new SqlCommand())
            {
                updateLogin.Connection = sc;
                updateLogin.CommandText = "UPDATE [dbo].[Login] SET Password = @Password WHERE TenantID = " + tenantID;
                updateLogin.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(passwordTextbox.Text));

                try
                {
                    sc.Open();
                    updateLogin.ExecuteNonQuery();
                    //resultmessage.Text = "Profile is updated.";
                }
                catch (Exception t)
                {
                    string f = t.ToString();
                }
                finally
                {
                    sc.Close();

                }
            }
            
            
        }
    }
    protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("TenantDashboard.aspx");

        }
}

   

