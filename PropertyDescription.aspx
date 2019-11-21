<%@ Page Title="Room Magnet Property" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PropertyDescription.aspx.cs" Inherits="PropertyDescription" %>

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
    <div class="col-md-1">
      <asp:Button runat="server" style="margin-top: 1rem; margin-left:.5rem;" class="btn" ID="backButton" onClick="goBack" Text="Back"></asp:Button>
      </div>
       <div class="col-md-8" style="margin-top: 1rem;"> 
          <h1><asp:Label runat="server" Text = "Homeowner's Property" style="font-family: 'Oswald', sans-serif; " ID="PropertyHeaderTextbox"></asp:Label></h1>
           <asp:Image ID="imgbackgroundCheck" style="max-width: 30px;" runat="server" />         
        </div> <!--end col-->
        <div class="col-md-3" style="margin-top: 1rem;"> 
            <asp:Button runat="server" class="btn" ID="Button1" OnClick="FavoriteClick" Text="Favorite"></asp:Button>      
        </div> <!--end col-->
    
    
<%--        <div class="col-md-1" style="margin-top: 1.5rem; "> 
        <asp:Button runat="server" class="btn" ID="btnFavorite" OnClick="FavoriteClick" Text="Favorite"></asp:Button> </p>
            </div>--%>
    </div><!-- end div row -->  
    
    
    <div class="row prop" style=" background-color: #ebebeb; margin-bottom: 3rem; border-radius:25px; ">
        <div class="col-md-6" >
            <h2> <asp:Label runat="server"  style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="lblPropName" Text = "Property Name"></asp:Label></h2>
            
            <h5> <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultLocation" Text = "Property Location"></asp:Label></h5>     
            <h5> <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultPrice" Text = "Property Price"></asp:Label></h5>
            <p> <asp:Label runat="server" ID="lblResultDesc" style="font-family: 'Raleway', sans-serif; line-height: 1.3; font-size: 18px; max-width: 200px; min-width: 200px; word-wrap: break-word" Text = "The brief description of the property would go here."></asp:Label></p>
                 <asp:Image ID="privateEntranceBadge" class="img-fluid" runat="server" Height="35" Width="130" />
                 <asp:Image ID="kitchenBadge" class="img-fluid" runat="server" Height="35" Width="130" />
                 <asp:Image ID="privateBathroomBadge" class="img-fluid" runat="server" Height="35" Width="130" />
                 <asp:Image ID="furnishBadge" class="img-fluid" runat="server" Height="35" Width="130" />
                 <asp:Image ID="storageBadge" class="img-fluid" runat="server" Height="35" Width="130" />
                 <asp:Image ID="smokerBadge" class="img-fluid" runat="server" Height="35" Width="130" />

            
            <%--<img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;">--%>
        </div>
        
        <div class="col-md-6" style="margin-top: .5rem;  margin-bottom: 1rem;">
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <br>
                <ol class="carousel-indicators">
                           <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                           <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                           <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner"> 
                          <div class="carousel-item active">
                            <asp:Image ID="image1" ImageUrl='<%#Eval("resultimage1")%>' style="height:300px;" runat ="server" />
                        </div>
                          <div class="carousel-item">
                            <asp:Image ID="image2" ImageUrl='<%#Eval("resultimage2")%>' style="height:300px;" runat ="server" />
                        </div>
                        <div class="carousel-item">
                            <asp:Image ID="image3" ImageUrl='<%#Eval("resultimage3")%>' style="height:300px;" runat ="server" />
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
    
    
<%--    <div class="row" style="margin-top: 1rem;">
        <div class="col-md-6" >
            <h2> <asp:Label runat="server" Text = "Host Name" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="lblHostName"></asp:Label> </h2>
            <h5> <asp:Label runat="server" Text = "Host " style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblHostTitle"></asp:Label>  </h5>
            <p> <asp:Label runat="server" Text = "The brief bio of a host would go here." style="font-family: 'Raleway', sans-serif; font-size: 18px;" ID="lblHostBio"></asp:Label>  </p>
            <img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;">
        </div>--%>
        
<%--        <div class="col-md-6" style="margin-top: .5rem;  margin-bottom: 1rem;">--%>
    <div class="row " style="margin-top: 1rem; background-color: #ebebeb; margin-bottom: 3rem; border-radius:25px; height:410px !important;">
            <div class="col-md-12" style="margin-top: 1rem;">
                <div class="row">
                      <div class="col-md-6" >
                            <h2> <asp:Label runat="server" Text = "Host Name" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="lblHostName"></asp:Label> </h2>
                          <%--  <h5> <asp:Label runat="server" Text = "Host " style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblHostTitle"></asp:Label>  </h5>--%>
                            <p> <asp:Label runat="server" Text = "The brief bio of a host would go here." style="font-family: 'Raleway', sans-serif; font-size: 18px;" ID="lblHostBio"></asp:Label>  </p>
                         <%--   <img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;"><img src="images/badges-03.png" style="max-width: 130px;">--%>
                          <img src="images/badges-10.png" style="max-width: 130px;" />
                      </div>
                       <div class="col-md-6" >
                            <asp:Image ID="image7" style="max-height:350px; margin-left:1rem;" runat="server" />
                       </div>
                </div>
          </div>
    </div><!-- end div big row -->  
<%--             <div id="carousel2" class="carousel slide" data-ride="carousel">

                <div class="carousel-inner"> 
                          <div class="carousel-item active">
                           <asp:Image ID="image4" ImageUrl="" class="img-fluid" runat ="server" />
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
            </div> --%>
        
        
<%--    </div><!-- end div row --> 

    
</div> <!-- end div container! -->   --%>
    <div class="row" style="background-color: #ebebeb; margin-bottom: 3rem; border-radius:25px;">
        <div class="col-md-12">
             <h2 style="margin-top:1rem;">Where We're Located</h2>

            
    <div id="googleMapsApi" style="float:center;">
       
         <script type="text/javascript" src="//maps.googleapis.com/maps/api/js?key=AIzaSyCoG7Yz9O6kPXgfXB8dk3S0Ehl0YZwn4r8&sensor=false&libraries=places,geometry"></script>
            <input id="pac-input" class="controls" type="text" placeholder="Search Box"/>
                <div class="container" id="map-canvas" style="height: 400px; width:100%;"></div>

        <script type="text/javascript">  
           
                    function init() {
                
                        var geocoder = new google.maps.Geocoder();
                        //will use this once pages are all linked up
                        //--code here--
                        //
                        var address = "<%= addressForMap %>";
                        var map;
                        var marker;
                        var circle;
                        var searchBox;
                
                        geocoder.geocode({ 'address': address }, function (results, status) {
                            if (status == google.maps.GeocoderStatus.OK) {

                                var startlat = results[0].geometry.location.lat();
                                var startlng = results[0].geometry.location.lng();

                                 map = new google.maps.Map(document.getElementById('map-canvas'), {
                                    center: {
                                        lat: startlat,
                                        lng: startlng
                                    },
                                    zoom: 12
                                });

                                marker = new google.maps.Marker({
                                    position: {
                                        lat: startlat,
                                        lng: startlng
                                    },
                                            map: map,
                                            draggable:true
                                });

                                 circle = new google.maps.Circle({
                                    map: map,
                                    radius: 4023,    // 2.5 miles in metres
                                    fillColor: '#AA0000'
                                 });

                                circle.bindTo('center', marker, 'position');
                                marker.setVisible(false);

                                searchBox = new google.maps.places.SearchBox(document.getElementById('pac-input'));
                                map.controls[google.maps.ControlPosition.TOP_CENTER].push(document.getElementById('pac-input'));

                                google.maps.event.addListener(searchBox, 'places_changed', function() {
                                searchBox.set('map', null);

                                var places = searchBox.getPlaces();

                                 var bounds = new google.maps.LatLngBounds();
                                 var i, place;
                                 for (i = 0; place = places[i]; i++) {
                                   (function(place) {
                                     var marker = new google.maps.Marker({

                                       position: place.geometry.location
                                     });
                                       marker.bindTo('map', searchBox, 'map');
                                       circle.bindTo('center', marker, 'position');
                                       marker.setVisible(false);
                                     google.maps.event.addListener(marker, 'map_changed', function() {
                                       if (!this.getMap()) {
                                         this.unbindAll();
                                       }
                                     });
                                     bounds.extend(place.geometry.location);


                                   }(place));

                                 }
                                 map.fitBounds(bounds);
                                 searchBox.set('map', map);
                                 map.setZoom(Math.min(map.getZoom(),12));

                               });


                            } else {
                                alert("Request failed.")
                            }
                        });
                
                 }
                 google.maps.event.addDomListener(window, 'load', init);
        
            </script>

        </div>


        </div>
    </div>
   
</div>
</asp:Content>