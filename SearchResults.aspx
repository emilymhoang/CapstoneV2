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
<div  class="container">
  <div class="row fixed-top" style="margin-top: 6.35rem; background-color: white; ">
    <div class="col-md-8">
      <h1 style="margin-left: 2rem;">Search for your perfect space.</h1>
      </div>
    <div class="col-md-4" style="margin-top: .3rem; ">
                <a href="Search.aspx" class="btn " style=" font-size: 22px;">Go Back to Search</a>
        </div> <!--end col-->
    </div><!-- end div row -->  
    
    
    <div class="row " style="margin-top: 12rem; border-bottom: solid; border-bottom-width: 1px; ">
        <div class="col-md-4" >
            <h2 class="list-group-item-heading">John Smith</h2>
            <h5>Falls Church, VA</h5>
            <p class="list-group-item-text">This is a room in an old home, but it's not haunted I swear. There is plenty of closet space and less than 10 miles from DC. There is free breakfast every morning and a cute garden outside.</p>
        
                        <img src="images/badges-09.png" style="max-width: 130px;">
                        <img src="images/badges-10.png" style="max-width: 130px;">
                        <img src="images/badges-08.png" style="max-width: 130px;">

        </div>
        <div class="col-md-2" style="margin-top: .5rem;">
            <img src="images/icons-07.png" style="max-width: 30px;">
        </div>
        <div class="col-md-5" style="margin-top: .5rem; float: right; margin-bottom: 1rem;">
            <a href="#"><img src="images/badges-11.png" style="max-width: 100px;"></a>
            <a href="#"><img src="images/badges-12.png" style="max-width: 90px;"></a>
            <a href="#"><img src="images/badges-13.png" style="max-width: 90px;"></a><br><br>
            <img src="images/rustic-wood-cornice.png" class="img-fluid">
        </div>
        
    </div><!-- end div row --> 
    
    
    <div class="row " style="margin-top: 2rem; border-bottom: solid; border-bottom-width: 1px; ">
        <div class="col-md-4" >
            <h2 class="list-group-item-heading">Mike Moore</h2>
            <h5>Falls Church, VA</h5>
            <p class="list-group-item-text">Sunny second floor bedroom with twin bed, shared bath, no cooking use hot pot for warm drinks and microwave of and common areas. 9 blocks from Falls Church Metro! One block from the 14th and 16th Street Bus. This lovely partly renovated, 50 yr old home is in a quiet neighborhood with a comfortable porch; can be your urban retreat</p>
            <img src="images/badges-09.png" style="max-width: 130px;">
                        <img src="images/badges-10.png" style="max-width: 130px;">
                        <img src="images/badges-08.png" style="max-width: 130px;">
        </div>
        <div class="col-md-2" style="margin-top: .5rem;">
            <img src="images/icons-07.png" style="max-width: 30px;">
        </div>
        <div class="col-md-5" style="margin-top: .5rem; float: right; margin-bottom: 1rem;">
            <a href="#"><img src="images/badges-11.png" style="max-width: 100px;"></a>
            <a href="#"><img src="images/badges-12.png" style="max-width: 90px;"></a>
            <a href="#"><img src="images/badges-13.png" style="max-width: 90px;"></a><br><br>
            <img src="images/kitchen.jpeg" class="img-fluid">
        </div>
        
    </div><!-- end div row --> 




    <div>
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
                             <table style="display:block;width:99.9%;clear:both">
                                 <tr>
                                     <td>
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="Label1" Text='<%#Eval("resultName") %>'></asp:Label> <asp:Label runat="server" Text=" "></asp:Label><asp:Image ID="Image1" ImageUrl='<%#Eval("backgroundCheckResult")%>' style="max-width: 35px; margin-bottom: 1rem;" class="img-fluid" runat="server" />
</br>
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
                                        <asp:Label runat="server" Text=" "></asp:Label></br> </br> </br> </br>
                                         </br>
                                    </td>
                                 </tr>   
                                <tr>
                                     <td>
                                        <asp:Button runat="server" class="btn" ID="btnFavorite" OnClick="FavoritesButton" Text="Favorite"/>
                                        &nbsp;
                                        <asp:Button runat="server" class="btn" ID="btnViewProfile" Text="View Profile" />
                                    </td
                                </tr>
                             </table>]\
                        </td>
                        <td>
                            <div class="row" style="margin:auto; margin-bottom: 1rem;" >
                                <div class="col-md-6" style="margin-top: 1rem;">
                                     <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                                        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                                    </ol>
                                    <div class="carousel-inner">
                                        <div class="row">
                                            <div class="carousel-item active">    
                                                <asp:Image ID="image4" ImageUrl='<%#Eval("resultimage1")%>' class="img-fluid" runat="server" />
                                                   </div>
                                            <div class="carousel-item ">
                                               <asp:Image ID="image5" ImageUrl='<%#Eval("resultimage2")%>' class="img-fluid" runat="server" />
                                                   </div>
                                            <div class="carousel-item ">                
                                                   <asp:Image ID="image6" ImageUrl='<%#Eval("resultimage3")%>' class="img-fluid" runat="server" />
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
                              </div>
                        </td>
                    </tr>
                </table>

                
            </ItemTemplate>

        </asp:ListView>
<%--            <asp:Button runat="server" class="btn" ID="btnRedirect" style="display: none;" Text="Favorite"/>
            <asp:Panel ID="Panel1" runat="server" CssClass="modalpopup">
                        <asp:Label style="font-family: 'Oswald', sans-serif;  font-size: 24px" ID="Label2" runat="server" Text="Label">Create a Message</asp:Label>
                        <asp:Button class="btn" ID="redirectButton" href="GetStarted.aspx" runat="server" Text="Create an Account" />
                        <asp:Button class="btn" ID="okButton" runat="server" Text="OK" /> <br/>
                </asp:Panel>
                <AjaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="btnRedirect" BackgroundCssClass="modalBackground" CancelControlID="OKButton">
                </AjaxToolkit:ModalPopupExtender>--%>
    </div>    
</div> <!-- end div container! -->   
</asp:Content>

