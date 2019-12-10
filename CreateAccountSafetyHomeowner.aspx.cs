using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateAccountSafetyHomeowner : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //redirects homeowner to the dashboard if they accept saftey terms
    protected void Understand(object sender, EventArgs e)
    {
        Response.Redirect("HostDashboard.aspx");
    }

}