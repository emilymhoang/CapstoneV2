<%@ Page Title="Basic Info Tenant" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateLoginHomeowner.aspx.cs" Inherits="CreateLoginHomeowner" %>


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
        <h1>Tell us about yourself.</h1>
        <p>Let us find you the perfect housemate.</p>
          <div class="progress " >
                <div class="progress-bar progress-bar-striped " role="progressbar" style="width: 50%; " aria-valuenow="50" ></div>
               </div>
      </div>
       
     
       
       
    </header>

    <section id="creation" style="margin-top: 4rem; font-family: 'raleway', sans-serif; color: #756664;">
      <div class="container">
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">User Name</label>
              <asp:Textbox type="text" ID="userNameTextbox" class="form-control" MaxLength="30" placeholder="User Name" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="userNameRequiredFieldValidator" runat="server" ControlToValidate="usernameTextbox" ErrorMessage="Required" ForeColor="#B23325">User Name is required.</asp:RequiredFieldValidator>
            <asp:Label ID="resultUser" runat="server" ForeColor="Red"></asp:Label>
            </div>
              <div class="col">
               <label for="formGroupExampleInput">Profile Picture</label><br>
                <asp:FileUpload id="FileUploadControlHost" runat="server" />
                <asp:RequiredFieldValidator ID="fileUploadRequiredFieldValidator" runat="server" ControlToValidate="FileUploadControlHost" ErrorMessage="Required" ForeColor="#B23325">Profile picture is required.</asp:RequiredFieldValidator>
                <br /><br />
                <asp:Label runat="server" id="StatusLabel" text=" " />
            </div><!--end col-->
          </div> <!--end row class-->
          <br>
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Password</label>
              <asp:Textbox type="password" ID="passwordTextbox" class="form-control" MaxLength="30" placeholder="Password" runat="server"></asp:Textbox>
                <asp:RequiredFieldValidator ID="passwordRequiredFieldValidator" runat="server" ControlToValidate="passwordTextbox" ErrorMessage="Required" ForeColor="#B23325">Password is required.</asp:RequiredFieldValidator>
            </div>
              <div class="col">
              <label for="formGroupExampleInput">Your Password Must:<br>*contain at least 8 characters<br>*contain at least 1 number<br>*contain at least 1 uppercase letter<br>*contain at least 1 lower case letter </label>
            </div>
             <!--end col-->
          </div> <!--end row class-->
          <br>
          <div class="row">
            <div class="col">
              <label for="formGroupExampleInput">Confirm Password</label>
              <asp:Textbox type="password" ID="confirmPasswordTextbox" class="form-control" MaxLength="30" placeholder="Confirm Password" runat="server"></asp:Textbox>
                 <asp:RequiredFieldValidator ID="comfirmPasswordRequiredFieldValidator" runat="server" ControlToValidate="confirmPasswordTextbox" ErrorMessage="RequiredFieldValidator" ForeColor="#B23325">Password is required.</asp:RequiredFieldValidator>
                <asp:Label ID="resultmessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
              <div class="col">
              <label for="formGroupExampleInput"></label>
            </div>
             <!--end col-->
          </div> <!--end row class-->
        <br>
        
        <div class="row" style="margin-bottom: 3rem;"> 
            <div class="col-md-4"><asp:Button ID="nextButton" class="btn" type="submit" style="float: right;" runat="server" Text="Next &#8250;" OnClick="submitLogin_Click"></asp:Button>
            <div class="col-md-4"><asp:Button ID="backbutton" class="btn" type="submit" style="float: right;" runat="server" Text="&#8249; Back" OnClick="Back_Click" CausesValidation="false" validaterequest="false"></asp:Button>

            </div>

             </div>
        </div>     
      </div> <!--end container-->
    </section>
</asp:Content>