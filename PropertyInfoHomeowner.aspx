<%@ Page Title="Basic Info Tenant" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PropertyInfoHomeowner.aspx.cs" Inherits="PropertyInfoHomeowner" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
              <style type="text/css">
       h1 {
        font-family: 'Oswald', sans-serif;
        color: #CC6559;
        font-size: 50px;
        }

        .btn {
           font-family: 'Oswald', sans-serif;
           color: white; 
           font-size: 20px;
       }

        .form-control{
            height: 50px;
            font-size:20px;
        }
        </style>
   <header style="margin-top: 8rem;">
      <div class="container">
        <h1>Tell us about yourself.</h1>
        <p>Let us find you the perfect housemate.</p>   
          <div class="progress " >
                <div class="progress-bar progress-bar-striped " role="progressbar" style="width: 75%; " aria-valuenow="75" ></div>
               </div>
      </div>
     
    </header>

    <section id="creation" style="margin-top: 4rem; font-family: 'Oswald', sans-serif; color: #756664; font-size: 18px">
      <div class="container">
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">House Number*</label>
              <asp:Textbox ID="houseNumTextbox" class="form-control" placeholder="" runat="server" MaxLength="15"></asp:Textbox>
                 <asp:Label ID="propertyResult" runat="server" ForeColor="Red"></asp:Label>
                <asp:RequiredFieldValidator ID="HouseNumRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="HouseNumTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
              <label for="formGroupExampleInput">Street Name*</label>
              <asp:Textbox id="StreetTextbox" class="form-control" placeholder="" runat="server" MaxLength="30"></asp:Textbox>
                <asp:RequiredFieldValidator ID="StreetRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="StreetTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div> <!--end col-->
          </div> <!--end row class-->
          <br>
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">City*</label>
              <asp:Textbox id="cityTextbox" class="form-control" placeholder="" runat="server" MaxLength="40"></asp:Textbox>
                <asp:RequiredFieldValidator ID="cityRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="cityTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
            <br />
            <div class="col">
              <label for="formGroupExampleInput">State</label>
              <asp:DropDownList ID="DropDownListState" runat="server">
	<asp:ListItem Value="">Select a state</asp:ListItem>
    <asp:ListItem Value="AL">Alabama</asp:ListItem>
	<asp:ListItem Value="AK">Alaska</asp:ListItem>
	<asp:ListItem Value="AZ">Arizona</asp:ListItem>
	<asp:ListItem Value="AR">Arkansas</asp:ListItem>
	<asp:ListItem Value="CA">California</asp:ListItem>
	<asp:ListItem Value="CO">Colorado</asp:ListItem>
	<asp:ListItem Value="CT">Connecticut</asp:ListItem>
	<asp:ListItem Value="DC">District of Columbia</asp:ListItem>
	<asp:ListItem Value="DE">Delaware</asp:ListItem>
	<asp:ListItem Value="FL">Florida</asp:ListItem>
	<asp:ListItem Value="GA">Georgia</asp:ListItem>
	<asp:ListItem Value="HI">Hawaii</asp:ListItem>
	<asp:ListItem Value="ID">Idaho</asp:ListItem>
	<asp:ListItem Value="IL">Illinois</asp:ListItem>
	<asp:ListItem Value="IN">Indiana</asp:ListItem>
	<asp:ListItem Value="IA">Iowa</asp:ListItem>
	<asp:ListItem Value="KS">Kansas</asp:ListItem>
	<asp:ListItem Value="KY">Kentucky</asp:ListItem>
	<asp:ListItem Value="LA">Louisiana</asp:ListItem>
	<asp:ListItem Value="ME">Maine</asp:ListItem>
	<asp:ListItem Value="MD">Maryland</asp:ListItem>
	<asp:ListItem Value="MA">Massachusetts</asp:ListItem>
	<asp:ListItem Value="MI">Michigan</asp:ListItem>
	<asp:ListItem Value="MN">Minnesota</asp:ListItem>
	<asp:ListItem Value="MS">Mississippi</asp:ListItem>
	<asp:ListItem Value="MO">Missouri</asp:ListItem>
	<asp:ListItem Value="MT">Montana</asp:ListItem>
	<asp:ListItem Value="NE">Nebraska</asp:ListItem>
	<asp:ListItem Value="NV">Nevada</asp:ListItem>
	<asp:ListItem Value="NH">New Hampshire</asp:ListItem>
	<asp:ListItem Value="NJ">New Jersey</asp:ListItem>
	<asp:ListItem Value="NM">New Mexico</asp:ListItem>
	<asp:ListItem Value="NY">New York</asp:ListItem>
	<asp:ListItem Value="NC">North Carolina</asp:ListItem>
	<asp:ListItem Value="ND">North Dakota</asp:ListItem>
	<asp:ListItem Value="OH">Ohio</asp:ListItem>
	<asp:ListItem Value="OK">Oklahoma</asp:ListItem>
	<asp:ListItem Value="OR">Oregon</asp:ListItem>
	<asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
	<asp:ListItem Value="RI">Rhode Island</asp:ListItem>
	<asp:ListItem Value="SC">South Carolina</asp:ListItem>
	<asp:ListItem Value="SD">South Dakota</asp:ListItem>
	<asp:ListItem Value="TN">Tennessee</asp:ListItem>
	<asp:ListItem Value="TX">Texas</asp:ListItem>
	<asp:ListItem Value="UT">Utah</asp:ListItem>
	<asp:ListItem Value="VT">Vermont</asp:ListItem>
	<asp:ListItem Value="VA">Virginia</asp:ListItem>
	<asp:ListItem Value="WA">Washington</asp:ListItem>
	<asp:ListItem Value="WV">West Virginia</asp:ListItem>
	<asp:ListItem Value="WI">Wisconsin</asp:ListItem>
	<asp:ListItem Value="WY">Wyoming</asp:ListItem>

</asp:DropDownList>
            </div> <!--end col-->
              <div class="col">
              <label for="formGroupExampleInput">Zip*</label>
              <asp:Textbox id="zipTextbox" class="form-control" placeholder="" runat="server" MaxLength="9"></asp:Textbox>
                  <asp:RequiredFieldValidator ID="zipRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="zipTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
              <div class="col">
                <label for="formGroupExampleInput">Don't fret, only your city, state, and zip code will appear on your profile to potential tenants</label>
            </div> <!--end col-->
          </div> <!--end row class-->
          <br>
          <div class="row">
            <div class="col">
              
        

          </div> <!--end row class-->
            <div class="row">
            
          </div> <!--end row class-->
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
            
             <div class="col-md-6"><asp:Button ID ="submitPropInfoButton" class="btn" Text ="Next>" type="submit" onClick="submitPropInfo" style="float: right;" runat="server"></asp:Button></div>
            
        </div>     
      </div> <!--end container-->
    </section>
</asp:Content>