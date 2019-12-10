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
    //create database connection
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    int tenantID;
    protected void Page_Load(object sender, EventArgs e)
    {
            sc.Open();
            String username = Session["username"].ToString();
            
            //grab tenantID of current user
            SqlCommand insert = new SqlCommand("SELECT TenantID FROM [dbo].[Login] WHERE Username = @Username", sc);
            insert.Parameters.AddWithValue("@Username", username);
            insert.Connection = sc;
            tenantID = Convert.ToInt32(insert.ExecuteScalar());
            insert.ExecuteNonQuery();

        //grab tenant information that will prepopulate textboxes
        SqlCommand filter = new SqlCommand("SELECT Email, PhoneNumber, Firstname, MiddleName, LastName, BirthDate," +
                                "Gender, BackgroundCheckDate, BackgroundCheckResult, LastUpdatedBy, LastUpdated, TenantBio FROM [dbo].[Tenant] WHERE " +
                                "TenantID = @tenantID", sc);

        filter.Parameters.AddWithValue("@tenantID", tenantID);
        filter.Connection = sc;
        filter.ExecuteNonQuery();
        if (IsPostBack == false)
        {
            SqlDataReader rdr = filter.ExecuteReader();

            while (rdr.Read())
            {
                HttpUtility.HtmlEncode(firstNameTextbox.Text = rdr["FirstName"].ToString());
                HttpUtility.HtmlEncode(lastNameTextbox.Text = rdr["LastName"].ToString());
                HttpUtility.HtmlEncode(emailTextbox.Text = rdr["Email"].ToString());
                HttpUtility.HtmlEncode(phoneNumberTextbox.Text = rdr["PhoneNumber"].ToString());
                HttpUtility.HtmlEncode(TenantBioTextbox.Text = rdr["TenantBio"].ToString());
            }
            passwordTextbox.Text = "";
        }


    }

    //update database with new changes
    protected void saveChanges(object sender, EventArgs e)
    {
        //create database connection
        using (SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand update = new SqlCommand())
            {
                try
                {
                    //update tenant table with new information
                    update.Connection = sc;
                    update.CommandText = "UPDATE [dbo].[Tenant] SET Email= @Email, PhoneNumber= @PhoneNumber, FirstName= @FirstName," +
                    "LastName = @LastName, TenantBio = @TenantBio WHERE TenantID = @tenantID";
                    update.Parameters.AddWithValue("@Email", emailTextbox.Text);
                    update.Parameters.AddWithValue("@PhoneNumber", phoneNumberTextbox.Text);
                    update.Parameters.AddWithValue("@FirstName", firstNameTextbox.Text);
                    update.Parameters.AddWithValue("@LastName", lastNameTextbox.Text);
                    update.Parameters.AddWithValue("@TenantBio", TenantBioTextbox.Text);
                    update.Parameters.AddWithValue("@tenantID", tenantID);
                    sc.Open();

                    //update email
                    String emailNew = emailTextbox.Text;
                    Session["Email"] = emailNew;
                    SqlCommand emailCheck = new SqlCommand("SELECT Count(*) FROM [dbo].[Tenant] WHERE lower(email) = @Email", sc);
                    emailCheck.Parameters.AddWithValue("@Email", emailNew);
                    emailCheck.Connection = sc;
                    int count = Convert.ToInt32(emailCheck.ExecuteScalar());
                    emailCheck.ExecuteNonQuery();

                    //validate email is available
                    if (count <= 1)
                    {

                    Session["email"] = emailTextbox.Text;
                    update.ExecuteNonQuery();
                    resultmessage.Text = "Profile is updated.";
                    Session["FirstName"] = firstNameTextbox.Text;
                    Session["LastName"] = lastNameTextbox.Text;
                    Session["PhoneNumber"] = phoneNumberTextbox.Text;
                    Session["TenantBio"] = TenantBioTextbox.Text;

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

            //update login with new password
            using (SqlCommand updateLogin = new SqlCommand())
            {
                updateLogin.Connection = sc;
                updateLogin.CommandText = "UPDATE [dbo].[Login] SET Password = @Password WHERE TenantID = @tenantID";
                updateLogin.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(passwordTextbox.Text));
                updateLogin.Parameters.AddWithValue("@tenantID", tenantID);


                try
                {
                    sc.Open();
                    updateLogin.ExecuteNonQuery();
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

   

