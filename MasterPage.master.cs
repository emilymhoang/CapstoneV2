using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie userInfo = new HttpCookie("userInfo");
        String username = userInfo["UserName"];
        String password = userInfo["password"];
        userInfo.Expires.Add(new TimeSpan(0, 1, 0));
        Response.Cookies.Add(userInfo);
        //something about session variables/cookies and username, password
        //https://www.c-sharpcorner.com/uploadfile/annathurai/cookies-in-Asp-Net/
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
        else
        {
            Response.Redirect("TenantDashboard.aspx");
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
