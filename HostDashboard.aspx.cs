using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostDashboard : System.Web.UI.Page
{
    String privateEntrance;
    String kitchen;
    String privateBathroom;
    String storage;
    String smoker;
    String furnish;
    String roomImg1;
    String roomImg2;
    String roomImg3;

    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        //lvMessages.DataSource = Message.lstMessages;
        //lvMessages.DataBind();

        //lvPropertyRoom.DataSource = PropertyRoom.listPropertyRoom;
        //lvPropertyRoom.DataBind();

        sc.Open();

        int accountID = Convert.ToInt32(Session["accountID"]);
        Response.Write(accountID);

        SqlCommand insert = new SqlCommand("SELECT HostID FROM [Capstone].[dbo].[Login] WHERE AccountID = @AccountID", sc);
        insert.Parameters.AddWithValue("@AccountID", accountID);
        insert.Connection = sc;
        int hostID = Convert.ToInt32(insert.ExecuteScalar());
        insert.ExecuteNonQuery();
        Session["hostID"] = hostID;

        SqlCommand filter = new SqlCommand("SELECT FirstName, LastName, PhoneNumber, Email, BackgroundCheckResult, imageV2, HostBio FROM [Capstone].[dbo].[Host] WHERE HostID = @HostID", sc);
        filter.Parameters.AddWithValue("@HostID", hostID);
        SqlDataReader rdr = filter.ExecuteReader();
        String backgroundCheckResult;
        while (rdr.Read())
        {
            nameTextbox.Text = rdr["FirstName"].ToString() + " " + rdr["LastName"].ToString();
            emailTextbox.Text = rdr["Email"].ToString();
            phoneTextbox.Text = rdr["PhoneNumber"].ToString();
            dashboardTitle.Text = rdr["FirstName"].ToString() + "'s Dashboard";
            hostBioTextbox.Text = rdr["HostBio"].ToString();
            backgroundCheckResult = rdr["BackgroundCheckResult"].ToString();
            if (backgroundCheckResult == "y")
            {
                backgroundCheckResultTitle.Text = "Complete";
                image7.ImageUrl = "images/icons-07.png";
                backgroundCheckResultLbl.Text = "Your Background Check has been completed. Background checks are important to us, we take your safety seriously.";
            }
            else
            {
                backgroundCheckResultTitle.Text = "Incomplete";
                image7.ImageUrl = "images/NC.png";
                backgroundCheckResultLbl.Text = "Our people are working hard to get your background check completed. Background checks are important to us, we take your safety seriously.";
            }


            byte[] ppImgData = (byte[])rdr["imagev2"];
            string ppImage = "data:image;base64," + Convert.ToBase64String(ppImgData, 0, ppImgData.Length);
            image1.ImageUrl = ppImage;
            
            
        }
        usernameTextbox.Text = Session["username"].ToString();

        int hostIDRefresh = Convert.ToInt32(Session["hostID"]);
        Message.lstMessages.Clear();
        //Change badge property info

        int roomID = Convert.ToInt32(Session["RoomID"]);
        SqlCommand badge2 = new SqlCommand("SELECT PrivateEntrance, Kitchen, PrivateBathroom, Furnished, ClosetSpace, NonSmoker FROM [Capstone].[dbo].[BadgeProperty] WHERE RoomID =" + roomID, sc);

        SqlDataReader rdr2 = badge2.ExecuteReader();


        while (rdr2.Read())
        {
            privateEntrance = rdr2["privateEntrance"].ToString();
            kitchen = rdr2["Kitchen"].ToString();
            privateBathroom = rdr2["privateBathroom"].ToString();
            furnish = Session["Furnished"].ToString();
            storage = Session["Storage"].ToString();
            smoker = Session["Smoker"].ToString();
        }

        //if (privateEntrance == "y")
        //{
        //    privateEntranceBadge.ImageUrl = "images/badges-04.png";
        //}

        //if (kitchen == "y")
        //{
        //    kitchenBadge.ImageUrl = "images/badges-06.png";

        //}

        //if (privateBathroom == "y")
        //{
        //    privateBathroomBadge.ImageUrl = "images/badges-07.png";

        //}

        //if (furnish == "y")
        //{
        //    furnishBadge.ImageUrl = "images/badges-08.png";

        //}

        //if (storage == "y")
        //{
        //    storageBadge.ImageUrl = "images/badges-09.png";

        //}

        //if (smoker == "n")
        //{
        //    smokerBadge.ImageUrl = "images/badges-10.png";

        //}



        SqlCommand filterProp = new SqlCommand("SELECT Property.HostID, Property.PropertyID, Property.HouseNumber, PropertyRoom.BriefDescription, " +
            "PropertyRoom.RoomDescription, Property.Street, Property.Zip, Property.CityCounty, Property.HomeState, Property.MonthlyPrice, PropertyRoom.Image1 as PRimage1, PropertyRoom.Image2 as PRimage2, PropertyRoom.Image3 as PRimage3 FROM PropertyRoom" +
            " INNER JOIN Property ON PropertyRoom.PropertyID = Property.PropertyID WHERE Property.HostID = @HostID", sc);
        filterProp.Parameters.AddWithValue("@HostID", hostID);
        SqlDataReader readr = filterProp.ExecuteReader();
        while (readr.Read())
        {
            addressTextbox.Text = readr["HouseNumber"].ToString() + " " + readr["Street"].ToString() + " " + readr["CityCounty"].ToString() + ", " + readr["HomeState"].ToString() + " " + readr["Zip"].ToString();
            //priceTextbox.Text = readr["MonthlyPrice"].ToString();
            //descriptionTextbox.Text = readr["BriefDescription"].ToString();
            //roomDescripTextbox.Text = readr["RoomDescription"].ToString();
            //byte[] imgData = (byte[])readr["PRimage1"];
            //if (!(imgData == null))
            //{
            //    string img = Convert.ToBase64String(imgData, 0, imgData.Length);
            //    image4.ImageUrl = "data:image;base64," + img;
            //}
            //byte[] imgData2 = (byte[])readr["PRimage2"];
            //if (!(imgData2 == null))
            //{
            //    string img = Convert.ToBase64String(imgData2, 0, imgData2.Length);
            //    image5.ImageUrl = "data:image;base64," + img;
            //}
            //byte[] imgData3 = (byte[])readr["PRimage3"];
            //if (!(imgData3 == null))
            //{
            //    string img = Convert.ToBase64String(imgData3, 0, imgData3.Length);
            //    image6.ImageUrl = "data:image;base64," + img;
            //}
        }

        //------------------------------------------------------------------------------------------------------------
        //display property rooms

        PropertyRoom.listPropertyRoom.Clear();

        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                hostID = Convert.ToInt32(Session["hostID"]);
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT PropertyRoom.RoomID, PropertyRoom.PropertyID, Host.HostID, PropertyRoom.MonthlyPrice, isnull(PropertyRoom.BriefDescription, 'No Description') as BriefDescription, isnull(PropertyRoom.RoomDescription, 'No Description') as RoomDescription, PropertyRoom.Availability," +
                "PropertyRoom.SquareFootage, PropertyRoom.Image1, PropertyRoom.Image2, PropertyRoom.Image3 FROM Capstone.[dbo].[Host] inner join Capstone.[dbo].[Property]" +
                "on Property.HostID = Host.HostID left join Capstone.[dbo].[PropertyRoom] ON PropertyRoom.propertyID = Property.PropertyID WHERE Host.HostID = @HostID";

                command.Parameters.AddWithValue("@HostID", hostID);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int propertyID = Convert.ToInt32(reader["PropertyID"]);
                                string description = (string)reader["BriefDescription"];
                                int id = Convert.ToInt32(reader["RoomID"]);
                                string price = Math.Round(Convert.ToDouble(reader["MonthlyPrice"])).ToString();
                                string squareFootage = (string)reader["SquareFootage"];
                                string availability = (string)reader["Availability"];
                                string roomDescription = (string)reader["RoomDescription"];

                                byte[] imgData1;
                                byte[] imgData2;
                                byte[] imgData3;

                                try
                                {
                                    imgData1 = (byte[])reader["Image1"];
                                }
                                catch
                                {
                                    imgData1 = (byte[])Session["defaultPicture"];
                                }

                                try
                                {
                                    imgData2 = (byte[])reader["Image2"];
                                }
                                catch
                                {
                                    imgData2 = (byte[])Session["defaultPicture"];
                                }

                                try
                                {
                                    imgData3 = (byte[])reader["Image3"];
                                }
                                catch
                                {
                                    imgData3 = (byte[])Session["defaultPicture"];
                                }



                                string image1 = "data:image;base64," + Convert.ToBase64String(imgData1, 0, imgData1.Length);
                                string image2 = "data:image;base64," + Convert.ToBase64String(imgData2, 0, imgData2.Length);
                                string image3 = "data:image;base64," + Convert.ToBase64String(imgData3, 0, imgData3.Length);



                               PropertyRoom newRoom = new PropertyRoom(propertyID, price, squareFootage, availability, description, roomDescription, image1, image2, image3);
                               PropertyRoom.listPropertyRoom.Add(newRoom);
                            }
                        }
                    }
                }
                catch (SqlException t)
                {
                    string b = t.ToString();
                }
                finally
                {
                    connection.Close();

                }

            }
        }
        


        //displays all of tenants messages
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                //Change join for host side
                command.CommandText = "select  Message.HostID, Message.TenantID, Message.Message, Message.MessageDate," +
                    " Message.LastUpdated, Message.LastUpdatedBy, Host.FirstName, Host.LastName from Message " +
                    "left join Host on message.HostID = host.HostID where Message.HostID = @Hostid order by Message.MessageID desc";
                command.Parameters.AddWithValue("@hostid", hostIDRefresh);


                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int hostid = Convert.ToInt32(reader["HostID"]);
                                int tenantid = Convert.ToInt32(reader["TenantID"]);
                                string message = (string)reader["Message"];
                                string lub = (string)reader["LastUpdatedBy"];


                                Message msg = new Message(hostid, tenantid, message, lub);

                                msg.setMessageDate(Convert.ToDateTime(reader["MessageDate"]));
                                string recievername = (string)reader["FirstName"] + " " + (string)reader["LastName"];
                                msg.setRecieverName(recievername);


                                Message.lstMessages.Add(msg);
                            }

                        }
                        else
                        {
                            //lblInvalidSearch.Text = "Search returned no properties";
                        }

                    }
                }
                catch (SqlException t)
                {
                    string b = t.ToString();
                }
                finally
                {
                    connection.Close();

                }

            }
        }

        lvMessages.DataSource = Message.lstMessages;
        lvMessages.DataBind();

        lvPropertyRoom.DataSource = PropertyRoom.listPropertyRoom;
        lvPropertyRoom.DataBind();

    }
    protected void sendMessage(object sender, EventArgs e)
    {
        int tenantID = Convert.ToInt32(Session["tenantID"]);
        int hostID = Convert.ToInt32(hostNameDropdown.SelectedItem.Value);
        string msgtxt = messageTextbox.Text;
        string messageSender = Session["username"].ToString();

        Message newMessage = new Message(tenantID, hostID, msgtxt, messageSender);

        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO [dbo].[Message] ([HostID],[TenantID],[Message],[MessageDate]," +
                    "[LastUpdatedBy],[LastUpdated]) VALUES (@host,@tenant,@message,@msgdate,@lub,@lu)";

                command.Parameters.AddWithValue("@host", newMessage.hostID);
                command.Parameters.AddWithValue("@tenant", newMessage.tenantID);
                command.Parameters.AddWithValue("@message", newMessage.message);
                command.Parameters.AddWithValue("@msgdate", newMessage.messageDate);
                command.Parameters.AddWithValue("@lub", newMessage.lastUpdatedBy);
                command.Parameters.AddWithValue("@lu", newMessage.lastUpdated);


                try
                {
                    connection.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException)
                {

                }
                finally
                {
                    connection.Close();
                }
            }
        }


        Message.lstMessages.Clear();

        //displays all of tenants messages
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;


                command.CommandText = "select  Message.HostID, Message.TenantID, Message.Message, Message.MessageDate," +
                    " Message.LastUpdated, Message.LastUpdatedBy, Host.FirstName, Host.LastName from Message " +
                    "left join Host on message.HostID = host.HostID where Message.TenantID = @tenantid order by Message.MessageID desc";
                command.Parameters.AddWithValue("@tenantid", tenantID);


                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int hostid = Convert.ToInt32(reader["HostID"]);
                                int tenantid = Convert.ToInt32(reader["TenantID"]);
                                string message = (string)reader["Message"];
                                string lub = (string)reader["LastUpdatedBy"];


                                Message msg = new Message(hostid, tenantid, message, lub);

                                msg.setMessageDate(Convert.ToDateTime(reader["MessageDate"]));
                                string recievername = (string)reader["FirstName"] + " " + (string)reader["LastName"];
                                msg.setRecieverName(recievername);


                                Message.lstMessages.Add(msg);
                            }

                        }
                        else
                        {
                            //lblInvalidSearch.Text = "Search returned no properties";
                        }

                    }
                }
                catch (SqlException t)
                {
                    string b = t.ToString();
                }
                finally
                {
                    connection.Close();

                }

            }
        }

        lvMessages.DataSource = Message.lstMessages;
        lvMessages.DataBind();
        messageTextbox.Text = string.Empty;

        
    }

    protected void contract(object sender, EventArgs e)
    {
        Response.Redirect("Contract.aspx");
    }

    protected void logout(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Index.aspx");
    }
}