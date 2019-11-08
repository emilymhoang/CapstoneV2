using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GetStarted : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RentMyRoom(object sender, EventArgs e)
    {
        Response.Redirect("BasicInfoHomeowner.aspx");
    }

    protected void FindMyRoom(object sender, EventArgs e)
    {
        Response.Redirect("BasicInfoTenant.aspx");
    }

}