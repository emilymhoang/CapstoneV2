using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        //this is page load. yes it is
    }

    protected void submitLogin_Click(object sender, EventArgs e)
    {
        // connect to database to retrieve stored password stringhttp://localhost:58981/Login.aspx.cs
        //try
            System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
            findPass.Connection = sc;
            // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
            sc.Open();
            findPass.CommandText = "select Password from [Capstone].[dbo].[Login] where Username = @Username";
            findPass.Parameters.Add(new SqlParameter("@Username", userNameTextbox.Text));

            SqlDataReader reader = findPass.ExecuteReader(); // create a reader

            if (reader.HasRows) // if the username exists, it will continue
            {
                while (reader.Read()) // this will read the single record that matches the entered username
                {
                    string storedHash = reader["Password"].ToString(); // store the database password into this variable

                    if (PasswordHash.ValidatePassword(passwordTextbox.Text, storedHash)) // if the entered password matches what is stored, it will show success
                    {
                        resultmessage.Text = "Success!";
                        loginButton.Enabled = false;
                        userNameTextbox.Enabled = false;
                        passwordTextbox.Enabled = false;
                        SqlCommand insert = new SqlCommand("SELECT AccountID FROM [Capstone].[dbo].[Login] WHERE Username = @Username", sc);
                        insert.Parameters.AddWithValue("@Username", userNameTextbox.Text);
                        insert.Connection = sc;
                        int accountID = Convert.ToInt32(insert.ExecuteScalar());
                        insert.ExecuteNonQuery();
                        Session["AccountID"] = accountID;
                        Session["username"] = userNameTextbox.Text;
                        Session["LoggedIn"] = "true";


                        SqlCommand filter = new SqlCommand("SELECT TenantID, HostID, AdminID FROM [Capstone].[dbo].[Login] WHERE AccountID = @AccountID", sc);
                        filter.Parameters.AddWithValue("@AccountID", accountID);
                        SqlDataReader rdr = filter.ExecuteReader();
                        string tenantID = "", hostID = "", adminID = "";
                        while (rdr.Read())
                        {
                            tenantID = rdr["TenantID"].ToString();
                            hostID = rdr["HostID"].ToString();
                            adminID = rdr["AdminID"].ToString();
                        }

                        if (tenantID != "")
                        {
                            Response.Redirect("TenantDashboard.aspx");
                        }
                    else if(hostID != "")
                        {
                            Response.Redirect("HostDashboard.aspx");
                        }
                        else if (adminID != "")
                        {
                            Response.Redirect("AdminDashboard.aspx");
                    }
                }
                    else
                        resultmessage.Text = "Password is wrong.";
                }
            }
            else
            { // if the username doesn't exist, it will show failure
                resultmessage.Text = "User does not exist.";
            }
        sc.Close();

        //}
        //catch
        //{
        //    resultmessage.Text = "Database Error.";
        //}
    }

//    protected Boolean EmailValidation(String email)
//{
//    Boolean emailRegistered = false;
//    SqlCommand checkUser;
//    sc.Open();
//    //parameterized queries with XXS
//    checkUser = new SqlCommand("Select count(*) from [CapProject].[dbo].[Login] where (Email = @Email)", sc);
//    checkUser.Parameters.AddWithValue("@Email", HttpUtility.HtmlEncode(userNameTextbox.Text));
//    int userExist = (int)checkUser.ExecuteScalar();
//    sc.Close();

//    //works if the login info is already in DB but not if it's not 
//    if (userExist > 0)
//    {
//        emailRegistered = true;

//    }
//    else
//    {
//        emailRegistered = false;
//    }

//    return emailRegistered;
//    }
} 