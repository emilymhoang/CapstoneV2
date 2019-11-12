<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>
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
        .btn {
           font-family: 'Oswald', sans-serif;
           color: white; 
           font-size: 20px;
       }
    </style>

<div class="container">
  <div class="row " style="margin-top: 7rem; ">
    <div class="col-md-9">
        <h1><asp:Label ID="dashboardTitle" runat="server" Text=""></asp:Label></h1>
      </div>
    <div class="col-md-3">
        <a href="Search.aspx" class="btn " style="margin-top: 1rem;">Search Properties</a>
        <asp:Button ID="logoutButton" onClick="logout" style="margin-top: 1rem;" runat="server" Text="Logout" AutoPostBack="true" type="submit" class="btn"/>

      </div>
    </div><!-- end div row -->  
    
    
   <div class="row " style="margin-top: 1rem;">
    <div class="col-md-6" style="border: solid; border-color: white;">
        <div class="row">
            <div class="col-md-6">
               <h2 >Admin Dashboard</h2> 
            </div>
        </div>
           <%--    begin file container--%>
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem;" >
            <div class="col-md-6" style="margin-top: 1rem;">
            </div>
             <div class="col-md-6" style="margin-top: 1rem;">
                <h3><asp:Label ID="nameTextbox" runat="server" Text="John Smith" BackColor="#ebebeb"></asp:Label></h3>
                 <p><asp:Label ID="usernameTextbox" runat="server" Text="JohnSmith1" BackColor="#ebebeb"></asp:Label></p>
            </div>

        <%--    end profile container--%>
        </div>
      </div>
        <div class="col-md-6"  style="border: solid; border-color: white;">
            <h2 >Verify Background Checks</h2> 
            <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; " >
            <div class="col-md-12" style="margin-top: 1rem; border-bottom: solid; border-bottom-width: 1px;">
               <div>
        <asp:ListView id="lvSearchResults" runat="server" Visible="true" >
            <LayoutTemplate>
                <h1>Background checks to be verified</h1>
                <table id="tbl1" runat="server">
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <table style="margin-top: 1rem; border-bottom: solid; width:1500px; border-bottom-width: 1px;">
                    <tr>
                        <td>
                            <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="lblResult" Text='<%#Eval("resultName") %>'></asp:Label>
                        </td>
                        <td>
                            <div>
                                <asp:Button runat="server" class="btn" ID="btnFavorite" Text="Favorite"/>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultLocation" Text='<%#Eval("resultLocation") %>'></asp:Label>
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
                                            <asp:Label runat="server" ID="lblResultDesc" style="font-family: 'Raleway', sans-serif; line-height: 1.3; font-size: 18px;" Text='<%#Eval("resultDescription") %>'></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultPrice" Text='<%#Eval("resultPrice") %>'></asp:Label>
                        </td>
                    </tr>
                    
                </table>
            </ItemTemplate>

        </asp:ListView>
    </div>
            </div>
            </div>
            </div>
      </div>      <!-- end big row -->
    <div class="col-md-12"  style="border: solid; border-color: white;">
    <h2 >Search for properties</h2>
    <div class="row " style="margin-top: 1rem; background-color: #ebebeb; margin-bottom: 3rem;">
        <div class="col-md-12"  style=" margin-top: 1rem;">
        <asp:Textbox ID="searchTextbox" type="text" style="font-size: 30px; height:75px;" class="form-control" placeholder="Enter a zipcode or a city e.g. Arlington" runat="server"></asp:Textbox>
        <asp:Label ID="lblInvalidSearch" runat="server"></asp:Label>
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>    
             <div class="col-md-6"><asp:Button ID="searchButton" text="Submit" runat="server" class="btn" type="submit" onClick="search_Click" style="float: right;"></asp:Button></div>
        </div>
        <div class="list-group" style="margin-top: 1rem;overflow:scroll; height: 500px;">
        <asp:ListView id="lvSearchResultsAdmin" runat="server" Visible="true" >
            <LayoutTemplate>
                <h1>Search Results</h1>
                <table id="tbl1" runat="server">
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <table style="margin-top: 1rem; border-bottom: solid; width:1500px; border-bottom-width: 1px;">
                    <tr>
                        <td>
                            <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="lblResultName" Text='<%#Eval("resultName") %>'></asp:Label>
                        </td>
                        <td>
                            <div>
                                <asp:Button runat="server" class="btn" ID="btnFavorite" Text="Favorite"/>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultLocation" Text='<%#Eval("resultLocation") %>'></asp:Label>
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
                                            <asp:Label runat="server" ID="lblResultDesc" style="font-family: 'Raleway', sans-serif; line-height: 1.3; font-size: 18px;" Text='<%#Eval("resultDescription") %>'></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="lblResultPrice" Text='<%#Eval("resultPrice") %>'></asp:Label>
                        </td>
                    </tr>
                  <tr>
                        <td>
                            <asp:Button ID="deleteButton" class="btn" type="submit" style="float: right;" runat="server" Text="Delete Property" OnCommand="deleteProperty" AutoPostBack ="true"></asp:Button>
                        </td>
                    </tr>
                    
                </table>
            </ItemTemplate>

        </asp:ListView>
          </div>
    </div><!-- end div big row -->  
</div><!-- end div big row -->  
</div><!-- end div container! -->   

</asp:Content>

