﻿<%@ Page Title="Create Login Tenant" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateLoginTenant.aspx.cs" Inherits="CreateLoginTenant" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <style type="text/css">   
    h1 {
        font-family: 'Oswald', sans-serif;
        
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

    <header style="margin-top: 8rem; color: #756664;">
      <div class="container">
        <h1>Tell us about yourself.</h1>
        <p style="font-family:  color: #756664; font-size: 20px;">Let us find you the perfect space.</p>    
                <div class="progress " >
                <div class="progress-bar progress-bar-striped " role="progressbar" style="width: 66%; " aria-valuenow="66" ></div>
               </div>
      </div>
    </header>
   

    <section id="creation" style="margin-top: 4rem; font-family: 'raleway', sans-serif; color: #756664; font-size: 20px;">
      <div class="container">
          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
              <label for="formGroupExampleInput">User Name*</label>
              <asp:Textbox type="text" ID="userNameTextbox" class="form-control" MaxLength="30" placeholder="User Name" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="userNameRequiredFieldValidator" runat="server" ControlToValidate="usernameTextbox" ErrorMessage="Required" ForeColor="#B23325">User Name is required.</asp:RequiredFieldValidator>
            <asp:Label ID="resultUser" runat="server" ForeColor="Red"></asp:Label>
            </div>
              <div class="col-md-6">
              <label for="formGroupExampleInput">Profile Picture*</label><br>
                <asp:FileUpload id="FileUploadControl" runat="server" />
                <asp:RequiredFieldValidator ID="fileUploadRequiredFieldValidator" runat="server" ControlToValidate="FileUploadControl" ErrorMessage="Required" ForeColor="#B23325">Profile Picture is required.</asp:RequiredFieldValidator>
                <br /><br />
                <asp:Label runat="server" id="StatusLabel" text=" " />
            </div><!--end col-->
          </div> <!--end row class-->
          <div class="row" >
            <div class="col-md-6">
              <label for="formGroupExampleInput">Password*</label>
              <asp:Textbox type="password" ID="passwordTextbox" class="form-control" MaxLength="30" placeholder="Password" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="passwordRequiredFieldValidator" runat="server" ControlToValidate="passwordTextbox" ErrorMessage="Required" ForeColor="#B23325">Password is required.</asp:RequiredFieldValidator>
            </div>
              <div class="col-md-6">
              <label for="formGroupExampleInput">Your Password Must:<br>*contain at least 8 characters<br>*contain at least 1 number<br>*contain at least 1 uppercase letter<br>*contain at least 1 lower case letter </label>
            </div>
             <!--end col-->
          </div> <!--end row class-->
          <div class="row">
            <div class="col-md-6">
              <label for="formGroupExampleInput">Confirm Password*</label>
              <asp:Textbox type="password" ID="confirmPasswordTextbox" class="form-control" MaxLength="30" placeholder="Confirm Password" runat="server"></asp:Textbox>
                 <asp:RequiredFieldValidator ID="confirmPasswordRequiredFieldValidator" runat="server" ControlToValidate="confirmPasswordTextbox" ErrorMessage="Required" ForeColor="#B23325">Password is required.</asp:RequiredFieldValidator>
                 <asp:Label ID="resultmessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
              <div class="col">
              <label for="formGroupExampleInput"></label>
            </div>
             <!--end col--
          </div> <!--end row class-->
              <%--<div class="row">
              <div class="col-md-6">
                  
             </div> <!--end col-->
                  <div class="col">
              <label for="formGroupExampleInput"></label>
            </div>
          </div> <!--end row class-->--%>

         </div> 
       
          <div class="row" style="margin-bottom: 3rem; margin-left:1rem;"> 
        
            <div class="col-md-6 "><asp:Button ID ="backButton" class="btn" Text ="&#8249; Back" type="submit" onClick="goBack" style="float: right;" runat="server" CausesValidation="false" validaterequest="fasle"></asp:Button></div>
             <div class="col-md-6 "><asp:Button ID="next2Button" class="btn" type="submit" style="float: left;" runat="server" Text="Next &#8250;" OnCommand="submitLogin_Click" AutoPostBack ="true"></asp:Button></div>
            
        </div>     
     
        </div> <!--end container--> 
    </section>
    </asp:Content>
    