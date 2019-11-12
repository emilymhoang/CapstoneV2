using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddRoom : System.Web.UI.Page
{
    int PropertyID;

    double MonthlyPrice;
    int SquareFootage;
    int NumberBedrooms;
    string privateBath;
    string privateEnt;
    string storage;
    string furnish;
    string smoker;
    string kitchen;

    SqlConnection sc = new SqlConnection(ConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submitPropRoom(object sender, EventArgs e)
    {
        Session["privateBathroom"] = rbPrivateBr.SelectedValue;
        Session["privateEntrance"] = rbPrivateEntr.SelectedValue;
        Session["Storage"] = rbStorage.SelectedValue;
        Session["Furnished"] = rbFurnished.SelectedValue;
        Session["Smoker"] = rbSmoke.SelectedValue;
        Session["Kitchen"] = rbKitchen.SelectedValue;

        privateBath = Session["privateBathroom"].ToString();
        privateEnt = Session["privateEntrance"].ToString();
        storage = Session["Storage"].ToString();
        furnish = Session["Furnished"].ToString();
        smoker = Session["Smoker"].ToString();
        kitchen = Session["Kitchen"].ToString();


        sc.Open();
        SqlCommand insert = new SqlCommand("SELECT PropertyID FROM [Capstone].[dbo].[Property] WHERE HostID = @HostID", sc);
        insert.Parameters.AddWithValue("@HostID", Convert.ToInt32(Session["hostID"]));
        insert.Connection = sc;
        int propertyID = Convert.ToInt32(insert.ExecuteScalar());
        insert.ExecuteNonQuery();

        SqlCommand getAccountID = new SqlCommand("SELECT AccountID FROM [Capstone].[dbo].[Login] WHERE HostID = @HostID", sc);
        getAccountID.Parameters.AddWithValue("@HostID", Convert.ToInt32(Session["hostID"]));
        getAccountID.Connection = sc;
        int accountID = Convert.ToInt32(getAccountID.ExecuteScalar());
        getAccountID.ExecuteNonQuery();
        Session["accountID"] = accountID;
        sc.Close();

        double monthlyPrice = Convert.ToDouble(monthlyPriceTextbox.Text);
        //int sqFoot = Convert.ToInt32(squareFootageTextbox.Text);
        String sqFoot = DropDownListSize.SelectedValue;
        String avail = DropDownListAvailibility.SelectedValue;
        String display = displayTextbox.Text;
        String roomDescription = DropDownListRoom.SelectedValue;

        //roomID
        int roomID;
        Session["RoomID"] = null;


        PropertyRoom newRoom = new PropertyRoom(propertyID, monthlyPrice, sqFoot, avail, display, roomDescription);
        System.Data.SqlClient.SqlCommand insertBadgeProperty = new System.Data.SqlClient.SqlCommand();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO [dbo].[PropertyRoom] ([PropertyID],[TenantID],[MonthlyPrice],[SquareFootage],[Availability],[BriefDescription],[RoomDescription],[LastUpdatedBy],[LastUpdated]) VALUES (@propid,@tenantid,@price,@sqft,@avail,@desc,@roomdescrip,@lub,@lu)";

                command.Parameters.AddWithValue("@propid", newRoom.propertyID);
                command.Parameters.AddWithValue("@tenantid", newRoom.tenantID);
                command.Parameters.AddWithValue("@price", newRoom.monthlyPrice);
                command.Parameters.AddWithValue("@sqft", newRoom.squareFootage);
                command.Parameters.AddWithValue("@avail", newRoom.availability);
                command.Parameters.AddWithValue("@desc", newRoom.briefDescription);
                command.Parameters.AddWithValue("@roomdescrip", newRoom.roomDescription);
                command.Parameters.AddWithValue("@lub", "Kessler");
                command.Parameters.AddWithValue("@lu", DateTime.Now);





                try
                {
                    connection.Open();
                    int recordsAffected = command.ExecuteNonQuery();

                    SqlCommand room = new SqlCommand("SELECT MAX(RoomID) FROM [Capstone].[dbo].[PropertyRoom]", connection);
                    room.Connection = connection;
                    roomID = Convert.ToInt32(room.ExecuteScalar());
                    Session["RoomID"] = roomID;
                    room.ExecuteNonQuery();


                    BadgeProperty newBadgeProperty = new BadgeProperty(roomID, privateEnt, kitchen, privateBath, furnish, storage, smoker);

                    insertBadgeProperty.CommandText = "INSERT INTO [Capstone].[dbo].[BadgeProperty] (RoomID, PrivateEntrance, Kitchen, PrivateBathroom, Furnished, ClosetSpace, NonSmoker) VALUES (@roomID, @privateEnt, @kitchen, @privateBath, @furnish, @storage, @smoker);";
                    insertBadgeProperty.Parameters.AddWithValue("@roomID", newBadgeProperty.RoomID);
                    insertBadgeProperty.Parameters.AddWithValue("@privateEnt", newBadgeProperty.privateEntrance);
                    insertBadgeProperty.Parameters.AddWithValue("@kitchen", newBadgeProperty.kitchen);
                    insertBadgeProperty.Parameters.AddWithValue("@privateBath", newBadgeProperty.privateBathroom);
                    insertBadgeProperty.Parameters.AddWithValue("@furnish", newBadgeProperty.furnished);
                    insertBadgeProperty.Parameters.AddWithValue("@storage", newBadgeProperty.closetSpace);
                    insertBadgeProperty.Parameters.AddWithValue("@smoker", newBadgeProperty.nonSmoker);
                    insertBadgeProperty.Connection = connection;
                    insertBadgeProperty.ExecuteNonQuery();
                }
                catch (Exception t)
                {
                    string f = t.ToString();
                }
                finally
                {
                    connection.Close();

                }
            }
        }




        if (FileUploadControl.HasFile)
        {

            HttpPostedFile postedFile = FileUploadControl.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" ||
                fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
            {
                sc.Open();
                Stream stream = postedFile.InputStream;
                BinaryReader br = new BinaryReader(stream);
                byte[] bytes = br.ReadBytes((int)stream.Length);

                SqlCommand cmd = new SqlCommand("UPDATE[Capstone].[dbo].[PropertyRoom] SET Image1 = @imgdata WHERE RoomID = @RoomID", sc);
                cmd.Parameters.AddWithValue("@RoomID", Session["RoomID"]);
                cmd.Parameters.AddWithValue("@imgdata", bytes);
                cmd.ExecuteNonQuery();
                sc.Close();
                StatusLabel.Text = "Image Uploaded successfully";

            }
            else
            {
                StatusLabel.Text = "Only Images (.jpg, .png, .gif and .bmp) can be uploaded!";
                return;
            }
        }
        else
        {
            StatusLabel.Text = "Please select an image to upload";
            return;

        }

        if (FileUpload2.HasFile)
        {

            HttpPostedFile postedFile = FileUpload2.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" ||
                fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
            {
                sc.Open();
                Stream stream = postedFile.InputStream;
                BinaryReader br = new BinaryReader(stream);
                byte[] bytes = br.ReadBytes((int)stream.Length);

                SqlCommand cmd = new SqlCommand("UPDATE[Capstone].[dbo].[PropertyRoom] SET Image2 = @imgdata WHERE RoomID = @RoomID", sc);
                cmd.Parameters.AddWithValue("@RoomID", Session["RoomID"]);
                cmd.Parameters.AddWithValue("@imgdata", bytes);
                cmd.ExecuteNonQuery();
                sc.Close();
                StatusLabel.Text = "Image Uploaded successfully";

            }
            else
            {
                StatusLabel.Text = "Only Images (.jpg, .png, .gif and .bmp) can be uploaded!";
                return;
            }
        }

        if (FileUpload3.HasFile)
        {

            HttpPostedFile postedFile = FileUpload3.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" ||
                fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
            {
                sc.Open();
                Stream stream = postedFile.InputStream;
                BinaryReader br = new BinaryReader(stream);
                byte[] bytes = br.ReadBytes((int)stream.Length);

                SqlCommand cmd = new SqlCommand("UPDATE[Capstone].[dbo].[PropertyRoom] SET Image3 = @imgdata WHERE RoomID = @RoomID", sc);
                cmd.Parameters.AddWithValue("@RoomID", Session["RoomID"]);
                cmd.Parameters.AddWithValue("@imgdata", bytes);
                cmd.ExecuteNonQuery();
                sc.Close();
                StatusLabel.Text = "Image Uploaded successfully";

            }
            else
            {
                StatusLabel.Text = "Only Images (.jpg, .png, .gif and .bmp) can be uploaded!";
                return;
            }
        }



        Response.Redirect("HostDashboard.aspx");
    }

    protected void populate(object sender, EventArgs e)
    {
        monthlyPriceTextbox.Text = "800.00";
        DropDownListSize.Text = "500";
        displayTextbox.Text = "Basement bedroom near City with a balcony";
        rbFurnished.SelectedValue = "y";
        rbKitchen.SelectedValue = "y";
        rbPrivateBr.SelectedValue = "y";
        rbPrivateEntr.SelectedValue = "y";
        rbSmoke.SelectedValue = "n";
        rbStorage.SelectedValue = "y";

    }


}