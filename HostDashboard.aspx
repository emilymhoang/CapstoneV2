<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HostDashboard.aspx.cs" Inherits="HostDashboard" %>
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
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem;" >
            <div class="col-md-6" style="margin-top: 1rem;">
                    <asp:Image ID="image1" ImageUrl="" class="img-fluid" runat="server" />
                
                <div class="row" style="margin-top: 1rem;">
                    <div class="col-md-6">
                        <asp:Image ID="image2" ImageUrl="" class="img-fluid" runat="server" />
                    </div>
                    <div class="col-md-6">
                        <asp:Image ID="image3" ImageUrl="" class="img-fluid" runat="server" />
                    </div>
                </div>
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <h3><asp:Label ID="nameTextbox" runat="server" Text="Name" BackColor="#ebebeb"></asp:Label></h3>
                 <p><asp:Label ID="usernameTextbox" runat="server" Text="Username" BackColor="#ebebeb"></asp:Label></p>
                 <p><asp:Label ID="emailTextbox" Text="name@gmailcom" runat="server" BackColor="#ebebeb"></asp:Label></p>
                 <p><asp:Label ID="phoneTextbox" Text="xxx-xxx-xxx" runat="server"  BackColor="#ebebeb"></asp:Label></p>
                <asp:Image ID="undergraduateBadge" ImageUrl="" class="img-fluid" runat="server" />
                 <asp:Image ID="graduateBadge" ImageUrl="" class="img-fluid" runat="server" />
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
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem;" >
            <div class="col-md-6" style="margin-top: 1rem;">
                 <div>
        <asp:ListView id="lvPropertyRoom" runat="server" Visible="true" >

            <LayoutTemplate>
                <h1>Your Property Room</h1>
                <table id="tbl1" runat="server">
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <table style="margin-top: 1rem; border-bottom: solid; width:1500px; border-bottom-width: 1px;">
                    <tr>
                        <td>
                            <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="lblResultName" Text='<%#Eval("availability") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem;" >
                                <div class="col-md-6" style="margin-top: 1rem;">


                                     <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                                    </ol>

                                    <div class="carousel-inner">
                                        <div class="row">
                                            <div class="carousel-item active">    
                                                <asp:Image ID="image4" ImageUrl='<%#Eval("roomimage1") %>' class="img-fluid" runat="server" />
                                                   </div>

                                            <div class="carousel-item ">
                                               <asp:Image ID="image5" ImageUrl='<%#Eval("roomimage2") %>' class="img-fluid" runat="server" />
                                                   </div>
                                            <div class="carousel-item ">                
                                                   <asp:Image ID="image6" ImageUrl='<%#Eval("roomimage3") %>' class="img-fluid" runat="server" />
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
                               </div>
                              </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultLocation" Text='<%#Eval("briefDescription") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        </tr>
                       <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <div style="max-width: 200px; min-width: 200px; word-wrap: break-word">
                                            <asp:Label runat="server" ID="lblResultDesc" style="font-family: 'Raleway', sans-serif; line-height: 1.3; font-size: 18px;" Text='<%#Eval("roomDescription") %>'></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultPrice" Text='<%#Eval("monthlyPrice") %>'></asp:Label>
                        </td>
                    </tr>
                    
                </table>

                
            </ItemTemplate>

        </asp:ListView>
    </div>

<%--                 <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                </ol>

                <div class="carousel-inner">
                    <div class="row">
                        <div class="carousel-item active">    
                            <asp:Image ID="image4" ImageUrl="" class="img-fluid" runat="server" />
                               </div>

                        <div class="carousel-item ">
                           <asp:Image ID="image5" ImageUrl="" class="img-fluid" runat="server" />
                               </div>
                        <div class="carousel-item ">                
                               <asp:Image ID="image6" ImageUrl="" class="img-fluid" runat="server" />
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
            </div>--%>

            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <h3><asp:Label ID="addressTextbox" runat="server" Text="Address" BackColor="#ebebeb"></asp:Label></h3>
                 <p><asp:Label ID="priceTextbox" runat="server" Text="Price" BackColor="#ebebeb"></asp:Label></p>
                 <p><asp:Label ID="descriptionTextbox" Text="Single furnished room on a quiet street" runat="server" BackColor="#ebebeb"></asp:Label></p>
                 <p><asp:Label ID="roomDescripTextbox" Text="Shared Room" runat="server"  BackColor="#ebebeb"></asp:Label></p>

                <asp:Image ID="privateEntranceBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="140" />
                 <asp:Image ID="kitchenBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="140" />
                 <asp:Image ID="privateBathroomBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="140" />
                 <asp:Image ID="furnishBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="140" />
                 <asp:Image ID="storageBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="140" />
                 <asp:Image ID="smokerBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="140" />
                
                 <%--<img src="images/badges-01.png" style="max-width: 150px;">--%>
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
                <div class="col-md-4">
                    <a data-config="commands=videocall;size=14;status=off;theme=logo;language=en;bgcolor=#000000;hostname=www.skaip.org" id="skaip-buttons" href="http://www.skaip.org/">Skype</a><script src="//apps.skaip.org/buttons/widget/core.min.js" defer="defer"></script>
                    <div>
                        <a href="skype:Echo123"><button class="btn btn-primary" style="font-family: 'Oswald', sans-serif; color: white; font-size: 18px; ">Videochat</button></a>
                    </div>
                    </div>
              <div class="col-md-3">
                        <asp:Button ID="createMessageButton" runat="server" Text="Create a Message" AutoPostBack="true" type="submit" class="btn"/>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>        
                <asp:Panel ID="Panel1" runat="server" CssClass="modalpopup">
                    <center>
                        <asp:Label style="font-family: 'Oswald', sans-serif; color: #53A39F; font-size: 30px" ID="Label2" runat="server" Text="Label">Create a Message</asp:Label>
                    </center>
                    <asp:Label style="font-family: 'Oswald', sans-serif; color: #53A39F; font-size: 30px" ID="Label1" runat="server" Text="Label">Send to: </asp:Label>
                       
                        <asp:DropDownList ID="hostNameDropdown" runat="server">
                            <asp:ListItem Value="02">Ryan Krane</asp:ListItem>
                            <asp:ListItem Value="42">Hank Sherbert</asp:ListItem>
                            <asp:ListItem Value="43">Jason Gerhardt</asp:ListItem>
                            <asp:ListItem Value="44">Shannon Hoang</asp:ListItem>
                        </asp:DropDownList>
                       
                        
                        <br />
                    <center>
                        <asp:TextBox ID="messageTextbox" TextMode="MultiLine" class="form-control" style="height:300px; width:400px;" runat="server"></asp:TextBox>
                        <br />
                        <asp:Button class="btn" ID="sendButton" onClick="sendMessage" runat="server" Text="Send" />
                        <asp:Button class="btn" ID="cancelButton" runat="server" Text="Cancel" /> <br/>
                    </center>
                </asp:Panel>
                <AjaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="createMessageButton" BackgroundCssClass="modalBackground" CancelControlID="cancelButton">
                </AjaxToolkit:ModalPopupExtender>
            </div>
                </div>

            <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem;" >
                <div class="col-md-12" style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;">
                    <div class="list-group" style="overflow:scroll">
                        <asp:ListView id="lvMessages" runat="server" Visible="true" >
                        
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
                                        <h3>
                                            <asp:Label ID="Label3" runat="Server" Text="--" />
                                        </h3>
                                    </td>
                                    <td>
                                        <h3>
                                            <asp:Label ID="lblMessageDate" runat="Server" Text='<%#Eval("messageDate") %>' />
                                        </h3>
                                    </td>
                                </tr>
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
            <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; " >
            <div class="col-md-12" style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;">
               <h3><asp:Label ID="backgroundCheckResultTitle" runat="server" Text=""></asp:Label></h3>
                <p style="text-align: center;"><asp:Image ID="image7" style="max-width: 200px;" ImageUrl="" class="img-fluid" runat="server" /></p>
                <p><asp:Label ID="backgroundCheckResultLbl" runat="server" Text=""></asp:Label><br><br><br><br><br><br></p>
            </div>
            </div>
            </div>
    
   
    <div class="row " style="margin-top: 1rem;">
        <div class="col-md-12"  >
            
          </div>
    </div><!-- end div big row -->  
    
    <div class="row " style="margin-top: 1rem; background-color: #ebebeb; margin-bottom: 3rem;">
        <div class="col-md-12"  style=" margin-top: 1rem;">
            <h2>Your Rental Agreements</h2>
            <p>When you have a rental agreement, it will be indicated here. We hope you find your perfect housing match so that you can have some wonderful rental agreements.</p>
            <asp:Button ID="sampleAgreement" onClick="contract" style="margin-top: 1rem;" runat="server" Text="Sample Agreement" AutoPostBack="true" type="submit" class="btn"/><br/>
          </div>
    </div><!-- end div big row -->  
    
    
    
</div> 
</div><!-- end div container! -->   

</asp:Content>

