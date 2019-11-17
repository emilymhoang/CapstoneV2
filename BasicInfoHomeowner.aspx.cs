using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
public partial class BasicInfoHomeowner : System.Web.UI.Page
{
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void submitBasicInfo(object sender, EventArgs e)
    {
        String emailNew = emailTextbox.Text;
        Session["Email"] = emailNew;


        sc.Open();
        SqlCommand emailCheck = new SqlCommand("SELECT Count(*) FROM [Capstone].[dbo].[Host] WHERE lower(email) = @Email", sc);
        emailCheck.Parameters.AddWithValue("@Email", emailNew);
        emailCheck.Connection = sc;
        int count = Convert.ToInt32(emailCheck.ExecuteScalar());
        emailCheck.ExecuteNonQuery();
        sc.Close();

        if (count == 0)
        {
            if (emailTextbox.Text == confirmEmailTextbox.Text)
            {
                Session["firstName"] = firstNameTextbox.Text;
                Session["lastName"] = lastNameTextbox.Text;
                Session["gender"] = DropDownListGender.SelectedValue;
                Session["dateOfBirth"] = dateOfBirthTextbox.Text;
                Session["email"] = emailTextbox.Text;
                Session["phoneNumberTextbox"] = phoneNumberTextbox.Text;

                Response.Redirect("CreateLoginHomeowner.aspx");
            }
            else
            {
                resultmessage.Text = "Emails do not match.";
            }
        }
        else
        {
            emailLabel.Text = "Email already exists.";
        }

    }

    protected void populate(object sender, EventArgs e)
    {
        firstNameTextbox.Text = "Carey";
        lastNameTextbox.Text = "Cole";
        DropDownListGender.SelectedValue = "M";
        dateOfBirthTextbox.Text = "10-25-1970";
        emailTextbox.Text = "colecb@jmu.edu";
        confirmEmailTextbox.Text = "colecb@jmu.edu";
        phoneNumberTextbox.Text = "571-555-5555";
        HostBioTextbox.Text = "I am college professor who lives with my wife. I have an empty furnished basement that I am looking to fill and am hoping to find someone who will help with chores around my house since I am very busy.";
    
    }

}