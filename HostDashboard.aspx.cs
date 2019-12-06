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
    // protected global::System.Web.UI.WebControls.DropDownList drpTenantName;


    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

        string strPreviousPage = "";
        if (Request.UrlReferrer != null)
        {
            strPreviousPage = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
        }
        if (strPreviousPage == "")
        {
            Session["LoggedIn"] = "false";
            Response.Redirect("Login.aspx");
        }

        //lvMessages.DataSource = Message.lstMessages;
        //lvMessages.DataBind();

        //lvPropertyRoom.DataSource = PropertyRoom.listPropertyRoom;
        //lvPropertyRoom.DataBind();

        sc.Open();

        int accountID = Convert.ToInt32(Session["accountID"]);

        SqlCommand insert = new SqlCommand("SELECT HostID FROM [dbo].[Login] WHERE AccountID = @AccountID", sc);
        insert.Parameters.AddWithValue("@AccountID", accountID);
        insert.Connection = sc;
        int hostID = Convert.ToInt32(insert.ExecuteScalar());
        insert.ExecuteNonQuery();
        Session["hostID"] = hostID;

        SqlCommand filter = new SqlCommand("SELECT FirstName, LastName, PhoneNumber, Email, BackgroundCheckResult, imageV2, HostBio FROM [dbo].[Host] WHERE HostID = @HostID", sc);
        filter.Parameters.AddWithValue("@HostID", hostID);
        SqlDataReader rdr = filter.ExecuteReader();
        String backgroundCheckResult;
        while (rdr.Read())
        {
            nameTextbox.Text = HttpUtility.HtmlEncode(rdr["FirstName"].ToString()) + " " + HttpUtility.HtmlEncode(rdr["LastName"].ToString());
            emailTextbox.Text = HttpUtility.HtmlEncode(rdr["Email"].ToString());
            phoneTextbox.Text = HttpUtility.HtmlEncode(rdr["PhoneNumber"].ToString());
            dashboardTitle.Text = HttpUtility.HtmlEncode(rdr["FirstName"].ToString()) + "'s Dashboard";
            hostBioTextbox.Text = HttpUtility.HtmlEncode(rdr["HostBio"].ToString());
            backgroundCheckResult = HttpUtility.HtmlEncode(rdr["BackgroundCheckResult"].ToString());
            if (backgroundCheckResult == "y")
            {
                backgroundCheckResultTitle.Text = "Complete";
                image7.ImageUrl = "images/icons-07.png";
                backgroundCheckResultLbl.Text = "Your Background Check has been completed. Background checks are important to us, we take your safety seriously. To find out more about the background check process, click the button below.";
            }
            if (backgroundCheckResult == "r")
            {
                backgroundCheckResultTitle.Text = "Denied";
                image7.ImageUrl = "images/icons-08.png";
                backgroundCheckResultLbl.Text = "Your Background Check has been denied. Background checks are important to us. We take our users safety seriously. To find out more about the background check process, click the button below.";

            }
            else
            {
                backgroundCheckResultTitle.Text = "Incomplete";
                image7.ImageUrl = "images/NC.png";
                backgroundCheckResultLbl.Text = "Our people are working hard to get your background check completed. Background checks are important to us, we take your safety seriously. To find out more about the background check process, click the button below.";
            }


            byte[] ppImgData = (byte[])rdr["imagev2"];
            string ppImage = "data:image;base64," + Convert.ToBase64String(ppImgData, 0, ppImgData.Length);
            image1.ImageUrl = ppImage;


        }
        usernameTextbox.Text = Session["username"].ToString();

        int hostIDRefresh = Convert.ToInt32(Session["hostID"]);
        Message.lstHostMessages.Clear();
        //Change badge property info

        int roomID = Convert.ToInt32(Session["RoomID"]);
        SqlCommand badge2 = new SqlCommand("SELECT PrivateEntrance, Kitchen, PrivateBathroom, Furnished, ClosetSpace, NonSmoker FROM [dbo].[BadgeProperty] WHERE RoomID =" + roomID, sc);

        SqlDataReader rdr2 = badge2.ExecuteReader();


        while (rdr2.Read())
        {
            privateEntrance = HttpUtility.HtmlEncode(rdr2["privateEntrance"].ToString());
            kitchen = HttpUtility.HtmlEncode(rdr2["Kitchen"].ToString());
            privateBathroom = HttpUtility.HtmlEncode(rdr2["privateBathroom"].ToString());
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
            addressTextbox.Text = HttpUtility.HtmlEncode(readr["HouseNumber"].ToString()) + " " + HttpUtility.HtmlEncode(readr["Street"].ToString()) + " " + HttpUtility.HtmlEncode(readr["CityCounty"].ToString()) + ", " + HttpUtility.HtmlEncode(readr["HomeState"].ToString()) + " " + HttpUtility.HtmlEncode(readr["Zip"].ToString());
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
                "PropertyRoom.SquareFootage, PropertyRoom.Image1, PropertyRoom.Image2, PropertyRoom.Image3 FROM [dbo].[Host] inner join [dbo].[Property]" +
                "on Property.HostID = Host.HostID left join [dbo].[PropertyRoom] ON PropertyRoom.propertyID = Property.PropertyID WHERE Host.HostID = @HostID";

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
                                int propertyID = Convert.ToInt32(HttpUtility.HtmlEncode(reader["PropertyID"]));
                                string description = HttpUtility.HtmlEncode((string)reader["BriefDescription"]);
                                int id = Convert.ToInt32(HttpUtility.HtmlEncode(reader["RoomID"]));
                                string price = HttpUtility.HtmlEncode(Math.Round(Convert.ToDouble(reader["MonthlyPrice"])).ToString());
                                string squareFootage = HttpUtility.HtmlEncode((string)reader["SquareFootage"]);
                                string availability = HttpUtility.HtmlEncode((string)reader["Availability"]);
                                string roomDescription = HttpUtility.HtmlEncode((string)reader["RoomDescription"]);

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



        //displays all of host messages
        string messageSender = Session["username"].ToString();

        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;


                command.CommandText = "select Host.FirstName HostFirst, Host.LastName HostLast, [dbo].[Message].[HostID], " +
                    "[dbo].[Message].[TenantID], [dbo].[Message].[Message], [dbo].[Message].[MessageDate], [dbo].[Message].[LastUpdatedBy], " +
                    "[dbo].[Message].[LastUpdated], [dbo].[Tenant].FirstName TenantFirst, [dbo].[Tenant].LastName TenantLast " +
                    "from [dbo].[Host] left join [dbo].[Message] on [dbo].[Host].HostID = [dbo].[Message].HostID " +
                    "left join [dbo].[Tenant] on [dbo].[Message].TenantID = [dbo].[Tenant].TenantID " +
                    "where Message.HostID = @hostid order by Message.MessageID desc";
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
                                int hostid = Convert.ToInt32(HttpUtility.HtmlEncode(reader["HostID"]));
                                int tenantid = Convert.ToInt32(HttpUtility.HtmlEncode(reader["TenantID"]));
                                string message = HttpUtility.HtmlEncode((string)reader["Message"]);
                                string lub = HttpUtility.HtmlEncode((string)reader["LastUpdatedBy"]);
                                string tenantName = HttpUtility.HtmlEncode((string)reader["TenantFirst"]) + " " + HttpUtility.HtmlEncode((string)reader["TenantLast"]);


                                Message msg = new Message(tenantid, hostid, message, lub);

                                msg.setMessageDate(Convert.ToDateTime(HttpUtility.HtmlEncode(reader["MessageDate"])));
                                string recieverName = string.Empty;

                                if (messageSender.Equals(lub))
                                {
                                    recieverName = "To: " + HttpUtility.HtmlEncode((string)reader["TenantFirst"]) + " " + HttpUtility.HtmlEncode((string)reader["TenantLast"]) + "\tFrom: Me";
                                }
                                else
                                {
                                    recieverName = "To: Me\tFrom: " + HttpUtility.HtmlEncode((string)reader["TenantFirst"]) + " " + HttpUtility.HtmlEncode((string)reader["TenantLast"]);
                                }

                                msg.setRecieverName(recieverName);
                                msg.setTenantName(tenantName);

                                Message.lstHostMessages.Add(msg);
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


        //populates dropdown for messages
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;


                command.CommandText = "select distinct [dbo].[Tenant].FirstName, [dbo].[Tenant].LastName, [dbo].[Message].TenantID " +
                    "from [dbo].[Message] left join [dbo].[Tenant] on [dbo].[Message].TenantID = [dbo].[Tenant].TenantID " +
                    "where [dbo].[Message].HostID = @hostid";

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
                                ListItem item = new ListItem();
                                var val = Convert.ToInt32(HttpUtility.HtmlEncode(reader["TenantID"]));
                                item.Text = HttpUtility.HtmlEncode((string)reader["FirstName"]) + HttpUtility.HtmlEncode((string)reader["Lastname"]);
                                item.Value = val.ToString();
                                tenantNameDropdown.Items.Add(item);
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

        //message dropdown selection
        //foreach (ListItem item in tenantNameDropdown.Items)
        //{
        //    ListItem item2 = new ListItem();
        //    item2.Text = item.Text;
        //    item2.Value = item.Value;
        //    list.Items.Add(item2);
        //}

        lvMessagesHost.DataSource = Message.lstHostMessages;
        lvMessagesHost.DataBind();

        lvPropertyRoom.DataSource = PropertyRoom.listPropertyRoom;
        lvPropertyRoom.DataBind();

    }
    protected void sendMessage(object sender, EventArgs e)
    {
        resultmessageMessage.Text = "";
        if (messageTextbox.Text.Trim() != "")
        {
            int hostID = Convert.ToInt32(Session["hostID"]);
        int tenantID = Convert.ToInt32(tenantNameDropdown.SelectedItem.Value);
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


        Message.lstHostMessages.Clear();

        //displays all of tenants messages
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;


                command.CommandText = "select Host.FirstName HostFirst, Host.LastName HostLast, [dbo].[Message].[HostID], " +
                    "[dbo].[Message].[TenantID], [dbo].[Message].[Message], [dbo].[Message].[MessageDate], [dbo].[Message].[LastUpdatedBy], " +
                    "[dbo].[Message].[LastUpdated], [dbo].[Tenant].FirstName TenantFirst, [dbo].[Tenant].LastName TenantLast " +
                    "from [dbo].[Host] left join [dbo].[Message] on [dbo].[Host].HostID = [dbo].[Message].HostID " +
                    "left join [dbo].[Tenant] on [dbo].[Message].TenantID = [dbo].[Tenant].TenantID " +
                    "where Message.HostID = @hostid order by Message.MessageID desc";
                command.Parameters.AddWithValue("@hostid", hostID);


                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int hostid = Convert.ToInt32(HttpUtility.HtmlEncode(reader["HostID"]));
                                int tenantid = Convert.ToInt32(HttpUtility.HtmlEncode(reader["TenantID"]));
                                string message = HttpUtility.HtmlEncode((string)reader["Message"]);
                                string lub = HttpUtility.HtmlEncode((string)reader["LastUpdatedBy"]);
                                string tenantName = HttpUtility.HtmlEncode((string)reader["TenantFirst"]) + " " + HttpUtility.HtmlEncode((string)reader["TenantLast"]);

                                Message msg = new Message(tenantid, hostid, message, lub);

                                msg.setMessageDate(Convert.ToDateTime(reader["MessageDate"]));
                                string recieverName = string.Empty;

                                if (messageSender.Equals(lub))
                                {
                                    recieverName = "To: " + HttpUtility.HtmlEncode((string)reader["TenantFirst"]) + " " + HttpUtility.HtmlEncode((string)reader["TenantLast"]) + "\tFrom: Me";
                                }
                                else
                                {
                                    recieverName = "To: Me\tFrom: " + HttpUtility.HtmlEncode((string)reader["TenantFirst"]) + " " + HttpUtility.HtmlEncode((string)reader["TenantLast"]);
                                }

                                msg.setRecieverName(recieverName);
                                msg.setTenantName(tenantName);

                                Message.lstHostMessages.Add(msg);
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

        lvMessagesHost.DataSource = Message.lstHostMessages;
        lvMessagesHost.DataBind();
        messageTextbox.Text = string.Empty;
    }

else
        {
            Response.Write("<script> alert('Message is empty. Please try again.'); </script>");
            //resultmessageMessage.Text = "Message is empty.";
        }


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

    protected void hideProperties(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    connection.Open();
                    Button btn = sender as Button;
                    ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
                    var index = item.DataItemIndex;
                    var tenantID = drpTenantName.SelectedItem.Value;
                    //DropDownList list = (DropDownList)Page.FindControl("drpTenantName");
                    //var selectedPRid = PropertyRoom.listPropertyRoom[index].roomID;

                    SqlCommand filter = new SqlCommand("SELECT Host.FirstName, Host.LastName, Property.PropertyID FROM [dbo].[Host] LEFT JOIN [dbo].[Property] ON Host.HostID = Property.HostID WHERE Property.HostID = @HostID", connection);
                    filter.Parameters.AddWithValue("@HostID", Session["HostID"]);
                    SqlDataReader rdr = filter.ExecuteReader();
                    String name = "";
                    int propertyID = 0;
                    while (rdr.Read())
                    {
                        name = HttpUtility.HtmlEncode(rdr["FirstName"].ToString()) + " " + HttpUtility.HtmlEncode(rdr["LastName"].ToString());
                        propertyID = Convert.ToInt32(HttpUtility.HtmlEncode(rdr["PropertyID"]));
                    }

                    SqlCommand filterr = new SqlCommand("SELECT PropertyRoom.RoomID, PropertyRoom.PropertyID, Host.HostID, PropertyRoom.MonthlyPrice, isnull(PropertyRoom.BriefDescription, 'No Description') as BriefDescription, isnull(PropertyRoom.RoomDescription, 'No Description') as RoomDescription, PropertyRoom.Availability, " +
                "PropertyRoom.SquareFootage, PropertyRoom.Image1, PropertyRoom.Image2, PropertyRoom.Image3 FROM [dbo].[Host] inner join [dbo].[Property]" +
                "on Property.HostID = Host.HostID left join [dbo].[PropertyRoom] ON PropertyRoom.propertyID = Property.PropertyID WHERE Host.HostID = @HostID", connection);
                    filterr.Parameters.AddWithValue("@HostID", Session["HostID"]);
                    SqlDataReader rd = filterr.ExecuteReader();
                    int roomID = 0;
                    while (rd.Read())
                    {
                        roomID = Convert.ToInt32(rd["RoomID"]);   
                    }

                    int hostID = Convert.ToInt32(Session["hostID"]); 

                    SqlCommand insert = new SqlCommand("INSERT INTO [dbo].[RoomReservation] (RoomID, TenantID, HostID, PropertyID, StartDate, EndDate, LastUpdated, LastUpdatedBy) " +
                    "VALUES (@RoomID, @TenantID, @HostID, @PropertyID, @StartDate, @EndDate, @LastUpdated, @LastUpdatedBy)", connection);
                    insert.Parameters.AddWithValue("@TenantID", tenantID);
                    insert.Parameters.AddWithValue("@RoomID", roomID);
                    insert.Parameters.AddWithValue("@HostID", hostID);
                    insert.Parameters.AddWithValue("@PropertyID", propertyID);
                    insert.Parameters.AddWithValue("@StartDate", DateTime.Now);
                    insert.Parameters.AddWithValue("@EndDate", DBNull.Value);
                    insert.Parameters.AddWithValue("@LastUpdated", DateTime.Now);
                    insert.Parameters.AddWithValue("@LastUpdatedBy", name);

                    insert.ExecuteNonQuery();

                    SqlCommand update = new SqlCommand("UPDATE [dbo].[PropertyRoom] SET Availability = 'n', TenantID = @TenantID WHERE RoomID = @RoomID", connection);
                    update.Parameters.AddWithValue("@RoomID", roomID);
                    update.Parameters.AddWithValue("@TenantID", tenantID);
                    update.ExecuteNonQuery();
                }
                catch { }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}