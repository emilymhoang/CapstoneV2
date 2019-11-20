using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;


public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void getPass_Click(object sender, EventArgs e)
    {
        string username = string.Empty;
        string password = string.Empty;
        string constr = ConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString;
        using (SqlConnection sc = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Username, Password FROM [dbo].[Login] WHERE Username = @Username"))
            {
                cmd.Parameters.AddWithValue("@Username", usernameTextbox.Text.Trim());
                cmd.Connection = sc;
                sc.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        HttpUtility.HtmlEncode(username = sdr["Username"].ToString());
                        HttpUtility.HtmlEncode(password = sdr["Password"].ToString());
                    }
                }
                sc.Close();
            }
        }
        if (!string.IsNullOrEmpty(password))
        {
            MailMessage mm = new MailMessage("kkess530@gmail.com", emailTextbox.Text.Trim());
            mm.Subject = "Room Magnet Password Recovery";
            mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", username, password);
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = "kkess530@gmail.com";
            NetworkCred.Password = "B1gSams@2";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Password has been sent to your email address.";
        }
        else
        {
            lblMessage.ForeColor = Color.Red;
            lblMessage.Text = "This username does not match our records.";
        }
    }



}