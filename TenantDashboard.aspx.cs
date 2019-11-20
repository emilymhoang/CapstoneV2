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
using Stripe;

public partial class TenantDashboard : System.Web.UI.Page
{ 
    String underGraduate;
    String graduate;
    public string stripePublishableKey = WebConfigurationManager.AppSettings["StripePublishableKey"];
    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        var secretKey = WebConfigurationManager.AppSettings["StripeSecretKey"];
        StripeConfiguration.ApiKey = secretKey;
        if (Request.Form["stripeToken"] != null)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = Request.Form["stripeEmail"],
                //SourceToken = Request.Form["stripeToken"]
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            Console.WriteLine(charge);
        }

        //if (Session["username"] == null)
        //{
        //    Session["LoggedIn"] = "false";
        //    Response.Redirect("Login.aspx");
        //}

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

        lvMessagesTenant.DataSource = Message.lstTenantMessages;
        lvMessagesTenant.DataBind();

        lvFavorites.DataSource = Favorite.lstFavorites;
        lvFavorites.DataBind();

        sc.Open();
        int accountID = Convert.ToInt32(Session["accountID"]);
        Response.Write(accountID);

        SqlCommand insert = new SqlCommand("SELECT TenantID FROM [dbo].[Login] WHERE AccountID = @AccountID", sc);
        insert.Parameters.AddWithValue("@AccountID", accountID);
        insert.Connection = sc;
        int tenantID = Convert.ToInt32(insert.ExecuteScalar());
        insert.ExecuteNonQuery();
        Session["tenantID"] = tenantID;

        SqlCommand filter = new SqlCommand("SELECT FirstName, LastName, PhoneNumber, Email, BackgroundCheckResult, imageV2 FROM [dbo].[Tenant] WHERE TenantID = @TenantID", sc);
        filter.Parameters.AddWithValue("@TenantID", tenantID);
        SqlDataReader rdr = filter.ExecuteReader();
        String backgroundCheckResult;
        while (rdr.Read())
        {
            nameTextbox.Text = HttpUtility.HtmlEncode(rdr["FirstName"].ToString()) + " " + HttpUtility.HtmlEncode(rdr["LastName"].ToString());
            emailTextbox.Text = HttpUtility.HtmlEncode(rdr["Email"].ToString());
            phoneTextbox.Text = HttpUtility.HtmlEncode(rdr["PhoneNumber"].ToString());
            dashboardTitle.Text = HttpUtility.HtmlEncode(rdr["FirstName"].ToString()) + "'s Dashboard";
            backgroundCheckResult = HttpUtility.HtmlEncode(rdr["BackgroundCheckResult"].ToString());
            if (backgroundCheckResult == "y")
            {
                backgroundCheckResultTitle.Text = "Complete";
                image7.ImageUrl = "images/icons-07.png";
                backgroundCheckResultLbl.Text = "Your Background Check has been completed. Background checks are important to us. We take your safety seriously.";
            }
            else
            {
                backgroundCheckResultTitle.Text = "Not Complete";
                image7.ImageUrl = "images/NC.png";
                backgroundCheckResultLbl.Text = "Our people are working hard to get your background check completed. Background checks are important to us. We take your safety seriously.";
            }
            byte[] imgData = (byte[])rdr["imageV2"];
            if (!(imgData == null))
            {
                string img = Convert.ToBase64String(imgData, 0, imgData.Length);
                image1.ImageUrl = "data:image;base64," + img;
            }
        }
        usernameTextbox.Text = Session["username"].ToString();

        int tenantIDRefresh = Convert.ToInt32(Session["tenantID"]);
        Message.lstTenantMessages.Clear();

        SqlCommand badge = new SqlCommand("SELECT Undergraduate, graduate FROM [dbo].[BadgeTenant] WHERE TenantID = @TenantID", sc);
        badge.Parameters.AddWithValue("@TenantID", tenantID);

        SqlDataReader rdr2 = badge.ExecuteReader();


        while (rdr2.Read())
        {
            underGraduate = HttpUtility.HtmlEncode(rdr2["Undergraduate"].ToString());
            graduate = HttpUtility.HtmlEncode(rdr2["graduate"].ToString());
        }

        if (underGraduate == "True")
        {
            undergraduateBadge.ImageUrl = "images/badges-01.png";
        }

        if (graduate == "True")
        {
            graduateBadge.ImageUrl = "images/badges-02.png";


        }







        //displays all of tenants messages

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
                    "where Message.TenantID = @tenantid order by Message.MessageID desc";
                command.Parameters.AddWithValue("@tenantid", tenantIDRefresh);


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


                                Message msg = new Message(tenantid, hostid, message, lub);

                                msg.setMessageDate(Convert.ToDateTime(HttpUtility.HtmlEncode(reader["MessageDate"])));
                                string recieverName = string.Empty;

                                if (messageSender.Equals(lub))
                                {
                                    recieverName = "To: " + HttpUtility.HtmlEncode((string)reader["HostFirst"]) + " " + HttpUtility.HtmlEncode((string)reader["HostLast"] )+ "\tFrom: Me";
                                }
                                else
                                {
                                    recieverName = "To: Me\tFrom: " + HttpUtility.HtmlEncode((string)reader["HostFirst"] )+ " " + HttpUtility.HtmlEncode((string)reader["HostLast"]);
                                }

                                msg.setRecieverName(recieverName);


                                Message.lstTenantMessages.Add(msg);
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

        lvMessagesTenant.DataSource = Message.lstTenantMessages;
        lvMessagesTenant.DataBind();

        //favorite
        Favorite.lstFavorites.Clear();
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;


                command.CommandText = "select [dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Host].BackgroundCheckResult, [dbo].[Property].HouseNumber, [dbo].[Property].Street, [dbo].[Property].CityCounty, " +
                            "[dbo].[Property].HomeState, [dbo].[Property].Zip, [dbo].[PropertyRoom].RoomID, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') " +
                    "as BriefDescription, isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice, PropertyRoom.Image1 " +
                    "AS Image1, PropertyRoom.Image2 AS Image2, PropertyRoom.Image3 AS Image3 from [dbo].[Host] left join [dbo].[Property] " +
                    "on [dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] on " +
                    "[dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID left join [dbo].[Favorite] on " +
                    "[dbo].[PropertyRoom].RoomID = [dbo].[Favorite].RoomID where [dbo].[Favorite].TenantID = @tenantid";
                command.Parameters.AddWithValue("@tenantid", tenantIDRefresh);


                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string name = HttpUtility.HtmlEncode((string)reader["FirstName"]) + " " + HttpUtility.HtmlEncode((string)reader["LastName"]);
                                string location = HttpUtility.HtmlEncode((string)reader["CityCounty"]) + ", " + HttpUtility.HtmlEncode((string)reader["HomeState"]) + " " + HttpUtility.HtmlEncode((string)reader["Zip"]);

                                string description = HttpUtility.HtmlEncode((string)reader["BriefDescription"]);
                                int id = Convert.ToInt32(reader["RoomID"]);
                                string fullAddress = HttpUtility.HtmlEncode((string)reader["HouseNumber"]) + " " + HttpUtility.HtmlEncode((string)reader["Street"]) + ", " + HttpUtility.HtmlEncode((string)reader["CityCounty"]) + ", " + HttpUtility.HtmlEncode((string)reader["HomeState"]) + " " + HttpUtility.HtmlEncode((string)reader["Zip"]);
                                string price = HttpUtility.HtmlEncode(Math.Round(Convert.ToDouble(reader["MonthlyPrice"])).ToString());
                                backgroundCheckResult = HttpUtility.HtmlEncode(reader["BackgroundCheckResult"].ToString().ToLower());
                                string backgroundCheckPhoto = "";
                                if (backgroundCheckResult == "n")
                                {
                                    backgroundCheckPhoto = "images/NC.png";
                                }
                                if (backgroundCheckResult == "y")
                                {
                                    backgroundCheckPhoto = "images/icons-07.png";
                                }
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
                                Favorite fav = new Favorite(id, name, location, description, price, backgroundCheckPhoto, image1, image2, image3);
                                fav.setFullAddress(fullAddress);
                                Favorite.lstFavorites.Add(fav);
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

        lvFavorites.DataSource = Favorite.lstFavorites;
        lvFavorites.DataBind();


        //populates dropdown for messages
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;


                command.CommandText = "select distinct [dbo].[Favorite].HostID, [dbo].[Host].FirstName, [dbo].[Host].LastName " +
                    "from [dbo].[Favorite] left join [dbo].[Host] " +
                    "on [dbo].[Favorite].HostID = [dbo].[Host].HostID " +
                    "where [dbo].[Favorite].TenantID = @tenantid";
                command.Parameters.AddWithValue("@tenantid", tenantIDRefresh);


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
                                var val = Convert.ToInt32(HttpUtility.HtmlEncode(reader["HostID"]));
                                item.Text = HttpUtility.HtmlEncode((string)reader["FirstName"] )+ HttpUtility.HtmlEncode((string)reader["Lastname"]);
                                item.Value = val.ToString();
                                hostNameDropdown.Items.Add(item);
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
        noReservation.Visible = true;
        Panel2.Visible = false;
        SqlCommand get = new SqlCommand("select[dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Host].BackgroundCheckResult, [dbo].[Property].CityCounty, " +
                    "[dbo].[Property].HomeState, [dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') " +
                    "as BriefDescription, isnull([dbo].[PropertyRoom].MonthlyPrice, 0) as MonthlyPrice, PropertyRoom.Image1 " +
                    "AS Image1, PropertyRoom.Image2 AS Image2, PropertyRoom.Image3 AS Image3 from [dbo].[Host] left join [dbo].[Property] " +
                    "on [dbo].[Host].HostID = [dbo].[Property].HostID left join [dbo].[PropertyRoom] on " +
                    "[dbo].[Property].PropertyID = [dbo].[PropertyRoom].PropertyID left join [dbo].[RoomReservation] on " +
                    "[dbo].[PropertyRoom].RoomID = [dbo].[RoomReservation].RoomID where [dbo].[RoomReservation].TenantID = @tenantid", sc);
        get.Parameters.AddWithValue("@TenantID", tenantID);
        get.ExecuteNonQuery();
        SqlDataReader r = get.ExecuteReader();
        while (r.Read())
        {
            noReservation.Visible = false;
            Panel2.Visible = true;
            rentalTitle.Text = HttpUtility.HtmlEncode(r["BriefDescription"].ToString());
            hostNames.Text = HttpUtility.HtmlEncode(r["FirstName"].ToString()) + " " + HttpUtility.HtmlEncode(r["LastName"].ToString());
            city.Text = HttpUtility.HtmlEncode(r["CityCounty"].ToString()) + ", " + HttpUtility.HtmlEncode(r["HomeState"].ToString());
            byte[] imgD1;
            byte[] imgD2;
            byte[] imgD3;

            try
            {
                imgD1 = (byte[])r["Image1"];
            }
            catch
            {
                imgD1 = (byte[])Session["defaultPicture"];
            }

            try
            {
                imgD2 = (byte[])r["Image2"];
            }
            catch
            {
                imgD2 = (byte[])Session["defaultPicture"];
            }

            try
            {
                imgD3 = (byte[])r["Image3"];
            }
            catch
            {
                imgD3 = (byte[])Session["defaultPicture"];
            }



            string i1 = "data:image;base64," + Convert.ToBase64String(imgD1, 0, imgD1.Length);
            string i2 = "data:image;base64," + Convert.ToBase64String(imgD2, 0, imgD2.Length);
            string i3 = "data:image;base64," + Convert.ToBase64String(imgD3, 0, imgD3.Length);

            image4.ImageUrl = i1;
            image5.ImageUrl = i2;
            image6.ImageUrl = i3;
        }
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


        Message.lstTenantMessages.Clear();

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
                    "where Message.TenantID = @tenantid order by Message.MessageID desc";
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
                                int hostid = Convert.ToInt32(HttpUtility.HtmlEncode(reader["HostID"]));
                                int tenantid = Convert.ToInt32(HttpUtility.HtmlEncode(reader["TenantID"]));
                                string message = HttpUtility.HtmlEncode((string)reader["Message"]);
                                string lub = HttpUtility.HtmlEncode((string)reader["LastUpdatedBy"]);


                                Message msg = new Message(tenantid, hostid, message, lub);

                                msg.setMessageDate(Convert.ToDateTime(HttpUtility.HtmlEncode(reader["MessageDate"])));
                                string recieverName = string.Empty;

                                if (messageSender.Equals(lub))
                                {
                                    recieverName = "To: " + HttpUtility.HtmlEncode((string)reader["HostFirst"]) + " " + HttpUtility.HtmlEncode((string)reader["HostLast"] )+ "\tFrom: Me";
                                } else
                                {
                                    recieverName = "To: Me\tFrom: " + HttpUtility.HtmlEncode((string)reader["HostFirst"]) + " " + HttpUtility.HtmlEncode((string)reader["HostLast"]);
                                }
                                
                                msg.setRecieverName(recieverName);


                                Message.lstTenantMessages.Add(msg);
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

        lvMessagesTenant.DataSource = Message.lstTenantMessages;
        lvMessagesTenant.DataBind();
        messageTextbox.Text = string.Empty;
    }

    protected void contract(object sender, EventArgs e)
    {fav
        Response.Redirect("Contract.aspx");
    }

    protected void profileButton(object sender, EventArgs e)
    {

        Favorite.selectedReultFullAddress = string.Empty;
        Button btn = sender as Button;
        ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
        var index = item.DataItemIndex;
        Favorite.selectedReultFullAddress = Favorite.lstFavorites[index].resultFullAddress;
        Session["position"] = index;

        Response.Redirect("PropertyDescription.aspx");
    }

    protected void logout(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Index.aspx");
    }
}