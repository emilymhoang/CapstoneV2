using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TenantProfile : System.Web.UI.Page
{
    String underGraduate;
    String graduate;
    String chores;
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        sc.Open();
        SqlCommand filter = new SqlCommand("SELECT FirstName, LastName, PhoneNumber, Email, BackgroundCheckResult, imageV2, TenantBio FROM [dbo].[Tenant] WHERE TenantID = @TenantID", sc);
        filter.Parameters.AddWithValue("@TenantID", Convert.ToInt32(Session["MessageTenantID"]));
        SqlDataReader rdr = filter.ExecuteReader();
        String backgroundCheckResult;
        while (rdr.Read())
        {
            lblTenantName.Text = HttpUtility.HtmlEncode(rdr["FirstName"].ToString()) + " " + HttpUtility.HtmlEncode(rdr["LastName"].ToString());
            backgroundCheckResult = HttpUtility.HtmlEncode(rdr["BackgroundCheckResult"].ToString());
            lblTenantBio.Text = HttpUtility.HtmlEncode(rdr["TenantBio"].ToString());
            PropertyHeaderTextbox.Text = HttpUtility.HtmlEncode(rdr["FirstName"].ToString()) + " " + HttpUtility.HtmlEncode(rdr["LastName"].ToString()) + "'s Profile";
            if (backgroundCheckResult == "y")
            {
                imgbackgroundCheck.ImageUrl = "images/icons-07.png";
            }
            if (backgroundCheckResult == "r")
            {
                imgbackgroundCheck.ImageUrl = "images/icons-08.png";

            }
            else
            {
                imgbackgroundCheck.ImageUrl = "images/NC.png";
            }
            byte[] imgData = (byte[])rdr["imageV2"];
            if (!(imgData == null))
            {
                string img = Convert.ToBase64String(imgData, 0, imgData.Length);
                tenantProfPic.ImageUrl = "data:image;base64," + img;
            }
        }

                int tenantID = Convert.ToInt32(Session["MessageTenantID"]);
                SqlCommand badge = new SqlCommand("SELECT Undergraduate, graduate, Chores FROM [dbo].[BadgeTenant] WHERE TenantID = @TenantID", sc);
                badge.Parameters.AddWithValue("@TenantID", tenantID);

                SqlDataReader rdr2 = badge.ExecuteReader();


                while (rdr2.Read())
                {
                    underGraduate = HttpUtility.HtmlEncode(rdr2["Undergraduate"].ToString());
                    graduate = HttpUtility.HtmlEncode(rdr2["graduate"].ToString());
                    chores = HttpUtility.HtmlEncode(rdr2["chores"].ToString());
                }

                if (underGraduate == "True")
                {
                    undergraduateBadge.ImageUrl = "images/badges-01.png";
                }

                if (graduate == "True")
                {
                    graduateBadge.ImageUrl = "images/badges-02.png";

                }

                if (chores == "True")
                {
                    choresBadge.ImageUrl = "images/badges-21.png";
                }
        sc.Close();

            }

    protected void goBack(object sender, EventArgs e)
    {
    Response.Redirect("Index.aspx");
    }
}