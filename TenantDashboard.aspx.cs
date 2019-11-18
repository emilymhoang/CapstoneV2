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

public partial class TenantDashboard : System.Web.UI.Page
{

    String underGraduate;
    String graduate;

    SqlConnection sc = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        lvMessages.DataSource = Message.lstMessages;
        lvMessages.DataBind();

        lvFavorites.DataSource = Favorite.lstFavorites;
        lvFavorites.DataBind();

        sc.Open();
        int accountID = Convert.ToInt32(Session["accountID"]);
        Response.Write(accountID);

        SqlCommand insert = new SqlCommand("SELECT TenantID FROM [Capstone].[dbo].[Login] WHERE AccountID = @AccountID", sc);
        insert.Parameters.AddWithValue("@AccountID", accountID);
        insert.Connection = sc;
        int tenantID = Convert.ToInt32(insert.ExecuteScalar());
        insert.ExecuteNonQuery();
        Session["tenantID"] = tenantID;

        SqlCommand filter = new SqlCommand("SELECT FirstName, LastName, PhoneNumber, Email, BackgroundCheckResult, imageV2 FROM [Capstone].[dbo].[Tenant] WHERE TenantID = @TenantID", sc);
        filter.Parameters.AddWithValue("@TenantID", tenantID);
        SqlDataReader rdr = filter.ExecuteReader();
        String backgroundCheckResult;
        while (rdr.Read())
        {
            nameTextbox.Text = rdr["FirstName"].ToString() + " " + rdr["LastName"].ToString();
            emailTextbox.Text = rdr["Email"].ToString();
            phoneTextbox.Text = rdr["PhoneNumber"].ToString();
            dashboardTitle.Text = rdr["FirstName"].ToString() + "'s Dashboard";
            backgroundCheckResult = rdr["BackgroundCheckResult"].ToString();
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
        Message.lstMessages.Clear();

        SqlCommand badge = new SqlCommand("SELECT Undergraduate, graduate FROM [Capstone].[dbo].[BadgeTenant] WHERE TenantID = @TenantID", sc);
        badge.Parameters.AddWithValue("@TenantID", tenantID);

        SqlDataReader rdr2 = badge.ExecuteReader();


        while (rdr2.Read())
        {
            underGraduate = rdr2["Undergraduate"].ToString();
            graduate = rdr2["graduate"].ToString();
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
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;


                command.CommandText = "select  Message.HostID, Message.TenantID, Message.Message, Message.MessageDate," +
                    " Message.LastUpdated, Message.LastUpdatedBy, Host.FirstName, Host.LastName from Message " +
                    "left join Host on message.HostID = host.HostID where Message.TenantID = @tenantid order by Message.MessageID desc";
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

        //favorite
        Favorite.lstFavorites.Clear();
        using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["RDSConnectionString"].ConnectionString))
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;


                command.CommandText = "select [dbo].[Host].FirstName, [dbo].[Host].LastName, [dbo].[Host].BackgroundCheckResult, [dbo].[Property].CityCounty, " +
                    "[dbo].[Property].HomeState, [dbo].[Property].Zip, isnull([dbo].[PropertyRoom].BriefDescription, 'No Description') " +
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
                                string name = (string)reader["FirstName"] + " " + (string)reader["LastName"];
                                string location = (string)reader["CityCounty"] + ", " + (string)reader["HomeState"] + " " + (string)reader["Zip"];

                                string description = (string)reader["BriefDescription"];


                                string price = Math.Round(Convert.ToDouble(reader["MonthlyPrice"])).ToString();
                                backgroundCheckResult = reader["BackgroundCheckResult"].ToString().ToLower();
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
                                Favorite fav = new Favorite(name, location, description, price, backgroundCheckPhoto, image1, image2, image3);
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

    protected void profileButton(object sender, EventArgs e)
    {

        SearchResult.selectedReultFullAddress = string.Empty;
        Button btn = sender as Button;
        ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;
        var index = item.DataItemIndex;
        SearchResult.selectedReultFullAddress = SearchResult.lstSearchResults[index].resultFullAddress;


        Response.Redirect("PropertyDescription.aspx");
    }

    protected void logout(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Index.aspx");
    }
}