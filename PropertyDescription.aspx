<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PropertyDescription.aspx.cs" Inherits="PropertyDescription" %>

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

</style>   
      <head>
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

<style>
@media only screen and (min-width: 900px) {
    .prop{
        margin-top: 180px;
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
    
    
</head>
<div  class="container">
    <div class=" fixed-top navbar-expand-lg " style="background-color: white;" id="custom-nav">
    	<div class="row" >
        <div class="col-md-3"> 
       		<a href="index.html"><img src="images/logo-01.png" alt="Room Magnet Logo" class="img-fluid" style="margin-left: 1em; max-width: 100px;"></a> 
        </div> <!-- end div header left - logo -->       
        
        <div class="col-md-9 navhome" style="text-align: right;"><!-- start nav header right -->   	
           
               <a href="#" class="btn btnb">Get Started</a>
           
               <a href="#" class="btn btnb">My Account</a>
           
               
          
            <nav ><ul class="nav justify-content-end">
             
              <li class="nav-item ">
                <a class="nav-link " href="#" style="font-family: 'Oswald', sans-serif; color: #756664; font-size: 16px;">Home-Owners</a>
              </li>
                
                <li class="nav-item">
                <a class="nav-link" href="#" style="font-family: 'Oswald', sans-serif; color: #756664; font-size: 16px;">Tenants</a>
              </li>
               
              
                
                <li class="nav-item">
                <a class="nav-link" href="#" style="font-family: 'Oswald', sans-serif; color: #756664; font-size: 16px;">FAQ</a>
              </li>
            </ul>   
        </nav> 
            </div>
        </div> <!-- end nav row -->  
     </div>  <!-- end div navbar -->
     

  <div class="row fixed-top" style="margin-top: 6.35rem; background-color: white; ">
    <div class="col-md-1" >
      <a href class="btn" style="margin-top: 1.5rem; margin-left: .5rem;">Back</a>
      </div>
    <div class="col-md-8" style="margin-top: 1rem; "> 
          <h1><asp:Label runat="server" Text = "Homeowner's Property" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="PropertyHeaderTextbox"></asp:Label><img src="images/icons-07.png" style="max-width: 30px;" alt="background check approved icon"></h1> 
        </div> <!--end col-->
      <div class="col-md-3" style="margin-top: 1.5rem; "> 
          <p style=" float: center; "><a href="#"><img src="images/badges-11.png" style="max-width: 100px;" alt="message icon"></a>
            <a href="#"><img src="images/badges-12.png" style="max-width: 90px;" alt="favorite icon"></a> </p>
        </div> <!--end col-->
    </div><!-- end div row -->  
    
    
    <div class="row prop" style="border-bottom: solid; border-bottom-width: 1px; ">
        <div class="col-md-6" >
            <h2> <asp:Label runat="server"  style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="lblResultName" Text = "Property Name"></asp:Label></h2>
            <h5> <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultLocation" Text = "Property Location"></asp:Label></h5>     
            <h5> <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultPrice" Text = "Property Price"></asp:Label></h5>
            <p > <asp:Label runat="server" ID="lblResultDesc" style="font-family: 'Raleway', sans-serif; line-height: 1.3; font-size: 18px; max-width: 200px; min-width: 200px; word-wrap: break-word" Text = "The brief description of the property would go here."></asp:Label></p>
            <img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;">
        </div>
        
        <div class="col-md-6" style="margin-top: .5rem;  margin-bottom: 1rem;">
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">

                <div class="carousel-inner"> 
                          <div class="carousel-item active">
                            <img src="images/kitchen.jpeg"  class="d-block w-100">
                        </div>
                          <div class="carousel-item">
                            <img src="images/kitchen.jpeg"  class="d-block w-100">
                        </div>
                  <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                  </a>
                  <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                  </a>
                </div> 
            </div> 
        </div>
        
    </div><!-- end div row --> 
    
    
    <div class="row" style="margin-top: 1rem;">
        <div class="col-md-6" >
            <h2> <asp:Label runat="server" Text = "Host Name" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="lblHostName"></asp:Label> </h2>
            <h5> <asp:Label runat="server" Text = "Host " style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblHostTitle"></asp:Label>  </h5>
            <p> <asp:Label runat="server" Text = "The brief bio of a host would go here." style="font-family: 'Raleway', sans-serif; font-size: 18px;" ID="lblHostBio"></asp:Label>  </p>
            <img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;">
        </div>
        
        <div class="col-md-6" style="margin-top: .5rem;  margin-bottom: 1rem;">
             <div id="carousel2" class="carousel slide" data-ride="carousel">

                <div class="carousel-inner"> 
                          <div class="carousel-item active">
                            <img src="images/johnsmith1.jpeg"  class="d-block w-100">
                        </div>
                          <div class="carousel-item">
                            <img src="images/johnsmith1.jpeg"  class="d-block w-100">
                        </div>
                  <a class="carousel-control-prev" href="#carousel2" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                  </a>
                  <a class="carousel-control-next" href="#carousel2" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                  </a>
                </div> 
            </div> 
        </div>
        
    </div><!-- end div row --> 
    
    
    
</div> <!-- end div container! -->    

</asp:Content>