<%@ Page Title="Edit Info Tenant" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProfileTenant.aspx.cs" Inherits="EditProfileTenant" %>


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
        <h1>Edit Profile</h1>
      </div>
    
    </header>

    <section id="creation" style="margin-top: 4rem; font-family: 'Oswald', sans-serif; color: #756664; font-size: 18px">
      <div class="container">
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">First Name</label>
              <asp:Textbox ID="firstNameTextbox" class="form-control" MaxLength="30" placeholder="First Name" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="firstNameRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="firstNameTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
              <label for="formGroupExampleInput">Last Name</label>
              <asp:Textbox id="lastNameTextbox" class="form-control" MaxLength="30" placeholder="Last Name" runat="server"></asp:Textbox>
              <asp:RequiredFieldValidator ID="lastNameRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="lastNameTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div> <!--end col-->
          </div> <!--end row class-->
          <br>
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Password</label>
              <asp:Textbox type="password" id="passwordTextbox" class="form-control" MaxLength="30" placeholder="Password" runat="server"></asp:Textbox>
              <asp:RequiredFieldValidator ID="passwordRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="passwordTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
              <label for="formGroupExampleInput">Your Password Must:<br>*contain at least 8 characters<br>*contain at least 1 number<br>*contain at least 1 uppercase letter<br>*contain at least 1 lower case letter </label>
             </div> <!--end col-->
          </div> <!--end row class-->
          <br>
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Email</label>
              <asp:Textbox id="emailTextbox" runat="server" class="form-control" MaxLength="50" placeholder="example@example.com" type="email"></asp:Textbox>
              <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="emailTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
                <asp:Label ID="resultmessage" runat="server" ForeColor="#53A39F"></asp:Label>  
                <asp:Label ID="emailLabel" runat="server" Text="" ForeColor="#53A39F"></asp:Label>
            </div>
            <div class="col">
              <label for="formGroupExampleInput">Phone Number</label>
                 <script> 
                     window.addFormat = function addFormat(f) {
        var r = /(\D+)/g,
            npa = '',
            nxx = '',
            last4 = '';
        f.value = f.value.replace(r, '');
        npa = f.value.substr(0, 3);
        nxx = f.value.substr(3, 3);
        last4 = f.value.substr(6, 4);
        f.value = '(' + npa + ') ' + nxx + '-' + last4;
    }
                 </script>
              <asp:Textbox id="phoneNumberTextbox" class="form-control" MaxLength="15" onKeyup="addFormat(this)" placeholder="(xxx)xxx-xxxx" runat="server" type="tel"></asp:Textbox>
              <asp:RequiredFieldValidator ID="phoneNumberRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="phoneNumberTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div> <!--end col-->
          </div> <!--end row class-->
        <br>
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Tenant Bio </label>
              <asp:Textbox id="TenantBioTextbox" runat="server" TextMode="MultiLine" class="form-control" style="height:100px; width:540px;" MaxLength="300" type="text"></asp:Textbox>
              <asp:Label ID="result" runat="server" ForeColor="Red"></asp:Label>
              <asp:RequiredFieldValidator ID="BioRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="TenantBioTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
             </div>
        
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
            
           
             <div class="col-md-6"><asp:Button ID ="saveChangesButton" class="btn" Text ="Save Changes" type="submit" onClick="saveChanges" style="float: right;" runat="server"></asp:Button>
                 <div class="col-md-6"><asp:Button ID="backbutton" class="btn" type="submit" style="float: right;" runat="server" Text="&#8249; Back" OnClick="Back_Click" CausesValidation="false" ValidateRequest="false"></asp:Button>

             </div>
            
        </div>     
      </div> 
           </div> <!--end container-->
    </section>
</asp:Content>
