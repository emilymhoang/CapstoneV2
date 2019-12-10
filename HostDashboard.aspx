﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HostDashboard.aspx.cs" Inherits="HostDashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <style>
        .modalBackground{
            background-color: black;
            filter:alpha(opacity=90) !important;
            opacity:0.6 ! important;
            z-index: 20;
        }
        .modalpopup{
            padding: 20px 0px 24px 10px;
            position: relative;
            width: 500px;
            height: 500px;
            background-color: white;
            border-radius: 10%;
            border: 1px solid black;
        }
        .btn {
           font-family: 'Oswald', sans-serif;
           color: white; 
           font-size: 20px;
       }
    </style>
<div  class="container">
  <div class="row " style="margin-top: 7rem; ">
    <div class="col-md-9">
        <h1><asp:Label ID="dashboardTitle" runat="server" Text=""></asp:Label></h1>
      </div>
    <div class="col-md-3">
        <a href="AddRoom.aspx" class="btn " style="margin-top: 1rem;">Add Room</a>
        <asp:Button ID="logoutButton" onClick="logout" style="margin-top: 1rem;" runat="server" Text="Logout" AutoPostBack="true" type="submit" class="btn"/>

      </div>
    </div><!-- end div row -->  
    
    
   <div class="row " style="margin-top: 1rem;">
    <div class="col-md-6" style="border: solid; border-color: white;">
        <div class="row">
            <div class="col-md-6">
               <h2 >Your Profile</h2> 
            </div>
            <div class="col-md-6">
                <a href="EditProfileHost.aspx" class="btn" >Edit Profile</a>
            </div>
        </div>
           <%--    begin file container--%>
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; overflow:auto !important; height:410px !important; border-radius:25px;" >
            <div class="col-md-6" style="margin-top: 1rem;">
                    <asp:Image ID="image1" style="border-radius: 10%;" class="img-fluid" runat="server" />
                
                <div class="row" style="margin-top: 1rem;">
                    <div class="col-md-6">
                        <asp:Image ID="image2" class="img-fluid" runat="server" />
                    </div>
                    <div class="col-md-6">
                        <asp:Image ID="image3" class="img-fluid" runat="server" />
                    </div>
                </div>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <h3><asp:Label ID="nameTextbox" runat="server" Text="Name" BackColor="#ebebeb"></asp:Label></h3>
                 <p><asp:Label ID="usernameTextbox" runat="server" Text="Username" BackColor="#ebebeb"></asp:Label></p>
                 <p><asp:Label ID="emailTextbox" Text="name@gmailcom" runat="server" BackColor="#ebebeb"></asp:Label></p>
                 <p><asp:Label ID="phoneTextbox" Text="xxx-xxx-xxx" runat="server"  BackColor="#ebebeb"></asp:Label></p>
                 <p><asp:Label ID="hostBioTextbox" Text="Host bio will go here displaying a little about the host." runat="server"  BackColor="#ebebeb"></asp:Label></p>
                <asp:Image ID="undergraduateBadge" class="img-fluid" runat="server" />
                 <asp:Image ID="graduateBadge" class="img-fluid" runat="server" />
                 <%--<img src="images/badges-01.png" style="max-width: 150px;">--%>
            </div>

        <%--    end profile container--%>
        </div>
      </div>

        <div class="col-md-6" style="border: solid; border-color: white;">
        <div class="row">
            <div class="col-md-6">
               <h2 >Your Property</h2> 
            </div>
            <div class="col-md-6">
            </div>
        </div>




           <%--    begin file container--%>
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; overflow:auto !important; height:410px !important; border-radius:25px;" >
            <div class="col-md-12" style="margin-top: 1rem;">
                <h3>Your Available Rooms in: </h3>
                <h2><asp:Label ID="addressTextbox" runat="server" Text="Address" BackColor="#ebebeb"></asp:Label></h2>

        <div class="list-group" style="margin-top: 1rem; height: 400px;">
        <asp:ListView id="lvPropertyRoom" runat="server" Visible="true" >

            <LayoutTemplate>
                <table id="tbl1" runat="server">
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <table style="margin-top: 1rem;  border-top: solid 1px;">
                    <tr>
                         <td>
                             <table >
                                <tr>
                                     <td>
                                        <%--<asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="Label1" Text='<%#Eval("briefDescription") %>'></asp:Label> <asp:Label runat="server" Text=" "></asp:Label>--%>
</br>
                                    </td>
                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label runat="server" ID="lblResultDesc" style="font-family: 'Oswald', sans-serif; line-height: 1.3; font-size: 20px; max-width: 200px; min-width: 200px; word-wrap: break-word;" Text='<%#Eval("briefDescription") %>'></asp:Label></br>
                                    </td>
                                </tr>
                                <tr>
                                     <td>
                                         <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 16px;" ID="lblResultPrice" Text='<%#Eval("monthlyPrice") %>'></asp:Label> </br>
                                        <asp:Label runat="server" style="font-family: 'Raleway', sans-serif; font-size: 16px;" ID="lblPropertyBio" Text='<%#Eval("roomDescription") %>'></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                     <td>




                                        
                                         <br />
                                        <asp:Button runat="server" class="btn" ID="hideProperty" OnClick="hideProperties" AutoPostBack="true" Text="Reserve a Room"/>
                                         </br>
                                    </td>
                                 </tr>   
                             </table>
                        </td>
                        <td>
                            <div class="row" style="margin:auto; margin-bottom: 1rem; margin-top: 1rem;" >
                                <center>
                                     <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                                    </ol>
                                    <div class="carousel-inner" style="width: 200px">
                                        <div class="row">
                                            <div class="carousel-item active">    
                                                <asp:Image ID="image4" style="object-fit: cover; width:200px; height:150px;" ImageUrl='<%#Eval("roomimage1")%>' class="img-fluid" runat="server" />
                                                   </div>
                                            <div class="carousel-item ">
                                               <asp:Image ID="image5" style="object-fit: cover;  width:200px; height:150px;" ImageUrl='<%#Eval("roomimage2")%>' class="img-fluid" runat="server" />
                                                   </div>
                                            <div class="carousel-item ">                
                                                   <asp:Image ID="image6" style="object-fit: cover;  width:200px; height:150px;" ImageUrl='<%#Eval("roomimage3")%>' class="img-fluid" runat="server" />
                                                </div>
                                        </div>
                                    </div>
                                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                        <span class="sr-only">Next</span>
                                    </a>
                                </div>
                                    </center>
                              </div>
                        </td>
                    </tr>
                </table>

                
            </ItemTemplate>

        </asp:ListView>
                        <asp:DropDownList runat="server" ID="drpTenantName" DataSourceID="SqlDataSource2" DataTextField="FullName" CssClass="form-control" width="200px" DataValueField="TenantID"></asp:DropDownList>
                                         <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:HostDashConnectionString %>' SelectCommand="select Tenant.FirstName + ' ' + Tenant.LastName as FullName, Message.TenantID from Tenant left join Message on Tenant.TenantID = Message.TenantID where Message.HostID = @hostid
">
                                             <SelectParameters>
                                                 <asp:SessionParameter SessionField="hostID" DefaultValue="487" Name="hostid"></asp:SessionParameter>
                                             </SelectParameters>
                                         </asp:SqlDataSource>
            </div>
    

            </div>

        <%--    end profile container--%>
        </div>
      </div>

      </div>      <!-- end big row -->
    
    
         <div class="row " style="margin-top: 1rem;">
        <div class="col-md-6"  style="border: solid; border-color: white;">
            <div class="row">
                <div class="col-md-12">
                   <div class="row">
                    <div class="col-md-4">
                    <h3 >Message Board</h3> 
                        </div>
                <div class="col-md-3">
                    <a data-config="commands=videocall;size=14;status=off;theme=logo;language=en;bgcolor=#000000;hostname=www.skaip.org" id="skaip-buttons" href="http://www.skaip.org/">Skype</a><script src="//apps.skaip.org/buttons/widget/core.min.js" defer="defer"></script>
                        <a href="skype:Echo123"><button runat="server" class="btn " style="font-family: 'Oswald', sans-serif; color: white;  ">Videochat</button></a>
                    </div>
              <div class="col-md-3">
                        <asp:Button ID="createMessageButton" runat="server" Text="Create a Message" AutoPostBack="true" type="submit" class="btn"/>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>        
                <asp:Panel ID="Panel1" runat="server" CssClass="modalpopup">
                    <center>
                        <asp:Label style="font-family: 'Oswald', sans-serif;  font-size: 24px" ID="Label2" runat="server" Text="Label">Create a Message</asp:Label>
                    </center>
                    <asp:Label style="font-family: 'Oswald', sans-serif; ; font-size: 20px" ID="Label1" runat="server" Text="Label">Send to: </asp:Label>
                       
                        <asp:DropDownList ID="tenantNameDropdown" runat="server">
                            
                        </asp:DropDownList>
                    <br />
                    <br />
                       
                        
                    <center>
                        <asp:TextBox ID="messageTextbox" TextMode="MultiLine" class="form-control" style="height:300px; width:400px;" runat="server"></asp:TextBox>
                        <br />
                                            <asp:Label ID="resultmessageMessage" runat="server" ForeColor="Red"></asp:Label>
                        <asp:Button class="btn" ID="sendButton" onClick="sendMessage" runat="server" Text="Send" />
                        <asp:Button class="btn" ID="cancelButton" runat="server" Text="Cancel" /> <br/>
                    </center>
                </asp:Panel>
                <AjaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="createMessageButton" BackgroundCssClass="modalBackground" CancelControlID="cancelButton">
                </AjaxToolkit:ModalPopupExtender>
            </div>
                </div>

            <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; overflow:auto !important; height:410px !important; border-radius:25px;" >
                <div class="col-md-12" style="margin-top: 1rem;">
                    <div class="list-group" >
                        <asp:ListView id="lvMessagesHost" runat="server" Visible="true" >
                        
                        <LayoutTemplate>
                           <%-- <h1>Message Board</h1>--%>
                        <table id="tbl1" runat="server">
                            <tr id="itemPlaceholder" runat="server"></tr>
                        </table>
                        </LayoutTemplate>

                        <ItemTemplate>
                        <table>
                                <tr>
                                    <td>
                                        <h3>
                                            <asp:Label ID="lblSenderName" runat="Server" Text='<%#Eval("recieverName") %>' />
                                        </h3>
                                    </td>
                                    <td>
                                            <asp:Button ID="viewTenantProfile" onClick="viewTenantProfile" style="font-size: 14px;" runat="server" Text="View Profile" AutoPostBack="true" type="submit" class="btn" />
                                    </td>
<%--                                    <td>
                                        <h3>
                                            <asp:Label ID="Label3" runat="Server" Text="--" />
                                        </h3>
                                    </td>--%>
                                    <td>
                                        <h5>
                                            <asp:Label ID="lblMessageDate" runat="Server" Text='<%#Eval("messageDate") %>' />
                                        </h5>
                                    </td>
                                </tr>
                            </table>
                            <table style="border-bottom: 1px solid black">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMessage" runat="Server" Text='<%#Eval("message") %>' />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>

                    </asp:ListView>
                </div>
                </div>
            </div>
          </div>
         </div>
    
    </div><!-- end div big row -->
        <div class="col-md-6"  style="border: solid; border-color: white;">
            <h2 >Background Check Status</h2> 
            <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; overflow:auto !important; height:410px !important; border-radius:25px;" >
            <div class="col-md-12" style="margin-top: 1rem;">
               <h3><asp:Label ID="backgroundCheckResultTitle" runat="server" Text=""></asp:Label></h3>
                <p style="text-align: center;"><asp:Image ID="image7" style="max-width: 100px;" class="img-fluid" runat="server" /></p>
                <p><asp:Label ID="backgroundCheckResultLbl" runat="server" Text=""></asp:Label><br></p>
                     <a href="https://www.intellicorp.net/marketing" class="btn" target="blank">More Information</a><br><br>
            </div>
            </div>
            </div>
    
   
    <div class="row " style="margin-top: 1rem;">
        <div class="col-md-12"  >
            
          </div>
    </div><!-- end div big row -->  
    
    <div class="row " style="margin-top: 1rem; background-color: #ebebeb; margin-bottom: 3rem;  border-radius:25px;">
        <div class="col-md-12"  style=" margin-top: 1rem;">
            <h2>Your Rental Agreements</h2>
            <p>When you have a rental agreement, it will be indicated here. We hope you find your perfect housing match so that you can have some wonderful rental agreements.</p>
            <asp:Button ID="sampleAgreement" onClick="contract" style="margin-top: 1rem;" runat="server" Text="Sample Agreement" AutoPostBack="true" type="submit" class="btn"/><br/><br />
          </div>
    </div><!-- end div big row -->  
    
    
    
</div> 
</div><!-- end div container! -->   

</asp:Content>

