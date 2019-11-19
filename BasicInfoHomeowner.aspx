<%@ Page Title="Basic Info Tenant" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BasicInfoHomeowner.aspx.cs" Inherits="BasicInfoHomeowner" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
        <h1>Tell us about yourself.</h1>
        <p>Let us find you the perfect housemate.</p>
                <div class="progress " >
                <div class="progress-bar progress-bar-striped " role="progressbar" style="width: 25%; " aria-valuenow="25" ></div>
               </div>
      </div>
    </header>

    <section id="creation" style="margin-top: 4rem;">
      <div class="container">
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">First Name</label>
              <asp:Textbox ID="firstNameTextbox" class="form-control" MaxLength="30" placeholder="First Name" runat="server" type="text"></asp:Textbox>
                <asp:RequiredFieldValidator ID="firstNameRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="firstNameTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
              <label for="formGroupExampleInput">Last Name</label>
              <asp:Textbox id="lastNameTextbox" class="form-control" MaxLength="30" placeholder="Last Name" runat="server" type="text"></asp:Textbox>
              <asp:RequiredFieldValidator ID="lastNameRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="lastNameTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div> <!--end col-->
          </div> <!--end row class-->
          <br>
          <div class="row">
            <div class="col">
             <label for="formGroupExampleInput">Gender</label>
              <asp:DropDownList ID="DropDownListGender" runat="server">
	               <asp:ListItem Value="-1">Select One</asp:ListItem> 
                  <asp:ListItem Value="O">I do not wish to Answer</asp:ListItem>
	                <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
    
                  </asp:DropDownList>
                <asp:Label ID="resultmessagegender" runat="server" ForeColor="Red"></asp:Label><br/>
              <asp:RequiredFieldValidator ID="genderRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="DropDownListGender" ForeColor="#B23325"></asp:RequiredFieldValidator>
                </div>
            <div class="col">
                 <div class="form-group">
              <label for="formGroupExampleInput">Date of Birth</label>
                    
              <asp:TextBox ID="dateOfBirthTextbox" ClientIDMode="Static" runat="server"  class="form-control" MaxLength="10" placeholder="DD-MM-YYYY" type="date"></asp:TextBox>
<%--CssClass="m-wrap span12 date form_datetime"--%>           
                     <asp:Label ID="resultmessagedob" runat="server" ForeColor="Red"></asp:Label>
              <asp:RequiredFieldValidator ID="dateOfBirthRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="dateOfBirthTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
<%--            <script type="text/javascript">
            $(function () {
            $('#dateOfBirthTextbox').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "mm/dd/yyyy",
                language: "tr"
            });
        });
            </script>--%>
                </div>            
             </div> <!--end col-->
          </div> <!--end row class-->

        <div class="row">
            <div class="col">
               <label for="formGroupExampleInput">Email</label>
              <asp:Textbox id="emailTextbox" runat="server" class="form-control" MaxLength="50" placeholder="example@example.com" type="email"></asp:Textbox>
              <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ErrorMessage="Required" AutoPostBack="true" ControlToValidate="emailTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
           <div class="col">
              <label for="formGroupExampleInput">Confirm Email</label>
              <asp:Textbox id="confirmEmailTextbox" runat="server" class="form-control" MaxLength="50" placeholder="example@example.com" type="email"></asp:Textbox>
              <asp:Label ID="resultmessage" runat="server" ForeColor="Red"></asp:Label>
               <asp:Label ID="emailLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
                
               <asp:RequiredFieldValidator ID="confirmRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="confirmEmailTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div> <!--end col-->
          </div> <!--end row class-->
        <br>
            <br>
          <div class="row">
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
              <asp:Textbox id="phoneNumberTextbox" class="form-control" MaxLength="13" onKeyup="addFormat(this)" placeholder="(xxx)xxx-xxxx" runat="server" type="tel"></asp:Textbox>
              <asp:RequiredFieldValidator ID="phoneNumberRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="phoneNumberTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
              <div class="col">
                   <label for="formGroupExampleInput">Host Bio</label>
                   <asp:Textbox id="HostBioTextbox" runat="server" TextMode="MultiLine" class="form-control" style="height:100px; width:550px;" MaxLength="300" placeholder="Ex. I am retired and live at home. I have an empty furnished basement that I am looking to fill and am hoping to find someone who will help with chores around my house." type="text"></asp:Textbox>
                   <asp:Label ID="result" runat="server" ForeColor="Red"></asp:Label>
                   <asp:RequiredFieldValidator ID="BioRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="HostBioTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
           
             </div>
          <!--end col-->
          </div> <!--end row class-->
        <br>
        
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
             <div class="col-md-6"><asp:Button ID ="populatebutton" class="btn" Text ="Populate" type="submit" onClick="populate" style="float: right;" runat="server" CausesValidation="false"></asp:Button></div>
             <div class="col-md-6"><asp:Button ID ="nextButton" class="btn" Text ="Next" type="submit" onClick="submitBasicInfo" AutoPostBack="true" style="float: right;" runat="server"></asp:Button></div>
            
        </div>     
      </div> <!--end container-->
    </section>
</asp:Content>
