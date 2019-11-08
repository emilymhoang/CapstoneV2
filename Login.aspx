<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

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
        <h1>Login to your account</h1>
        <p style="font-family: 'Oswald', sans-serif; color: #756664; font-size: 20px;">Let us find you the perfect space.</p> 
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
        
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
             <div class="col-md-6">
                 <asp:Label ID="resultmessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                 <asp:Button ID="loginButton" class="btn" type="submit" style="float: right;" runat="server" Text="Login" OnCommand="submitLogin_Click" AutoPostBack ="true"></asp:Button></div>
            
        </div>     
      </div> <!--end container-->
    </section>
</asp:Content>
