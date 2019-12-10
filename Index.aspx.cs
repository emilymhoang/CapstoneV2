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
            Response.Redirect("TenantDashboard.aspx");
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