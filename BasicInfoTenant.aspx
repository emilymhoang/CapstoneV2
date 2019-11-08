<%@ Page Title="Basic Info Tenant" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BasicInfoTenant.aspx.cs" Inherits="BasicInfoTenant" %>


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

    <header style="margin-top: 8rem; font-family: 'Oswald', sans-serif; color: #756664;">
      <div class="container">
        <h1>Tell us about yourself.</h1>
        <p style="font-family: 'Oswald', sans-serif; color: #756664; font-size: 20px;">Let us find you the perfect space.</p>    
                <div class="progress " >
                <div class="progress-bar progress-bar-striped " role="progressbar" style="width: 33%; " aria-valuenow="33" ></div>
               </div>
      </div>
    </header>

    <section id="creation" style="margin-top: 4rem; font-family: 'Oswald', sans-serif; color: #756664; font-size: 25px;">
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
          <div class="row">
            <div class="col">
             <label for="formGroupExampleInput">Gender</label><br />
               <asp:DropDownList ID="DropDownListGender" runat="server">
	                <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                    <asp:ListItem Value="O">Other</asp:ListItem>
                  </asp:DropDownList>
              <asp:RequiredFieldValidator ID="genderRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="DropDownListGender" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
                 <div class="form-group">
              <label for="formGroupExampleInput">Date of Birth</label>
                    
              <asp:TextBox ID="dateOfBirthTextbox" ClientIDMode="Static" runat="server" CssClass="m-wrap span12 date form_datetime" class="form-control" MaxLength="10" placeholder="DD-MM-YYYY"></asp:TextBox>

<%--              <asp:Textbox id="dateOfBirthTextbox" class="form-control" MaxLength="10" placeholder="DD-MM-YYYY" runat="server"></asp:Textbox>--%>
              <asp:RequiredFieldValidator ID="dateOfBirthRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="dateOfBirthTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            <script type="text/javascript">
            $(function () {
            $('#dateOfBirthTextbox').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "mm/dd/yyyy",
                language: "tr"
            });
        });
            </script>
                </div>            
             </div> <!--end col-->
          </div> <!--end row class-->

        <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Email</label>
              <asp:Textbox id="emailTextbox" runat="server" class="form-control" MaxLength="50" placeholder="example@example.com"></asp:Textbox>
              <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="emailTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invaid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailTextBox"></asp:RegularExpressionValidator>             
            </div>
            <div class="col">
              <label for="formGroupExampleInput">Confirm Email</label>
              <asp:Textbox id="confirmEmailTextbox" runat="server" class="form-control" MaxLength="50" placeholder="example@example.com"></asp:Textbox>
              <asp:Label ID="resultmessage" runat="server" ForeColor="Red"></asp:Label>
              <asp:Label ID="emailLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
                
                <asp:RequiredFieldValidator ID="confirmRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="confirmEmailTextbox" ForeColor="#B23325" Display="Dynamic"></asp:RequiredFieldValidator>
            </div> <!--end col-->
          </div> <!--end row class-->
          <div class="row">
             <div class="col">
              <label for="formGroupExampleInput">Phone Number</label>
              <asp:Textbox id="phoneNumberTextbox" class="form-control" MaxLength="15" placeholder="xxx-xxx-xxxx" runat="server"></asp:Textbox>
              <asp:RequiredFieldValidator ID="phoneNumberRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="phoneNumberTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
              <div class="col">
              <asp:CheckBox ID="undergradCheck" type=" checkbox" name="Undergraduate Student" value="undergrad" runat="server"></asp:Checkbox> Undergraduate Student<br>
               <asp:CheckBox ID="gradCheck" type=" checkbox" name="Graduate Student" value="grad" runat="server"></asp:Checkbox> Graduate Student<br>
             </div> <!--end col-->
          </div> <!--end row class-->
                          
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
            <div class="col-md-6"><asp:Button ID ="populatebutton" class="btn" Text ="Populate" type="submit" onClick="populate" style="float: right;" runat="server" CausesValidation="false"></asp:Button></div>
             <div class="col-md-6"><asp:Button ID ="nextButton" class="btn" Text ="Next>" type="submit" onClick="submitBasicInfo" style="float: right;" runat="server" CausesValidation="true"></asp:Button></div>
        </div>     
      </div> <!--end container-->
    </section>
</asp:Content>
   
