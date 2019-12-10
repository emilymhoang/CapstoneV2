﻿using System;
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
        if (IsPostBack==false)
        {
            dateOfBirthRequiredFieldValidator.Enabled = false;
        }
        else
        {
            dateOfBirthRequiredFieldValidator.Enabled = true;
        }
    }

    
    protected void submitBasicInfo(object sender, EventArgs e) 
    {

        // converting Time 
        var today = DateTime.Today;

        var birthdate = Convert.ToDateTime(dateOfBirthTextbox.Text);
        var age = today.Year - birthdate.Year;
        if (birthdate.Date > today.AddYears(-age)) age--;

        //age Validation 
        if (age < 18)
        {
            resultmessagedob.Text = "All users must be atleast 18 years old";
            return;
        }

        //makes sure email does not already exist in the database
        String emailNew = emailTextbox.Text;
        Session["Email"] = emailNew;
        sc.Open();
        SqlCommand emailCheck = new SqlCommand("SELECT Count(*) FROM [dbo].[Tenant] WHERE lower(email) = @Email", sc);
        emailCheck.Parameters.AddWithValue("@Email", emailNew);
        emailCheck.Connection = sc;
        int count = Convert.ToInt32(emailCheck.ExecuteScalar());
        emailCheck.ExecuteNonQuery();
        sc.Close();

        if (count == 0)
        {
            if (emailTextbox.Text == confirmEmailTextbox.Text)
            {
                if(DropDownListGender.SelectedValue != "-1") { 


                        Session["firstName"] = firstNameTextbox.Text;
                        Session["lastName"] = lastNameTextbox.Text;
                        Session["gender"] = DropDownListGender.SelectedValue;
                        Session["dateOfBirth"] = dateOfBirthTextbox.Text;
                        Session["email"] = emailTextbox.Text;
                        Session["phoneNumberTextbox"] = phoneNumberTextbox.Text;
                        Session["underGraduate"] = undergradCheck.Checked;
                        Session["graduate"] = gradCheck.Checked;
                        Session["chores"] = choresCheck.Checked;
                        Session["tenantBio"] = TenantBioTextbox.Text;
                        Response.Redirect("CreateLoginTenant.aspx");
                        
                }
                else
                {
                    resultmessagegender.Text = "Must select a valid gender";
                }
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

    //populate button
    protected void populate(object sender, EventArgs e)
    {
        firstNameTextbox.Text = "Emily";
        lastNameTextbox.Text = "Hoang";
        DropDownListGender.SelectedValue = "F";
        dateOfBirthTextbox.Text = "12-02-1997";
        emailTextbox.Text = "hoangex@dukes.jmu.edu";
        confirmEmailTextbox.Text = "hoangex@dukes.jmu.edu";
        phoneNumberTextbox.Text = "703-342-7285";
        TenantBioTextbox.Text = "I am a Junior Nursing student at James Madison University. I am looking to rent a room where I can exchange my skills obtained from nursing for a discounted price.";

    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        
    }

    //makes sure both undergrad and grad cannot both be checked
    protected void undergradCheck_checkChanged(object sender, EventArgs e)
    {
        if (undergradCheck.Checked == true)
        {
        gradCheck.Checked = !undergradCheck.Checked;
        NAcheck.Checked = !undergradCheck.Checked;
        }

    }

    //makes sure both undergrad and grad cannot both be checked
    protected void gradCheck_checkChanged(object sender, EventArgs e)
    {
        if (gradCheck.Checked == true)
        {
        undergradCheck.Checked = !gradCheck.Checked;
        NAcheck.Checked = !gradCheck.Checked;

        }

    }

    //makes sure undergrad and grad are not checked if NA is checked
    protected void NAcheck_checkChanged(object sender, EventArgs e)
    {
        if (NAcheck.Checked == true)
        {
        undergradCheck.Checked = !NAcheck.Checked;
        gradCheck.Checked = !NAcheck.Checked;
        }

    }



}