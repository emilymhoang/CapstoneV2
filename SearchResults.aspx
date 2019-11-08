<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="SearchResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div  class="container">
  <div class="row fixed-top" style="margin-top: 6.35rem; background-color: white; ">
    <div class="col-md-8">
      <h1 style="margin-left: 2rem;">Search for your perfect space.</h1>
      </div>
    <div class="col-md-4" style="margin-top: 1rem; ">
                <a href="Search.aspx" class="btn " style="margin-top: 1rem; font-size: 30px;">Go Back to Search</a>
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
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblResultName" Text='<%#Eval("resultName") %>'></asp:Label>
                        </td>
                        <td>
                            <div>
                                <asp:Button runat="server" ID="btnFavorite" Text="Favorite"/>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblResultLocation" Text='<%#Eval("resultLocation") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        </tr>
                       <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <div style="max-width: 200px; min-width: 200px; word-wrap: break-word">
                                            <asp:Label runat="server" ID="lblResultDesc" Text='<%#Eval("resultDescription") %>'></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblResultPrice" Text='<%#Eval("resultPrice") %>'></asp:Label>
                        </td>
                    </tr>
                    
                </table>
            </ItemTemplate>

        </asp:ListView>
    </div>

    
    
    
</div> <!-- end div container! -->   
</asp:Content>

