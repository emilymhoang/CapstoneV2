﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="PropertyRoomInfo.aspx.cs" Inherits="PropertyRoomInfo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link href="Content/bootstrap.css" rel="stylesheet" />
     <style type="text/css">   
    h1 {
        font-family: 'Oswald', sans-serif;
        
        font-size: 50px;
        }
    h4{
        font-family: 'Oswald', sans-serif;
        
        font-size: 40px;
    }

        .btn {
           font-family: 'Oswald', sans-serif;
           color: white; 
           font-size: 20px;
       }

        .paragraph{
            font-family: 'Oswald', sans-serif;
                color: #756664;
                font-size: 30px;
        }
        </style>

   <header style="margin-top: 8rem;">
      <div class="container">
        <h1>Tell us about the room</h1>
         <p>Let us find you the perfect housemate.</p>   
                <div class="progress " >
                <div class="progress-bar progress-bar-striped " role="progressbar" style="width: 90%; " aria-valuenow="90" ></div>
               </div>
      </div>
       
   
       
       
    </header>

    <section id="creation" style="margin-top: 4rem;">
      <div class="container">
          <div class="row">
            <div class="col">
             <label for="formGroupExampleInput">Room Picture*</label><br>
                <asp:FileUpload id="FileUploadControl" runat="server" />
                <asp:RequiredFieldValidator ID="fileUploadRequiredFieldValidator" runat="server" ControlToValidate="FileUploadControl" ErrorMessage="Required" ForeColor="#B23325">At least one profile picture is required.</asp:RequiredFieldValidator>
                <br /><br />

            </div>
            <div class="col">
             <label for="formGroupExampleInput">Room Picture 2</label><br>
                <asp:FileUpload id="FileUpload2" runat="server" />
                 <br /><br />

              </div>
            <div class="col">
             <label for="formGroupExampleInput">Room Picture 3</label><br>
                <asp:FileUpload id="FileUpload3" runat="server" />
                <br /><br />

            
            </div> <!--end col-->
          </div> <!--end row class-->
          
          
          
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Monthly Price</label>
                <script> 
                 function setTwoNumberDecimal(event) {
                    this.value = parseFloat(this.value).toFixed(2);
                    }
                </script>
                <asp:TextBox ID="monthlyPriceTextbox" class="form-control" runat="server" placeholder="Ex. 800.00" onchange="setTwoNumberDecimal" step="0.01" value="0.00" min="0" max="9999" type="number" maxlength="7" name="item[amount]"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="monthlyPriceRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="monthlyPriceTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
              
            <div class="col">
              <label for="formGroupExampleInput">Room Size</label>
              <asp:DropDownList ID="DropDownListSize" CssClass="form-control" runat="server">
                     <asp:ListItem Value="Small">Small</asp:ListItem>
                  <asp:ListItem Value="Medium">Medium</asp:ListItem>
                  <asp:ListItem Value="Large">Large</asp:ListItem>
</asp:DropDownList>
              <asp:RequiredFieldValidator ID="squareFootageRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="DropDownListSize" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div> <!--end col-->
              <div class="col"> 
                   <label for="formGroupExampleInput">Availability</label>
              <asp:DropDownList ID="DropDownListAvailability" CssClass="form-control" runat="server">
	<asp:ListItem Value='Y'>Yes</asp:ListItem>
    <asp:ListItem Value='N'>No</asp:ListItem>
                  </asp:DropDownList>
               <label for="formGroupExampleInput">Availability will allow you to hide the room when you find a match, and show it as available when you want to bring it back for a new tenant</label>
          
              <asp:RequiredFieldValidator ID="AvailabilityRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="DropDownListAvailability" ForeColor="#B23325"></asp:RequiredFieldValidator>
           

             </div>
          </div> <!--end row class-->
          <br>
          <div class="row">
          
            <div class="col">
          
              <label for="formGroupExampleInput">Property Room Title</label>
              <asp:Textbox ID="displayTextbox" type="text" class="form-control" placeholder="Ex. Basement bedroom near City" runat="server" MaxLength="75"></asp:Textbox>
                <br>
      
            </div>
         
            <%--<div class="col">
               <label for="formGroupExampleInput">Property Room Layout*</label>
              <asp:DropDownList ID="DropDownListRoom" runat="server">
    <asp:ListItem Value="Single Room">Single Room</asp:ListItem>
    <asp:ListItem Value="Shared Space">Shared Space</asp:ListItem>
</asp:DropDownList>
              </div>--%>
            <div class="col">
                 
                <asp:Label runat="server" id="StatusLabel" text=" " />
                  </div> <!--end col-->
          </div> <!--end row class-->
 <br>
            <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Property Description/Biography</label>
              <asp:Textbox ID="bioTextbox" class="form-control" type="text" TextMode="MultiLine" style="height:100px; width:1150px;" placeholder="Ex. Fully furnished basement bedroom with separate kitchen and lounge area. Two miles from metro and close to multiple shopping centers." runat="server" MaxLength="300"></asp:Textbox>
                <br>
            </div>
          </div> <!--end row class-->
             <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Does the space have a private bathroom?*</label>
              <asp:RadioButtonList ID="rbPrivateBr" runat="server">
                    <asp:ListItem Text="Yes" Value="y" />
                    <asp:ListItem Text="No" Value="n" />
            </asp:RadioButtonList>
            </div>
            <div class="col">
              <label for="formGroupExampleInput">Does the space have a private entrance?*</label>
              <asp:RadioButtonList ID="rbPrivateEntr" runat="server">
                    <asp:ListItem Text="Yes" Value="y" />
                    <asp:ListItem Text="No" Value="n" />
            </asp:RadioButtonList>
            </div> <!--end col-->
                 <div class="col">
              <label for="formGroupExampleInput">Does the space have a closet/ storage space?*</label>
              <asp:RadioButtonList ID="rbStorage" runat="server">
                    <asp:ListItem Text="Yes" Value="y" />
                    <asp:ListItem Text="No" Value="n" />
            </asp:RadioButtonList>
            </div> <!--end col-->
          </div> <!--end row class-->
        <br>
             <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Is the space furnished?*</label>
              <asp:RadioButtonList ID="rbFurnished" runat="server">
                    <asp:ListItem Text="Yes" Value="y" />
                    <asp:ListItem Text="No" Value="n" />
            </asp:RadioButtonList>
            </div>
            <div class="col">
              <label for="formGroupExampleInput">Do you smoke/ allow smokers?*</label>
              <asp:RadioButtonList ID="rbSmoke" runat="server">
                    <asp:ListItem Text="Yes" Value="y" />
                    <asp:ListItem Text="No" Value="n" />
            </asp:RadioButtonList>
            </div> <!--end col-->
                 <div class="col">
              <label for="formGroupExampleInput">Is there a personal kitchen?*</label>
              <asp:RadioButtonList ID="rbKitchen" runat="server">
                    <asp:ListItem Text="Yes" Value="y" />
                    <asp:ListItem Text="No" Value="n" />
            </asp:RadioButtonList>
            </div> <!--end col-->
              </div> <!--end col-->
          </div> <!--end row class-->
          <br>
        
              <div class="row">
                  
            
               </div>

          <br>

        <br>
        
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
             <div class="col-md-6"><asp:Button ID ="populatebutton" class="btn" Text ="Populate" type="submit" onClick="populate" style="float: right;" runat="server" CausesValidation="false"></asp:Button></div>
             <div class="col-md-6"><asp:Button ID ="nextButton" class="btn" Text ="Next" type="submit" onClick="submitPropRoom" style="float: right;" runat="server"></asp:Button></div>
            
        </div>     
        </div>
      </div> <!--end container-->

    </section>
</asp:Content>
