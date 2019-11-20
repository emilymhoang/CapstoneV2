<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

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
              <asp:Textbox id="emailTextbox" runat="server" class="form-control" MaxLength="50" placeholder="example@example.com" type="email"></asp:Textbox>
              <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ErrorMessage="Required" AutoPostBack="true" ControlToValidate="emailTextbox" ForeColor="#B23325"></asp:RequiredFieldValidator>
            </div>
              <div class="col">
              <label for="formGroupExampleInput"></label>
            </div>
              </div>
                  <div class="row" >
            <div class="col-md-6">
              <label for="formGroupExampleInput">New Password</label>
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
              <label for="formGroupExampleInput">Confirm Password</label>
              <asp:Textbox type="password" ID="confirmPasswordTextbox" class="form-control" MaxLength="30" placeholder="Confirm Password" runat="server"></asp:Textbox>
                 <asp:RequiredFieldValidator ID="confirmPasswordRequiredFieldValidator" runat="server" ControlToValidate="confirmPasswordTextbox" ErrorMessage="Required" ForeColor="#B23325">Password is required.</asp:RequiredFieldValidator>
                 <asp:Label ID="resultmessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
              <div class="col">
              <label for="formGroupExampleInput"></label>
            </div>
              </div>

              <div class="row">
            <div class="col-md-6">
               <asp:Button ID="resetPassButton" class="btn" type="submit" style="float:left;" runat="server" Text="Reset Password" OnCommand="resetPass_Click" AutoPostBack ="true" ></asp:Button></div>
      
                </div>
              <div class="col">
              <label for="formGroupExampleInput"></label>
            </div>
  
      </div> <!--end container-->
    </section>
</asp:Content>

