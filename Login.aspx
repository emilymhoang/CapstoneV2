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
    
      <div class="container"> 

          <div class="row">
                <div class="col-md-6">
                    <header style="margin-top: 8rem;">
        <h1 style="color: #756664;">Login to Your Account</h1>
          <p>Find your perfect home-sharing solution today.</p>
      
    </header>
    <section id="creation" style="margin-top: 4rem;font-family: 'Oswald', sans-serif; color: #756664; font-size: 30px;">
      <div class="container">
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">User Name</label>
              <asp:Textbox type="text" ID="userNameTextbox" class="form-control" MaxLength="30" placeholder="User Name" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="userNameRequiredFieldValidator" runat="server" ControlToValidate="usernameTextbox" ErrorMessage="Required" style="font-family: 'Oswald', sans-serif; color: #B23325; font-size: 20px;">User Name is required.</asp:RequiredFieldValidator>
                 <label for="formGroupExampleInput"></label>
            
            </div>
            
          </div> <!--end row class-->
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Password</label>
              <asp:Textbox type="password" ID="passwordTextbox" class="form-control" MaxLength="30" placeholder="Password" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="passwordRequiredFieldValidator" runat="server" ControlToValidate="passwordTextbox" ErrorMessage="Required" style="font-family: 'Oswald', sans-serif; color: #B23325; font-size: 20px;">Password is required.</asp:RequiredFieldValidator>
                <label for="formGroupExampleInput"></label>
            </div>
             
          </div> <!--end row class-->
                 <asp:Label ID="resultmessage" runat="server" Text="" style="font-family: 'Oswald', sans-serif; color: #B23325; font-size: 20px;"></asp:Label>
           <div class="row" style=""> 
             <div class="col-md-12" >   
                                 
                 <asp:Button ID="loginButton" class="btn" type="submit" style="float:left;" runat="server" Text="Login" OnCommand="submitLogin_Click" AutoPostBack ="true" ></asp:Button></div>
           <asp:CheckBox ID="SaveLogin" Text="Remember Me" runat="server" oncheckedchanged="SaveLogin_CheckedChanged" style="font-family: 'Oswald', sans-serif; color: #756664; font-size: 20px;"/>
            </div>     
      </div> <!--end container-->
    </section>

                </div>
                 <div class="col-md-6" style="margin-top:9rem;">
                    <img src="images/banner-technology-grandkids.jpg" class="img-fluid" style="border-radius:25px;"/>

                 </div>
          </div>

      
    </div>
</asp:Content>
