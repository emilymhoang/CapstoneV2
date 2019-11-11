<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="PropertyRoomInfo.aspx.cs" Inherits="PropertyRoomInfo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <header style="margin-top: 8rem;">
      <div class="container">
        <h1>Tell us about the room</h1>
                <div class="progress " >
                <div class="progress-bar progress-bar-striped " role="progressbar" style="width: 90%; " aria-valuenow="90" ></div>
               </div>
      </div>
       
   
       
       
    </header>

    <section id="creation" style="margin-top: 4rem;">
      <div class="container">
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Monthly Price</label>
              <asp:Textbox ID="monthlyPriceTextbox" class="form-control" MaxLength="10" placeholder="Ex. 800.00" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="monthlyPriceRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="monthlyPriceTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
              <label for="formGroupExampleInput">Square Footage</label>
              <asp:Textbox id="squareFootageTextbox" class="form-control" MaxLength="10" placeholder="Ex. 941" runat="server"></asp:Textbox>
              <asp:RequiredFieldValidator ID="squareFootageRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="squareFootageTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div> <!--end col-->
          </div> <!--end row class-->
          <br>
          <div class="row">
          
            <div class="col">
              <label for="formGroupExampleInput">Please briefly describe your Room*</label>
              <asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem Value="Single Room">Single Room</asp:ListItem>
                  <asp:ListItem Value="Shared Space">Shared Space</asp:ListItem>
</asp:DropDownList>
            </div>
         
            <div class="col">
             <label for="formGroupExampleInput">Availibility</label>
              <asp:DropDownList ID="DropDownListAvailibility" runat="server">
	<asp:ListItem Value='Y'>Yes</asp:ListItem>
    <asp:ListItem Value='N'>No</asp:ListItem>
                  </asp:DropDownList>
               
              <asp:RequiredFieldValidator ID="AvailibilityRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="DropDownListAvailibility" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
                <label for="formGroupExampleInput">Availability will allow you to hide the room when you find a match, and show it as available when you want to bring it back for a new tenant</label>
            </div> <!--end col-->
          </div> <!--end row class-->
 <br>
            <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">What best describes your property? (To be shown to potential Tenant's)*</label>
              <asp:Textbox ID="displayTextbox" class="form-control" placeholder="Ex. Basement bedroom near City" runat="server" MaxLength="200"></asp:Textbox>
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
              <label for="formGroupExampleInput">Do you have pets?*</label>
              <asp:RadioButtonList ID="rbPets" runat="server">
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
             <div class="col-md-6"><asp:Button ID ="nextButton" class="btn" Text ="Next>" type="submit" onClick="submitPropRoom" style="float: right;" runat="server"></asp:Button></div>
            
        </div>     
      </div> <!--end container-->
    </section>
</asp:Content>
