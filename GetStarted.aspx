<%@ Page Title="Basic Info Tenant" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GetStarted.aspx.cs" Inherits="GetStarted" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
  <section id="creation" style="margin-top: 4rem;">
      <div class="container">
   <header style="margin-top: 8rem;">
      <div class="container">
        <h1 style="text-align; center; color: #756664;">Welcome to the first step in finding your perfect housemate.</h1> <br />
        <p style="font-family: 'raleway', sans-serif; color: #756664; font-size: 22px; text-align; center;">Tell us some things about yourself so we can find the best option for you.</p><br />
          
           <div class="row" style="margin-top: 2rem; margin-bottom: 2rem;">
               <div class="col-md-2 offset-3">
                   <p style="text-align:center;"> <img src="images/icons-05.png"  style="max-width:100px;" alt="icon of a house">
                    <asp:Button ID="RentMyRoomButton"  class="btn" style=" margin-top: 1rem; Font-Size:22px;" runat="server" Text="Rent My Room" onClick = "RentMyRoom" AutoPostBack ="true"></asp:Button></p>
               </div>
               <div class="col-md-2 offset-1">
                  <p style="text-align:center;"> <img src="images/icons-06.png"  style="max-width:95px;" alt="icon of a magnifying glass"> 
                   <asp:Button ID="FindMyRoomButton" class="btn" style="margin-top: 1rem; Font-Size:22px;" runat="server" Text="Find My Room" OnClick ="FindMyRoom" AutoPostBack ="true"></asp:Button></p>
               </div>
             </div>



       </div>
    </header>
      </div> <!--end container-->
    </section>
</asp:Content>
