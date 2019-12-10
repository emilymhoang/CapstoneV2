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
        if (!IsPostBack)
        {
            if (Request.Cookies["Username"] != null && Request.Cookies["Password"] != null)
            {
                userNameTextbox.Text = Request.Cookies["Username"].Value;
                passwordTextbox.Text = Request.Cookies["Password"].Value;
            }
        }
    }

    

    protected void submitLogin_Click(object sender, EventArgs e)
    {

        if (SaveLogin.Checked)
        {
            Response.Cookies["Username"].Value = userNameTextbox.Text;
            Response.Cookies["Password"].Value = passwordTextbox.Text;

            Response.Cookies["Email"].Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(10);

        }
        else
        {
            Response.Cookies["Email"].Expires = DateTime.Now.AddMinutes(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(-1);

        }

        // connect to database to retrieve stored password stringhttp://localhost:58981/Login.aspx.cs
        //try
        System.Data.SqlClient.SqlCommand findPass = new System.Data.SqlClient.SqlCommand();
            findPass.Connection = sc;
            // SELECT PASSWORD STRING WHERE THE ENTERED USERNAME MATCHES
            sc.Open();
            findPass.CommandText = "select Password from [dbo].[Login] where Username = @Username";
            findPass.Parameters.Add(new SqlParameter("@Username", userNameTextbox.Text));

            SqlDataReader reader = findPass.ExecuteReader(); // create a reader

            if (reader.HasRows) // if the username exists, it will continue
            {
                while (reader.Read()) // this will read the single record that matches the entered username
                {
                    string storedHash = HttpUtility.HtmlEncode(reader["Password"].ToString()); // store the database password into this variable

                    if (PasswordHash.ValidatePassword(passwordTextbox.Text, storedHash)) // if the entered password matches what is stored, it will show success
                    {
                        resultmessage.Text = "Success!";
                        loginButton.Enabled = false;
                        userNameTextbox.Enabled = false;
                        passwordTextbox.Enabled = false;
                        SqlCommand insert = new SqlCommand("SELECT AccountID FROM [dbo].[Login] WHERE Username = @Username", sc);
                        insert.Parameters.AddWithValue("@Username", userNameTextbox.Text);
                        insert.Connection = sc;
                        int accountID = Convert.ToInt32(insert.ExecuteScalar());
                        insert.ExecuteNonQuery();
                        Session["AccountID"] = accountID;
                        Session["username"] = userNameTextbox.Text;
                        Session["LoggedIn"] = "true";


                        SqlCommand filter = new SqlCommand("SELECT TenantID, HostID, AdminID FROM [dbo].[Login] WHERE AccountID = @AccountID", sc);
                        filter.Parameters.AddWithValue("@AccountID", accountID);
                        SqlDataReader rdr = filter.ExecuteReader();
                        string tenantID = "", hostID = "", adminID = "";
                        while (rdr.Read())
                        {
                            tenantID = HttpUtility.HtmlEncode(rdr["TenantID"].ToString());
                            hostID = HttpUtility.HtmlEncode(rdr["HostID"].ToString());
                            adminID = HttpUtility.HtmlEncode(rdr["AdminID"].ToString());
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

    }

    protected void SaveLogin_CheckedChanged(object sender, EventArgs e)
    {

    }

} 