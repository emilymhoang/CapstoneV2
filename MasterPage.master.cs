using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        
        HttpCookie userInfo = new HttpCookie("userInfo");
        String username = userInfo["UserName"];
        String password = userInfo["password"];
        Session["defaultPicture"] = null;
        userInfo.Expires.Add(new TimeSpan(0, 1, 0));
        Response.Cookies.Add(userInfo);
        //something about session variables/cookies and username, password
        //https://www.c-sharpcorner.com/uploadfile/annathurai/cookies-in-Asp-Net/


        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                 
                command.CommandText = "select [dbo].[Tenant].imageV2 from [dbo].[Tenant] where [dbo].[Tenant].TenantID = 422";
                
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                byte[] imgData = (byte[])reader["imageV2"];
                                Session["defaultPicture"] = imgData;

                            }

                        }
                        
                    }
                }
                catch (SqlException t)
                {
                    string b = t.ToString();
                }
                
            }
        }




    }

    protected void getStarted(object sender, EventArgs e)
    {
        Response.Redirect("GetStarted.aspx");
    }
    protected void dashboard(object sender, EventArgs e)
    {
        if (Session["LoggedIn"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else if (Session["LoggedIn"].ToString() == "true")
        {
            sc.Open();
            int accountID = Convert.ToInt32(Session["accountID"]);
            Response.Write(accountID);

            SqlCommand login = new SqlCommand("SELECT HostID, TenantID, AdminID FROM [dbo].[Login] WHERE AccountID = @AccountID", sc);
            login.Parameters.AddWithValue("@AccountID", accountID);
            login.Connection = sc;
            SqlDataReader rdr = login.ExecuteReader();
            string tenantID = "", hostID = "", adminID = "";
            while (rdr.Read())
            {
                adminID = rdr["AdminID"].ToString();
                tenantID = rdr["TenantID"].ToString();
                hostID = rdr["HostID"].ToString();
            }
            Session["hostID"] = hostID;
            Session["tenantID"] = tenantID;
            Session["adminID"] = adminID;
            if (tenantID != "")
            {
                Response.Redirect("TenantDashboard.aspx");
            }
            else if (hostID != "")
            {
                Response.Redirect("HostDashboard.aspx");
            }
            else if (adminID != "")
            {
                Response.Redirect("AdminDashboard.aspx");
            }
            sc.Close();
        }
    }
    protected void FAQ(object sender, EventArgs e)
    {
        Response.Redirect("FAQs.aspx");
    }
    protected void AboutUs(object sender, EventArgs e)
    {
        Response.Redirect("AboutUs.aspx");
    }
}
