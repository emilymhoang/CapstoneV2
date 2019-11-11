using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{

    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    // Isaac was here
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void getStarted(object sender, EventArgs e)
    {
        Response.Redirect("GetStarted.aspx");
    }
    protected void myAccount(object sender, EventArgs e)
    {

        if (Session["LoggedIn"].ToString() == "true")
        {

            sc.Open();
            int accountID = Convert.ToInt32(Session["accountID"]);
            Response.Write(accountID);

            SqlCommand login = new SqlCommand("SELECT HostID, TenantID, AdminID FROM [Capstone].[dbo].[Login] WHERE AccountID = @AccountID", sc);
            login.Parameters.AddWithValue("@AccountID", accountID);
            login.Connection = sc;
            //login.ExecuteNonQuery();
            SqlDataReader rdr = login.ExecuteReader();
            string tenantID = "", hostID = "", adminID = "";
            while (rdr.Read())
            {
                adminID = rdr["AdminID"].ToString();
                Session["adminID"] = adminID;
                hostID = rdr["HostID"].ToString();
                Session["hostID"] = hostID;
                tenantID = rdr["TenantID"].ToString();
                Session["tenantID"] = tenantID;
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
        else
        {
            Response.Redirect("Login.aspx");
        }

        
    }
    protected void translate(object sender, EventArgs e)
    {
        Response.Redirect("BasicInfoTenant.aspx");
    }
}