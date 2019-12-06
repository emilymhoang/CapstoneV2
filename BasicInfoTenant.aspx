<%@ Page Title="Basic Info Tenant" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BasicInfoTenant.aspx.cs" Inherits="BasicInfoTenant" %>


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
        <p>Let us find you the perfect space.</p>    
                <div class="progress " >
                <div class="progress-bar progress-bar-striped " role="progressbar" style="width: 33%; " aria-valuenow="33" ></div>
               </div>
      </div>
    </header>

    <section id="creation" style="margin-top: 4rem;">
      <div class="container">
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput" style="font-family:'raleway', sans-serif;">First Name*</label>
              <asp:Textbox ID="firstNameTextbox" class="form-control" MaxLength="30" placeholder="First Name" runat="server" type="text"></asp:Textbox>
                <asp:RequiredFieldValidator ID="firstNameRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="firstNameTextbox" ForeColor="#B23325" style="font-family:'raleway', sans-serif;"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
              <label for="formGroupExampleInput" style="font-family:'raleway', sans-serif;">Last Name*</label>
              <asp:Textbox id="lastNameTextbox" class="form-control" MaxLength="30" placeholder="Last Name" runat="server" type="text" style="font-family:'raleway', sans-serif;"></asp:Textbox>
              <asp:RequiredFieldValidator ID="lastNameRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="lastNameTextbox" ForeColor="#B23325" style="font-family:'raleway', sans-serif;"></asp:RequiredFieldValidator>
            </div> <!--end col-->
          </div> <!--end row class-->
          <div class="row">
            <div class="col">
             <label for="formGroupExampleInput" style="font-family:'raleway', sans-serif;">Gender*</label><br />
               <asp:DropDownList ID="DropDownListGender" CssClass="form-control" runat="server" AutoPostBack="true">
	               <asp:ListItem Value="-1"  style="font-family:'raleway', sans-serif;">Select One</asp:ListItem> 
                   <asp:ListItem Value="O"  style="font-family:'raleway', sans-serif;">I do not wish to answer</asp:ListItem>
                   <asp:ListItem Value="M"  style="font-family:'raleway', sans-serif;">Male</asp:ListItem>
                    <asp:ListItem Value="F" style="font-family:'raleway', sans-serif;">Female</asp:ListItem>
                
                  </asp:DropDownList> <br/>
                <asp:Label ID="resultmessagegender" runat="server" ForeColor="Red"></asp:Label><br/>
              <asp:RequiredFieldValidator ID="genderRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="DropDownListGender" ForeColor="#B23325"  style="font-family:'raleway' sans-serif;"></asp:RequiredFieldValidator>
            </div>
            <div class="col">
                 <div class="form-group">
              <label for="formGroupExampleInput" style="font-family:'raleway', sans-serif;">Date of Birth*</label>
                    
               <asp:TextBox ID="dateOfBirthTextbox" ClientIDMode="Static" runat="server"  class="form-control" MaxLength="10" placeholder="DD-MM-YYYY" type="date" style="font-family:'raleway', sans-serif;"></asp:TextBox>

<%--              <asp:Textbox id="dateOfBirthTextbox" class="form-control" MaxLength="10" placeholder="DD-MM-YYYY" runat="server"></asp:Textbox>--%>
              <asp:RequiredFieldValidator ID="dateOfBirthRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="dateOfBirthTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
           <asp:Label ID="resultmessagedob" Text="" runat="server" ForeColor="Red"></asp:Label>
         <%--<script type="text/javascript">
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

        <div class="row" style="margin-top: 2rem;">
            <div class="col">
              <label for="formGroupExampleInput" style="font-family:'raleway', sans-serif;">Email*</label>
              <asp:Textbox id="emailTextbox" style="font-family:'raleway', sans-serif;" runat="server" class="form-control" MaxLength="50" placeholder="example@example.com" type="email"></asp:Textbox>
              <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="emailTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
               <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="#B23325" ControlToValidate="emailTextBox"></asp:RegularExpressionValidator>     --%>        
            </div>
            <div class="col">
              <label for="formGroupExampleInput" style="font-family:'raleway', sans-serif;">Confirm Email*</label>
              <asp:Textbox id="confirmEmailTextbox" runat="server" class="form-control" MaxLength="50" placeholder="example@example.com" type="email" style="font-family:'raleway', sans-serif;"></asp:Textbox>
              <asp:Label ID="resultmessage" runat="server" ForeColor="Red"></asp:Label>
              <asp:Label ID="emailLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
                
                <asp:RequiredFieldValidator ID="confirmRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="confirmEmailTextbox" ForeColor="#B23325" Display="Dynamic"></asp:RequiredFieldValidator>
            </div> <!--end col-->
          </div> <!--end row class-->
          <div class="row" style="margin-top: 2rem;">
             <div class="col">
              <label for="formGroupExampleInput" style="font-family:'raleway', sans-serif;">Phone Number*</label>
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
              <asp:Textbox id="phoneNumberTextbox" style="font-family:'raleway', sans-serif;" class="form-control" MaxLength="17" placeholder="(xxx)xxx-xxxx" onKeyup="addFormat(this)" runat="server" type="tel"></asp:Textbox>
              <asp:RequiredFieldValidator ID="phoneNumberRequiredFieldValidator" runat="server" ErrorMessage="Required" ControlToValidate="phoneNumberTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
               
              </div>
              <div class="col">
                   <label for="formGroupExampleInput" style="font-family:'raleway', sans-serif;">Tenant Bio*</label>
              <asp:Textbox id="TenantBioTextbox" runat="server" TextMode="MultiLine" class="form-control" style="height:100px; width:550px;" MaxLength="300"  placeholder="Ex. I am a Junior Nursing student at James Madison University." type="text" ></asp:Textbox>
              <asp:Label ID="result" runat="server" ForeColor="Red"></asp:Label>
              <asp:RequiredFieldValidator ID="BioRequiredFieldValidator" runat="server" ErrorMessage="Required" style="font-family:'raleway', sans-serif;" ControlToValidate="TenantBioTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>            
             </div>
         </div> <!--end row class-->

              <div class="row">
                  <div class="col"> 
                  <p>Institution Level</p>
                 <p><asp:CheckBox ID="undergradCheck" type=" checkbox" name="Undergraduate Student" OnCheckedChanged = "undergradCheck_checkChanged"  value="undergrad" runat="server" AutoPostBack = "true" ></asp:Checkbox> Undergraduate Student<br>
                 <asp:Checkbox ID="gradCheck" type=" checkbox" name="Graduate Student" OnCheckedChanged = "gradCheck_checkChanged"  value="grad" runat="server" AutoPostBack = "true" style="font-family:'raleway', sans-serif;"></asp:Checkbox > Graduate Student<br>
                   <asp:Checkbox ID="NAcheck" type=" checkbox" name="Not Applicable" OnCheckedChanged ="NAcheck_checkChanged" value="NA" runat="server" AutoPostBack ="true" style="font-family:'raleway', sans-serif;"></asp:Checkbox > Not Applicable<br></p>
                </div>
                <div class="col">  
              <p>Chores/Tasks</p>
                  <p><asp:CheckBox ID="choresCheck" type=" checkbox" name="Willing to do Chores" value="chores" runat="server" style="font-family:'raleway', sans-serif;"></asp:Checkbox> Willing to do chores<br></p>
                </div>


             </div> <!--end col-->
         
                          
        <div class="row" style="margin-bottom: 3rem;"> 
          
            <div class="col-md-6"><asp:Button ID ="populatebutton" class="btn" Text ="Populate" type="submit" onClick="populate" style="float: right;" runat="server" CausesValidation="false"></asp:Button></div>
             <div class="col-md-6"><asp:Button ID ="nextButton" class="btn" Text ="Next" type="submit" AutoPostBack="true" onClick="submitBasicInfo" style="float: right;" runat="server" CausesValidation="true"></asp:Button></div>
        </div>     
      </div> <!--end container-->
    </section>
</asp:Content>
   
