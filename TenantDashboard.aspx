<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenantDashboard.aspx.cs" Inherits="TenantDashboard" %>
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
           
       }

        .big-table {
            display: table; /* Make the container element behave like a table */
            width: 100%; /* Set full-width to expand the whole page */
        }

        .table-cell {
            display: table-cell; /* Make elements inside the container behave like table cells */
        }
        
        
    </style>
<div  class="container">
  <div class="row " style="margin-top: 7rem; ">
    <div class="col-md-9">
        <h1><asp:Label ID="dashboardTitle" runat="server" Text=""></asp:Label></h1>
      </div>
    <div class="col-md-3">
        <a href="Search.aspx" class="btn " style="margin-top: 1rem;">Search Properties</a>
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
                <a href="EditProfileTenant.aspx" class="btn" >Edit Profile</a>
            </div>
        </div>
           <%--    begin file container--%>
        <div class="row container" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; overflow:auto !important; height:410px !important; border-radius:25px;" >
            <div class="col-md-6 " style="margin-top: 1rem;">
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
                <h3><asp:Label ID="nameTextbox" runat="server" Text="John Smith" BackColor="#ebebeb"></asp:Label></h3>
                 <p><asp:Label ID="usernameTextbox" runat="server" Text="JohnSmith1" BackColor="#ebebeb"></asp:Label></p>
                 <p><asp:Label ID="emailTextbox" Text="johnsmith@gmailcom" runat="server" BackColor="#ebebeb"></asp:Label></p>
                 <p><asp:Label ID="phoneTextbox" Text="xxx-xxx-xxx" runat="server"  BackColor="#ebebeb"></asp:Label></p>
                <asp:Image ID="undergraduateBadge" ImageUrl="" class="img-fluid" runat="server" />
                 <asp:Image ID="graduateBadge" ImageUrl="" class="img-fluid" runat="server" />
                 <%--<img src="images/badges-01.png" style="max-width: 150px;">--%>
            </div>

        <%--    end profile container--%>
        </div>
      </div>

        <div class="col-md-6"  style="border: solid; border-color: white;">
            <div class="row">
                    <div class="col-md-6">
                    <h3 >Your Favorites</h3> 
                        </div>
                    </div>
            <div class="container row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; overflow:auto !important; height:410px !important; border-radius:25px;" >
                <div class="col-md-12" style="margin-top: 1rem;">
                    <div class="list-group " style="margin-top: 1rem;  height: 500px;">
         <asp:ListView id="lvFavorites" runat="server" Visible="true" >

            <LayoutTemplate>
                <table id="tbl1" runat="server">
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <table style=" border-bottom: solid; border-bottom-width: 1px;">
                    <tr>
                         <td style="width: 200px;">
                             <table>
                                 <tr>
                                     <td>
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="Label1" Text='<%#Eval("favName") %>'></asp:Label> <asp:Label runat="server" Text=" "></asp:Label><asp:Image ID="backgroundCheck" ImageUrl='<%#Eval("backgroundCheckResult")%>' style="max-width: 35px; margin-bottom: 1rem;" class="img-fluid" runat="server" />
</br>
                                    </td>
                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultLocation" Text='<%#Eval("favLocation") %>'></asp:Label></br>
                                    </td>
                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label runat="server" ID="lblResultDesc" style="font-family: 'Raleway', sans-serif; line-height: 1.3; font-size: 18px; max-width: 200px; min-width: 200px; word-wrap: break-word;" Text='<%#Eval("favDescription") %>'></asp:Label></br>
                                    </td>
                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultPrice" Text='<%#Eval("favPrice") %>'></asp:Label> </br>
                                    </td>
                                </tr>
                                 <tr>
                                     <td>
                                        <asp:Label runat="server" Text=" "></asp:Label>
                                    </td>
                                 </tr>   
                                <tr>
                                     <td>
                                        <asp:Button runat="server" class="btn" ID="btnViewProfile" onClick="profileButton" Text="View Profile" />
                                    </td
                                </tr>
                             </table>
                        </td>
                        <td style="width: 200px;">
                            <div class="row" style="margin:auto; margin-bottom: 1rem;" >
                                <center>
                                <div class="col-md-6" style="margin-top: 1rem;">
                                     <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                                    </ol>
                                     <div class="carousel-inner" style="width: 200px; max-height: 200px;">
                                        <div class="row">
                                            <div class="carousel-item active">    
                                                <asp:Image ID="image4" style="width:1000px;" ImageUrl='<%#Eval("resultimage1")%>' class="img-fluid" runat="server" />
                                                   </div>
                                            <div class="carousel-item ">
                                               <asp:Image ID="image5" style="width:1000px" ImageUrl='<%#Eval("resultimage2")%>' class="img-fluid" runat="server" />
                                                   </div>
                                            <div class="carousel-item ">                
                                                   <asp:Image ID="image6" style="width:1000px" ImageUrl='<%#Eval("resultimage3")%>' class="img-fluid" runat="server" />
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
                                    </center>
                              </div>
                        </td>
                    </tr>
                </table>

                
            </ItemTemplate>

        </asp:ListView>
                </div>
                </div>
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
                    <div>
                        <a href="skype:Echo123"><button class="btn " style="font-family: 'Oswald', sans-serif; color: white;  ">Videochat</button></a>
                    </div>
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
                       
                        <asp:DropDownList ID="hostNameDropdown" runat="server">
                            
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

            <div class="row container" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; overflow:auto !important; height:410px !important; border-radius:25px;" >
                <div class="col-md-12" style="margin-top: 1rem;">

                    <div class="list-group" style=" height: 290px;">

                        <asp:ListView id="lvMessagesTenant" runat="server" Visible="true" >
                        
                        <LayoutTemplate>
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
<%--                                    <td>
                                        <h3>
                                            <asp:Label ID="Label3" runat="Server" Text="--" />
                                        </h3>
                                    </td>--%>
                                    <td>
                                        <h5>
                                            <asp:Label style="float: right;" ID="lblMessageDate" runat="Server" Text='<%#Eval("messageDate") %>' />
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


        <%--<div class="col-md-6" style="border: solid; border-color: white;" >
        <div class="row">
            <div class="col-md-12">
               <h2 >Background Check Status</h2> 
            </div>
            
        </div>
        
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; " >
            <div class="col-md-12" style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;">
               <h3>Completed</h3>
                <p style="text-align: center;"><img src="images/icons-07.png" style="max-width: 75px;"></p>
                <p>Your Backround Check has been completed. Background checks are important to us, we take your safety seriously.</p>
            </div>
             
        </div>
      </div>--%>
    
    </div><!-- end div big row -->
        <div class="col-md-6"  style="border: solid; border-color: white;">
            <h2 >Background Check Status</h2> 
            <div class="row container" style="background-color: #ebebeb; margin-top: 1rem; overflow:auto !important; height:410px !important; border-radius:25px;" >
            <div class="col-md-12" style="margin-top: 1rem; ">
               <h3><asp:Label ID="backgroundCheckResultTitle" runat="server" Text=""></asp:Label></h3>
                <p style="text-align: center;"><asp:Image ID="image7" style="max-width: 100px;" ImageUrl="" class="img-fluid" runat="server" /></p>
                <p><asp:Label ID="backgroundCheckResultLbl" runat="server" Text=""></asp:Label><br><br><br></p>
            </div>
            </div>
            </div>
    
   
    <div class="row " style="margin-top: 1rem;">
        <div class="col-md-12"  >
            
          </div>
    </div><!-- end div big row -->  
    
    <div class="row container" style="margin-top: 1rem; background-color: #ebebeb; margin-bottom: 3rem; border-radius:25px;">
        <div class="col-md-12"  style=" margin-top: 1rem;">
            <h2>Your Rental Agreements</h2>
            <p>When you have a rental agreement, it will be indicated here. We hope you find your perfect housing match so that you can have some wonderful rental agreements.</p>
            <asp:Button ID="sampleAgreement" onClick="contract" style="margin-top: 1rem;" runat="server" Text="Sample Agreement" AutoPostBack="true" type="submit" class="btn"/><br/><br/>
          </div>
    </div><!-- end div big row -->  
    
    
    
</div> 
</div><!-- end div container! -->   

</asp:Content>

