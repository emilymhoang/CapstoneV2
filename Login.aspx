<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
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
    <header style="margin-top: 8rem;">
      <div class="container"> 
        <h1 style="color: #756664;">Login to your account</h1>
      </div>
    </header>
    <section id="creation" style="margin-top: 4rem;font-family: 'Oswald', sans-serif; color: #756664; font-size: 30px;">
      <div class="container">
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">User Name</label>
              <asp:Textbox type="text" ID="userNameTextbox" class="form-control" MaxLength="30" placeholder="User Name" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="userNameRequiredFieldValidator" runat="server" ControlToValidate="usernameTextbox" ErrorMessage="Required" ForeColor="#B23325">User Name is required.</asp:RequiredFieldValidator>
            </div>
              <div class="col">
              <label for="formGroupExampleInput"></label>
            </div><!--end col-->
          </div> <!--end row class-->
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Password</label>
              <asp:Textbox type="password" ID="passwordTextbox" class="form-control" MaxLength="30" placeholder="Password" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="passwordRequiredFieldValidator" runat="server" ControlToValidate="passwordTextbox" ErrorMessage="Required" ForeColor="#B23325">Password is required.</asp:RequiredFieldValidator>
            </div>
              <div class="col">
              <label for="formGroupExampleInput"></label>
            </div>
             <!--end col-->
          </div> <!--end row class-->
                 <asp:Label ID="resultmessage" runat="server" Text="" ForeColor="Red"></asp:Label>
           <div class="row" style=""> 
             <div class="col-md-12" >   
                                  <asp:CheckBox ID="SaveLogin" Text="Remember Me" runat="server" oncheckedchanged="SaveLogin_CheckedChanged" style="font-family: 'Oswald', sans-serif; color: #756664; font-size: 20px;"/><br/>
                 <asp:Button ID="loginButton" class="btn" type="submit" style="float:left;" runat="server" Text="Login" OnCommand="submitLogin_Click" AutoPostBack ="true" ></asp:Button></div>
           <div class="row">
               <div class="col">
                   </div>
               </div>
               <%--<a href="ForgotPassword.aspx" style="font-family: 'Oswald', sans-serif; color: #756664; font-size: 20px;">Forgot Password?</a>--%>
            </div>     
      </div> <!--end container-->
    </section>
</asp:Content>
