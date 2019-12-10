<%@ Page Title="Create Adminstrator" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateLoginAdmin.aspx.cs" Inherits="CreateLoginAdmin" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<style type="text/css">   
    h1 {
        font-family: 'Oswald', sans-serif;
        
        font-size: 50px;
        }
    h4{
        font-family: 'Oswald', sans-serif;
        
        font-size: 30px;
    }

        .btn {
           font-family: 'Oswald', sans-serif;
           color: white; 
           font-size: 20px;
       }

        .paragraph{
            font-family: 'Oswald', sans-serif;
                color: #756664;
                font-size: 20px;
        }
        </style>

   <header style="margin-top: 8rem;">
      <div class="container">
        <h1>Create Administrator Account</h1>
        <p>Please enter the new administrator's account information.</p>
         
               </div>
      
    </header>

    <section id="creation" style="margin-top: 4rem; font-family: 'raleway', sans-serif; color: #756664;">
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
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">User Name</label>
              <asp:Textbox type="text" ID="userNameTextbox" class="form-control" MaxLength="30" placeholder="User Name" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="userNameRequiredFieldValidator" runat="server" ControlToValidate="usernameTextbox" ErrorMessage="Required" ForeColor="#B23325">User Name is required.</asp:RequiredFieldValidator>
            <asp:Label ID="resultUser" runat="server" ForeColor="Red"></asp:Label>
            </div>
              <br /> 
              <div class="col">
                  </div>
              <%--<div class="col">--%>
            </div><!--end col-->
          
          <br>
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Password</label>
              <asp:Textbox type="password" ID="passwordTextbox" class="form-control" MaxLength="30" placeholder="Password" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="passwordRequiredFieldValidator" runat="server" ControlToValidate="passwordTextbox" ErrorMessage="Required" ForeColor="#B23325">Password is required.</asp:RequiredFieldValidator>
            </div>
              <br /> 
              <div class="col">
              <label for="formGroupExampleInput">Your Password Must:<br>*contain at least 8 characters<br>*contain at least 1 number<br>*contain at least 1 uppercase letter<br>*contain at least 1 lower case letter </label>
            </div>
              </div>
            <div class="row">
                <div class="col">
                          <label for="formGroupExampleInput">Confirm Password</label>
                          <asp:Textbox type="password" ID="confirmPasswordTextbox" class="form-control" MaxLength="30" placeholder="Confirm Password" runat="server"></asp:Textbox>
                             <asp:RequiredFieldValidator ID="comfirmPasswordRequiredFieldValidator" runat="server" ControlToValidate="confirmPasswordTextbox" ErrorMessage="RequiredFieldValidator" ForeColor="#B23325">Password is required.</asp:RequiredFieldValidator>
                            <asp:Label ID="resultmessage" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                <br /> 
              <div class="col">
                  </div>
              </div>

           
             <!--end col-->
         
          <div class="row">
            
              <div class="col">
              <label for="formGroupExampleInput"></label>
            </div>
             <!--end col-->
          </div> <!--end row class-->
        <br>
        
        <div class="row" style="margin-bottom: 3rem;"> 
          
<%--            <div class="col-md-4"><asp:Button ID ="populatebutton" class="btn" Text ="Populate" type="submit" onClick="populate" style="float: right;" runat="server" CausesValidation="false"></asp:Button>--%>
            <div class="col-md-3"><asp:Button ID="backbutton" class="btn" type="submit" style="float: left;" runat="server" Text="Back" OnClick="Back_Click" CausesValidation="false" validaterequest="false"></asp:Button>
                  <br /> 
             

             </div>
            <div class="col-md-4"><asp:Button ID="Submit" class="btn" type="submit" style="float: left;" runat="server" Text="Submit" OnClick="submitLogin_Click"></asp:Button><br><br><br>
            

            </div>
        </div>     
    
    </section>
</asp:Content>
