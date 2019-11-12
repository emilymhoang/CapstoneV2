<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateAccountSafety.aspx.cs" Inherits="CreateAccountSafety" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
<div  class="container">
     
    <div class="row" style="margin-top: 7rem;">
        <div class="col-md-12">
        <h1>Your safety is crucial to us.</h1>
        <p style="font-family: 'Oswald', sans-serif; color: #756664; font-size: 30px;">Let us find you the perfect space.</p>    
                <div class="progress " >
                <div class="progress-bar progress-bar-striped " role="progressbar" style="width: 75%; " aria-valuenow="75" ></div>
               </div>
        </div>

    </div><!-- end div row -->

    <div class="row" style="margin-top: 3rem;">
        <div class="col-md-12">
            <label for="formGroupExampleInput" class="paragraph">In order to provide our customers with the best, most secure living and housemate matching experience, 
                we ask that the home-owners and tenants alike go through a background check. This ensures a superior housemate matching matching process. 
                You can read more about our standards on our safety page, once you've completed your profile.<br />
            <br>An email with more details will be sent to your inbox shortly.<br />
            <br>Other users will be able to see the state of your background check process, just as you will be able to see theirs.<br/>
            <br>The following indicators will appear at the specified steps in the process:<br/></label>
        </div>

    </div><!-- end div row --> 
    
    <div class="row" style="margin-top: 1rem;">
        <div class="col-md-12">
           <h4><img src="images/icons-07.png" alt="completed symbol" style="max-width: 50px;"> Completed</h4>  
            <p class="paragraph" style="margin-left: 4rem;">This person has completed the background check process and has been cleared and approved by our standards.</p>
             <h4><img src="images/NC.png" alt="pending symbol" style="max-width: 50px;"> Not Completed</h4>  
            <p class="paragraph" style="margin-left: 4rem;">This person has not completed the background check process.</p>
        </div>

    </div><!-- end div row --> 

    <div class="row" style="margin-top: 1rem; margin-bottom: 3rem;">
        <div class="col-md-2 offset-10">
            <asp:Button ID ="UnderstandButton" class="btn" Text ="I understand. Take me to my Account!" type="submit" onClick="Understand" style="float: right;" runat="server"></asp:Button>
        </div>
    </div>
    
  
</div> <!-- end div container! -->    

</asp:Content>

