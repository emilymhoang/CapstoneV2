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
            
           font-size: 20px;
       }

        .form-control{
            height: 50px;
            font-size:20px;
        }
        </style>
    
      

       <div class="row" style=" background-image: url(images/francesca-tosolini-lLDh9JppH2c-unsplash.jpg); background-repeat: no-repeat; background-size:cover; ">
           <div class="col-md-12" style=" margin-top:9rem; margin-bottom:2rem; ">
              
               <div class="card" style="width:28rem; margin: auto;">
              
              <div class="card-body">
                <h1 class="card-title" style="color: #756664;">Login to Your Account</h1>
                <p class="card-text">Find your perfect home-sharing solution today.</p>
                  
                      <div class="row">
                        <div class="col">
                          <label for="formGroupExampleInput"></label>
                          <asp:Textbox type="text" ID="userNameTextbox" class="form-control" MaxLength="30" placeholder="User Name" runat="server"></asp:Textbox>
                            <asp:RequiredFieldValidator ID="userNameRequiredFieldValidator" runat="server" ControlToValidate="usernameTextbox" ErrorMessage="Required" style="font-family: 'Raleway', sans-serif; color: #B23325; font-size: 20px;">User Name is required.</asp:RequiredFieldValidator>
                             <label for="formGroupExampleInput"></label>
            
                        </div>
            
                      </div> <!--end row class-->
                      <div class="row">
                        <div class="col">
                          <label for="formGroupExampleInput"></label>
                          <asp:Textbox type="password" ID="passwordTextbox" class="form-control" MaxLength="30" placeholder="Password" runat="server"></asp:Textbox>
                            <asp:RequiredFieldValidator ID="passwordRequiredFieldValidator" runat="server" ControlToValidate="passwordTextbox" ErrorMessage="Required" style="font-family: 'Raleway', sans-serif; color: #B23325; font-size: 20px;">Password is required.</asp:RequiredFieldValidator>
                            <label for="formGroupExampleInput"></label>
                        </div>
             
                      </div> <!--end row class-->
                             <asp:Label ID="resultmessage" runat="server" Text="" style="font-family: 'Oswald', sans-serif; color: #B23325; font-size: 20px;"></asp:Label>
                       <div class="row" > 
                         <div class="col-md-12" >   
                                 
                            <asp:Button ID="loginButton" class="btn" type="submit" style="float:left;" runat="server" Text="Login" OnCommand="submitLogin_Click" AutoPostBack ="true" ></asp:Button></div><br /><br />
                            <asp:CheckBox ID="SaveLogin" Text="Remember Me" runat="server" oncheckedchanged="SaveLogin_CheckedChanged" style="font-family: 'raleway', sans-serif; color: #756664; font-size: 14px; margin-left:1rem;"/><br />
                        </div>     
                 

             
              </div>
            </div>

           </div>
       </div>   
          




      
    
</asp:Content>
