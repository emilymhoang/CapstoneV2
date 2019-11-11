using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BasicInfoTenant : System.Web.UI.Page
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
        SqlCommand emailCheck = new SqlCommand("SELECT Count(*) FROM [Capstone].[dbo].[Tenant] WHERE lower(email) = @Email", sc);
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
                Session["underGraduate"] = undergradCheck.Checked;
                Session["graduate"] = gradCheck.Checked;
                Response.Redirect("CreateLoginTenant.aspx");
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
        firstNameTextbox.Text = "Emily";
        lastNameTextbox.Text = "Hoang";
        DropDownListGender.SelectedValue = "F";
        dateOfBirthTextbox.Text = "12-02-1997";
        emailTextbox.Text = "hoangex@dukes.jmu.edu";
        confirmEmailTextbox.Text = "hoangex@dukes.jmu.edu";
        phoneNumberTextbox.Text = "703-342-7285";

    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        //Insert image
    }


    }