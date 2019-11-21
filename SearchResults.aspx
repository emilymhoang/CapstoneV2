<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="SearchResults" %>

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

    <header style="margin-top: 8rem;">
      <div class="container">
        <h1>Search for your perfect space</h1>
          <br>
         <asp:Textbox ID="searchTextbox" type="text" style="font-size: 28px; height:60px;" class="form-control" placeholder="Enter a zipcode or a city e.g. Arlington" runat="server"></asp:Textbox>
              <asp:Label ID="lblInvalidSearch" runat="server"></asp:Label>
               </div>
    </header>

    <div  class="container">
     <div class="row">
            <div class="col">
              <label style="font-size: 28px" for="formGroupExampleInput">Add preferences to your search to find a place perfect for your specific needs.</label><br/><br />
                <label  style="font-size: 24px; color: black;" for="formGroupExampleInput">Search for...</label>
            </div>
             <!--end col-->
          </div> <!--end row class-->
          
          <%--<div class="row">
            <div class="col-md-4" >
              <p ><asp:CheckBox ID="singleRoomCheck" type=" checkbox" name="Single Room" value="Single Room" runat="server"></asp:Checkbox> Single Room<br>
               <asp:CheckBox ID="privateRoomCheck" type=" checkbox" name="Private Room" value="Private Room" runat="server"></asp:Checkbox> Private Room<br>
                <asp:CheckBox ID="privateAptCheck" type="checkbox" name="Private Apartment" value="Private Apartment" runat="server"></asp:Checkbox> Private Room<br></p>
            </div>
              </div>--%>
    
           <div class="row">  
          <div class="col-md-4">
              <h5><asp:CheckBox ID="furnishedCheck" type="checkbox" name="Furnished" value="y" runat="server"></asp:Checkbox>Furnished<br>
               <asp:CheckBox ID="privateBathroomCheck" type="checkbox" name="Private Bathroom" value="y" runat="server"></asp:Checkbox> Private Bathroom<br>
                <asp:CheckBox ID="closetCheck" type="checkbox" name="Closet/Storage Space" value="y" runat="server"></asp:Checkbox> Closet/ Storage Space<br></h5>
            </div>
              <div class="col-md-4">
              <h5><asp:CheckBox ID="nonSmokerCheck" type="checkbox" name="Non-Smokers" value="y" runat="server"></asp:Checkbox> Non-Smokers<br>
               <asp:CheckBox ID="kitchenCheck" type="checkbox" name="Kitchen" value="y" runat="server"></asp:CheckBox> Kitchen<br>
                <asp:CheckBox ID="privateEntranceCheck" type="checkbox" name="Private Entrance" value="y" runat="server"></asp:Checkbox> Private Entrance
                  <br></h5>
            </div>
               <div class="col-md-4">
              <p >
                  <asp:Button runat="server" class="btn" Text="Filter Results" ID="btnFilterResults" OnClick="btnFilterResults_Click" />
              </p>
            </div>
             <!--end col-->
          </div> <!--end row class-->
        </div>

<p>
  <label for="amount">Price range:</label>
  <input type="text" id="amount" readonly style="border:0; color:#f6931f; font-weight:bold;">
</p>
 
<div id="slider-range"></div>

  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $( function() {
    $( "#slider-range" ).slider({
      range: true,
      min: 0,
      max: 500,
      values: [ 75, 300 ],
      slide: function( event, ui ) {
        $( "#amount" ).val( "$" + ui.values[ 0 ] + " - $" + ui.values[ 1 ] );
      }
    });
    $( "#amount" ).val( "$" + $( "#slider-range" ).slider( "values", 0 ) +
      " - $" + $( "#slider-range" ).slider( "values", 1 ) );
  } );
  </script>

        <div  class="container">

    <div style="margin-top: 6.35rem;">
        <asp:ListView id="lvSearchResults" runat="server" Visible="true" >


            <LayoutTemplate>
                <h1>Search Results</h1>
                <table id="tbl1" runat="server">
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <table style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;">
                    <tr>
                         <td style="width: 450px;">
                             <table>
                                 <tr>
                                     <td>
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="Label1" Text='<%#Eval("propertyTitle") %>'></asp:Label> <asp:Label runat="server" Text=" "></asp:Label>
</br>
                                    </td>
                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 25px;" ID="Label2" Text='<%#Eval("resultName") %>'></asp:Label>
                                         <asp:Image ID="Image1" ImageUrl='<%#Eval("backgroundCheckResult")%>' style="max-width: 25px; margin-bottom: 1rem;" class="img-fluid" runat="server" /></br>
                                    </td>
                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultLocation" Text='<%#Eval("resultLocation") %>'></asp:Label></br>
                                    </td>
                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label runat="server" ID="lblResultDesc" style="font-family: 'Raleway', sans-serif; line-height: 1.3; font-size: 18px; max-width: 200px; min-width: 200px; word-wrap: break-word;" Text='<%#Eval("resultDescription") %>'></asp:Label></br>
                                    </td>
                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultPrice" Text='<%#Eval("resultPrice") %>'></asp:Label> </br>
                                    </td>
                                </tr>
                                 <tr>
                                     <td>
                                        <asp:Image ID="privateEntranceBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="130" />
                                        <asp:Image ID="kitchenBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="130" />
                                        <asp:Image ID="privateBathroomBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="130" />
                                        <asp:Image ID="furnishBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="130" />
                                        <asp:Image ID="storageBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="130" />
                                        <asp:Image ID="smokerBadge" ImageUrl="" class="img-fluid" runat="server" Height="35" Width="130" />
                                     </td>
                                     <td>
                                        <asp:Label runat="server" Text=" "></asp:Label></br> </br> </br> </br> </br> </br></br>
                                         </br>
                                    </td>
                                 </tr>   
                                <tr>
                                     <td>
                                        <asp:Button runat="server" class="btn" ID="btnFavorite" OnClick="FavoritesButton" Text="Favorite"/>
                                        &nbsp;
                                        <asp:Button runat="server" class="btn" ID="btnViewProfile" Text="View Additional Info" OnClick="profileButton"/>
                                    </td
                                </tr>
                             </table>
                        </td>
                        <td>
                            <div class="row" style="margin:auto; margin-bottom: 1rem;" >
                              <center>
                                <div class="col-md-12" style="margin-top: 1rem;">
                                     <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                                    </ol>
                                    <div class="carousel-inner" style="width: 500px">
                                        <div class="row">
                                            <div class="carousel-item active">    
                                                <asp:Image ID="image4" style="object-fit: cover; width:500px; height:400px;" ImageUrl='<%#Eval("resultimage1")%>' class="img-fluid" runat="server" />
                                                   </div>
                                            <div class="carousel-item ">
                                               <asp:Image ID="image5" style="object-fit: cover; width:500px; height:400px;" ImageUrl='<%#Eval("resultimage2")%>' class="img-fluid" runat="server" />
                                                   </div>
                                            <div class="carousel-item ">                
                                                   <asp:Image ID="image6" style="object-fit: cover; width:500px; height:400px;" ImageUrl='<%#Eval("resultimage3")%>' class="img-fluid" runat="server" />
                                                </div>
                                        </div>
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
                                  </center>
                              </div>
                        </td>
                    </tr>
                </table>

                
            </ItemTemplate>

        </asp:ListView>
        </div>
</div> <!-- end div container! -->   
</asp:Content>

