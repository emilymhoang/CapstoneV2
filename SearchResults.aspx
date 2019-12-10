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
        <h2>Search for Your Perfect Space</h2>
          <br>
         <div class="row">
          <div class="col">
          <asp:Textbox ID="searchTextbox" type="text" style="font-size: 20px; font-family:'raleway'; height:40px;" Width="800" class="form-control"  placeholder="Enter a zipcode or a city e.g. Arlington" runat="server"></asp:Textbox>
              <asp:Label ID="lblInvalidSearch" runat="server"></asp:Label>
          </div>
             <div class="col">
                <asp:Button ID="searchButton" text="Search"  runat="server" class="btn" type="submit" onClick="search_Click" style="float: left; font-size: 20px;"></asp:Button>
                 
              </div>
             </div>
          <br>
           <button class="btn " type="button" data-toggle="collapse" data-target="#collapseExample" aria-expanded="false" aria-controls="collapseExample" style="font-size: 20px;">&#43; Advanced Search </button>
         
      </div>
    </header>

    
    <div  class="container collapse" id="collapseExample">
     <div class="row" style="margin-top:1rem;">
            <div class="col">
              <label style="font-size: 22px;  font-family: 'raleway', sans-serif; " for="formGroupExampleInput">Add preferences to your search to find a place perfect for your specific needs...</label><br/><br />
                
            </div>
             <!--end col-->
          </div> <!--end row class-->
    
           <div class="row">  
          <div class="col-md-4">
              <p style="font-size:18px; line-height:26px;"><asp:CheckBox ID="furnishedCheck" type="checkbox" name="Furnished" value="y" runat="server"></asp:Checkbox> Furnished<br>
               <asp:CheckBox ID="privateBathroomCheck" type="checkbox" name="Private Bathroom" value="y" runat="server"></asp:Checkbox> Private Bathroom<br>
                <asp:CheckBox ID="closetCheck" type="checkbox" name="Closet/Storage Space" value="y" runat="server"></asp:Checkbox> Closet/ Storage Space<br></p>
            </div>
              <div class="col-md-4">
              <p style="font-size:18px; line-height:26px;"><asp:CheckBox ID="nonSmokerCheck" type="checkbox" name="Non-Smokers" value="y" runat="server"></asp:Checkbox> Non-Smokers<br>
               <asp:CheckBox ID="kitchenCheck" type="checkbox" name="Kitchen" value="y" runat="server"></asp:CheckBox> Kitchen<br>
                <asp:CheckBox ID="privateEntranceCheck" type="checkbox" name="Private Entrance" value="y" runat="server"></asp:Checkbox> Private Entrance
                  <br></p>
            </div>
              
            
           <div class="col-md-4">
               <p style="font-size:18px; line-height:16px;">
                  <label for="amount">Price Range:</label>
                  <%--<input type="text" id="amount" readonly style="border:0; color:black; font-weight:bold; margin-left:2rem; margin-right:2rem; width:500px;">--%>
                  <%--<asp:Label runat="server" ID="amount1" Width="500px"></asp:Label>--%>
                    
                       <asp:RadioButtonList runat="server" ID="rdoPriceList" RepeatDirection="Vertical" style="font-family: 'raleway', sans-serif; font-size:18px; line-height:16px;">
                        <asp:ListItem Value ="none"> No Preference</asp:ListItem>
                        <asp:ListItem Value="low"> $0 - $500</asp:ListItem>
                        <asp:ListItem Value="medium"> $501 - $999</asp:ListItem>
                        <asp:ListItem Value="high"> $1000+</asp:ListItem>
                    </asp:RadioButtonList>
                   <asp:Label runat="server" ID="lblInvalidFilterResults"></asp:Label>
                </p> 
           </div>
                <%--<div id="slider-range" style="width: 600px;  "></div>--%>
           
   
        </div>
        
        <div class="row" style="margin-top:1rem;">
            <div class="col-md-12">
                <p >
                  <asp:Button runat="server" class="btn" Text="Apply Filters" ID="Button1" style="font-size: 20px; float:left;" OnClick="btnFilterResults_Click" />
              </p>
            </div>
        </div>

    </div>



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
                <table style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px; margin-bottom:1rem;">
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
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 25px;" ID="Label2" Text='<%#Eval("resultName") %>'> </asp:Label>
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

                                     </td>
                                     <td>
                                        <asp:Label runat="server" Text=" "></asp:Label></br> </br> </br> </br> </br> </br></br>
                                         </br>
                                    </td>
                                 </tr>   
                             </table>
                        </td>
                        <td>
                            <table>
                                <tr>
                                     <td style="float:right;">
                                        <asp:Button runat="server" class="btn" ID="btnFavorite" OnClick="FavoritesButton" Text="&#10084; Favorite"/>
                                        &nbsp;
                                        <asp:Button runat="server" class="btn" ID="btnViewProfile" Text="&#43; View Additional Info" OnClick="profileButton"/>
                                    </td</tr>
                                <tr>
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
                                                <asp:Image ID="image4" style="object-fit: cover; width:500px; height:350px;" ImageUrl='<%#Eval("resultimage1")%>' class="img-fluid" runat="server" />
                                                   </div>
                                            <div class="carousel-item ">
                                               <asp:Image ID="image5" style="object-fit: cover; width:500px; height:350px;" ImageUrl='<%#Eval("resultimage2")%>' class="img-fluid" runat="server" />
                                                   </div>
                                            <div class="carousel-item ">                
                                                   <asp:Image ID="image6" style="object-fit: cover; width:500px; height:350px;" ImageUrl='<%#Eval("resultimage3")%>' class="img-fluid" runat="server" />
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
                        </td>
                    </tr>
                </table>

                
            </ItemTemplate>

        </asp:ListView>
        </div>
</div> <!-- end div container! -->   
</asp:Content>

