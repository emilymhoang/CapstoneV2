<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenantProfile.aspx.cs" Inherits="TenantProfile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <style>
        .modalBackground{
            background-color: black;
            filter:alpha(opacity=90) !important;
            opacity:0.6 ! important;
            z-index: 20;
        }
        .modalpopup{
            padding: 20px 0px 24px 10px;
            position: relative;
            width: 500px;
            height: 500px;
            background-color: white;
            border: 1px solid black;
        }

        #googleMapsApi{
            height: 400px;  
            width:100%;
            margin: 15px;  
            padding: 15px  
        }

        @media only screen and (min-width: 900px) {
    .prop{
        margin-top: 200px;
    }
} 
    
@media only screen and (max-width: 900px) {
    .prop{
        margin-top: 190px;
    }
}
    
@media only screen and (max-width: 885px) {
    .prop{
        margin-top: 220px;
    }
}

 @media only screen and (max-width: 800px) {
    .prop{
        margin-top: 220px;
    }
} 
@media only screen and (max-width: 765px) {
    .prop{
        margin-top: 310px;
    }
}    

</style> 
   
<meta charset="UTF-8">
<meta name="description" content="Room Magnet">
<meta name="keywords" content="room magnet, roommate, housing, matchmaking, house, apartment, living arrangement">
<meta name="author" content="Room Magnet">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<title>Room Magnet Property</title>

<!-- Bootstrap v4 -->
<link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" media="screen">
<!-- custom css -->
<link href="css/custom.css" rel="stylesheet" type="text/css" media="screen">
<link rel="shortcut icon" href="images/logo-02.png" type="image/x-icon"/>
<link href="https://fonts.googleapis.com/css?family=Oswald:400|Raleway:300&display=swap" rel="stylesheet">    

    
<div  class="container">
     
  <div class="row fixed-top" style="margin-top: 6.35rem; background-color: white; ">
    <div class="col-md-2">
      <asp:Button runat="server" style="margin-top: 1rem; margin-left:1rem;" class="btn" ID="backButton" onClick="goBack" Text="&#8249; Back"></asp:Button>
      </div>
       <div class="col-md-3" style="margin-top: 1rem;"> 
          <h1><asp:Label runat="server" Text = "Tenant's Profile" style="font-family: 'Oswald', sans-serif; " ID="PropertyHeaderTextbox"></asp:Label></h1>  
        </div> <!--end col-->

    
  
    </div><!-- end div row -->  

    <div class="row " style="margin-top: 13rem; background-color: #ebebeb; margin-bottom: 3rem; border-radius:25px; height:410px !important;">
            <div class="col-md-12" style="margin-top: 1rem;">
                <div class="row">
                      <div class="col-md-6" >
                            <h2> <asp:Label runat="server" Text = "Tenant Name" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="lblTenantName"></asp:Label>          <asp:Image ID="imgbackgroundCheck" style="max-width: 30px;" runat="server" />         
</h2>
                    
                            <p> <asp:Label runat="server" Text = "The brief bio of a Tenant would go here." style="font-family: 'Raleway', sans-serif; font-size: 18px;" ID="lblTenantBio"></asp:Label>  </p>
                         <%--   <img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;">--%>
                        <asp:Image ID="undergraduateBadge" style="max-width:200px;" runat="server" />
                        <asp:Image ID="graduateBadge" style="max-width:200px;" runat="server" />
                        <asp:Image ID="choresBadge" style="max-width:200px;" runat="server" />

                      </div>
                       <div class="col-md-6" >
                            <asp:Image ID="tenantProfPic" style="max-height:350px; max-width:500px; margin-left:1rem;" runat="server" />
                       </div>
                </div>
          </div>
    </div><!-- end div big row -->  
</div>
</asp:Content>

