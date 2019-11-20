using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

public partial class CreateLoginAdmin : System.Web.UI.Page
{

    //Create database connection
    SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    String firstName;
    String lastName;


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void goBack(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }

    protected void submitLogin_Click(object sender, EventArgs e)
    {
        //Username


        //ValidatePassword(username);
        String userNew = userNameTextbox.Text;
        Session["username"] = userNew;


        sc.Open();
        SqlCommand userCheck = new SqlCommand("SELECT Count(*) FROM [dbo].[Login] WHERE lower(Username) = @Username", sc);

        userCheck.Parameters.AddWithValue("@Username", userNew);
        userCheck.Connection = sc;
        int count = Convert.ToInt32(userCheck.ExecuteScalar());
        userCheck.ExecuteNonQuery();
        sc.Close();

        sc.Open();
        //getting the max student id
        int maxAdminID = 0;
        SqlCommand maxAdID = new SqlCommand();
        maxAdID.CommandText = "SELECT MAX(AdminID) FROM [Capstone].[dbo].[Admin];";
        maxAdID.Connection = sc;
        maxAdminID = Convert.ToInt32(maxAdID.ExecuteScalar());
        maxAdID.ExecuteNonQuery();
        maxAdminID++;
        sc.Close();

        //Password 
        System.Data.SqlClient.SqlCommand insertAdmin = new System.Data.SqlClient.SqlCommand();
        insertAdmin.Connection = sc;
        System.Data.SqlClient.SqlCommand insertLogin = new System.Data.SqlClient.SqlCommand();
        insertLogin.Connection = sc;

        firstName = firstNameTextbox.Text;
        lastName = lastNameTextbox.Text;

        String password = passwordTextbox.Text;
        String cpassword = confirmPasswordTextbox.Text;


        Session["password"] = password;

        if (count == 0)
        {
            bool isValid;
            if (password.Length > 8 && (isValid = ValidatePassword(password)))
            {
                if (password == cpassword)
                {
                    Admin newAdmin = new Admin(maxAdminID, firstName, lastName, userNameTextbox.Text, passwordTextbox.Text, confirmPasswordTextbox.Text);
                    resultmessage.Text = "";
                    insertAdmin.CommandText = "INSERT INTO [dbo].[Admin] (AdminID, FirstName, LastName) VALUES (@adminID, @firstName, @lastName)";

                    insertAdmin.Parameters.AddWithValue("@adminID", maxAdminID);
                    insertAdmin.Parameters.AddWithValue("@FirstName", firstName);
                    insertAdmin.Parameters.AddWithValue("@LastName", lastName);;
                    //ADD USERNAME and CONFIRM PASSOWRD IN DATABASE

                    sc.Open();
                    insertAdmin.ExecuteNonQuery();

                    //SqlCommand insert = new SqlCommand("SELECT  MAX(AdminID) FROM [Capstone].[dbo].[Admin] ", sc);
                    //insert.Connection = sc;
                    //int adminID = Convert.ToInt32(insert.ExecuteScalar());
                    //insert.ExecuteNonQuery();
                    //Session["adminID"] = adminID;

                    //if (FileUploadControlHost.HasFile)
                    //{

                    //    HttpPostedFile postedFile = FileUploadControlHost.PostedFile;
                    //    string fileName = Path.GetFileName(postedFile.FileName);
                    //    string fileExtension = Path.GetExtension(fileName);
                    //    int fileSize = postedFile.ContentLength;

                    //    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" ||
                    //        fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
                    //    {
                    //        Stream stream = postedFile.InputStream;
                    //        BinaryReader br = new BinaryReader(stream);
                    //        byte[] bytes = br.ReadBytes((int)stream.Length);

                    //        SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Host] SET imageV2 = @imgdata WHERE HostID = @HostID", sc);
                    //        cmd.Parameters.AddWithValue("@HostID", hostID);
                    //        cmd.Parameters.AddWithValue("@imgdata", bytes);
                    //        cmd.ExecuteNonQuery();

                    //        StatusLabel.Text = "Image Uploaded successfully";
                    //    }
                    //    else
                    //    {
                    //        StatusLabel.Text = "Only Images (.jpg, .png, .gif and .bmp) can be uploaded!";
                    //    }
                    //}
                    //else
                    //{
                    //    StatusLabel.Text = "Please select an image to upload";
                    //}


                    Login tempLogin = new Login(userNameTextbox.Text, passwordTextbox.Text);
                    insertLogin.CommandText = "INSERT INTO [dbo].[Login] (Username, Password, AdminID) VALUES (@userName, @Password, @adminID)";
                    insertLogin.Parameters.AddWithValue("@userName",userNameTextbox.Text);
                    insertLogin.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(passwordTextbox.Text));
                    insertLogin.Parameters.AddWithValue("@adminID", maxAdminID);

                    SqlCommand getadminID = new SqlCommand("SELECT AccountID FROM [dbo].[Login] WHERE AdminID = @adminID", sc);
                    getadminID.Parameters.AddWithValue("@AdminID", maxAdminID);
                    getadminID.Connection = sc;
                    int accountID = Convert.ToInt32(getadminID.ExecuteScalar());
                    getadminID.ExecuteNonQuery();
                    Session["accountID"] = accountID;
                    Session["username"] = newAdmin.userName;

                    insertLogin.ExecuteNonQuery();
                    sc.Close();
                    Response.Redirect("AdminDashboard.aspx");
                }
                else
                {
                    resultmessage.Text = "Passwords does not match.";
                }
            }
            else
            {
                resultmessage.Text = "Password does not meet minimum password requirements.";
            }
        }
        else
        {
            resultmessage.Text = "Username already exists.";
        }

    }

    static bool ValidatePassword(string password)
    {
        const int MIN_LENGTH = 8;

        if (password == null) throw new ArgumentNullException();

        bool meetsLengthRequirements = password.Length >= MIN_LENGTH;
        bool hasUpperCaseLetter = false;
        bool hasLowerCaseLetter = false;
        bool hasDecimalDigit = false;

        if (meetsLengthRequirements)
        {
            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpperCaseLetter = true;
                else if (char.IsLower(c)) hasLowerCaseLetter = true;
                else if (char.IsDigit(c)) hasDecimalDigit = true;
            }
        }

        bool isValid = meetsLengthRequirements
                    && hasUpperCaseLetter
                    && hasLowerCaseLetter
                    && hasDecimalDigit
                    ;
        return isValid;
    }

    protected void populate(object sender, EventArgs e)
    {

    }

    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");

    }

}