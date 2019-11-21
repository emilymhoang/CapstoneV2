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



        //AGE VALIDATION
        //var today = DateTime.Today;
        //var birthdate = Convert.ToDateTime(dateOfBirthTextbox.Text);
        //var age = today.Year - birthdate.Year;

        //age = new DateTime(DateTime.Now.Subtract(birthdate).Ticks).Year - 1;
        //DateTime lastYear = birthdate.AddYears(age);
        //int month = 0;
        //for (int z = 1; z <= 12; z++)
        //{
        //    if (lastYear.AddMonths(z) == today)
        //    {
        //        month = z;
        //        break;
        //    }
        //    else if (lastYear.AddMonths(z) >= today)
        //    {
        //        month = z - 1;
        //        break;
        //    }
        //}

        //int days = today.Subtract(lastYear.AddMonths(month)).Days;
        //int hours = today.Subtract(lastYear).Hours;

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
                //if (age > 18 || age < 100)
                //    {
                        Session["firstName"] = firstNameTextbox.Text;
                        Session["lastName"] = lastNameTextbox.Text;
                        Session["gender"] = DropDownListGender.SelectedValue;
                        Session["dateOfBirth"] = dateOfBirthTextbox.Text;
                        Session["email"] = emailTextbox.Text;
                        Session["phoneNumberTextbox"] = phoneNumberTextbox.Text;
                        Session["underGraduate"] = undergradCheck.Checked;
                        Session["graduate"] = gradCheck.Checked;
                        Response.Redirect("CreateLoginTenant.aspx");
                        //resultmessagedob.Text = "Student must be between 18 - 30 years old, age is " + age;
                        
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