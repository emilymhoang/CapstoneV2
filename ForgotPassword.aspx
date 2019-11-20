<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        <h1 style="color: #756664;">Reset Your Password</h1>
      </div>
    </header>
    <section id="creation" style="margin-top: 4rem;font-family: 'Oswald', sans-serif; color: #756664; font-size: 30px;">
      <div class="container">
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Email</label>
              <asp:Textbox id="emailTextbox" runat="server" class="form-control" MaxLength="50" placeholder="" type="email"></asp:Textbox>
              <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ErrorMessage="Required" AutoPostBack="true" ControlToValidate="emailTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
           <div class="col">
              <label for="formGroupExampleInput"></label>
            </div>
               
              </div>
          <div class="row">
              <div class="col">
              <label for="formGroupExampleInput">Username</label>
              <asp:Textbox id="usernameTextbox" runat="server" class="form-control" MaxLength="50" placeholder="" type="text"></asp:Textbox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" AutoPostBack="true" ControlToValidate="usernameTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
              </div>
               <div class="col">
              <label for="formGroupExampleInput"></label>
            </div>
              </div>
                 <asp:Label ID="resultmessage" runat="server" Text="" ForeColor="Red"></asp:Label>
           <div class="row" style="margin-bottom: 3rem;"> 
         
             <div class="col-md-12" >      
                 <asp:Button ID="getPassButton" class="btn" type="submit" style="float:left;" runat="server" Text="Reset Password" OnCommand="getPass_Click" AutoPostBack ="true" ></asp:Button></div>
            </div>     
      </div> <!--end container-->
    </section>



</asp:Content>

