<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <style type="text/css">
       h1 {
        font-family: 'Oswald', sans-serif;
        
        font-size: 50px;
        }

        .btn {
           font-family: 'Oswald', sans-serif;
           color: white; 
           font-size: 20px;
        body {
            background-image: url("images/young.jpeg");
        }
       }
        </style>
<%--    <div style="background-image: url(images/foldimg_A0_Rectangle_2_pattern.png); background-repeat: no-repeat; background-size:cover;">--%>
    
    <div class="row" style=" background-image: url(images/im3rd-media-CbZ4EDP__VQ-unsplash.jpg); background-repeat: no-repeat; background-size:cover; ">
           <div class="col-md-12" style=" margin-top:9rem; margin-bottom:2rem; ">
              
               <div class="card" style="width:28rem; margin: auto; margin-top:5rem; margin-bottom: 5rem;">
                  <div class="card-body">
                        <h1 class="card-title" style="color: #756664;">Search</h1>
                        <p class="card-text" style="font-size:20px;">By city or zip code.</p> <br /> 
                    
                     
                     
                     
                    

    <section id="creation">
      
          <div class="row">
            <div class="col-md-12">
              <asp:Textbox ID="searchTextbox" type="text" style="font-size: 20px; height:40px; font-family:'raleway';" class="form-control" placeholder="Enter a zipcode or a city e.g. Arlington" runat="server"></asp:Textbox>
              <asp:Label ID="lblInvalidSearch" runat="server"></asp:Label>
            </div>
              <!--end col-->
          </div> <!--end row class-->
          <br />
          
        
        <div class="row" style="margin-bottom: 3rem;"> 
         
             <div class="col-md-12"><asp:Button ID="searchButton" text="Search"  runat="server" class="btn" type="submit" onClick="search_Click" style="float: left; font-size: 20px;"></asp:Button></div>
            
        </div>
<%--          </div>--%>
        </section>
      


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
                            <asp:Label ID="lblName" runat="Server" Text='<%#Eval("cityCounty") %>' />
                        </td>
                    </tr>
                    <tr>
                        <th>state</th>
                        <th>rooms</th>
                        <th>price</th>
                        <th>street</th>
                    </tr>
                    <tr>
                        
                        <td>
                            <asp:Label ID="lblDescription" runat="Server" Text='<%#Eval("homeState") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblNumberBedrooms" runat="Server" Text='<%#Eval("numberOfRooms") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblPrice" runat="Server" Text='<%#Eval("priceRange") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblStreet" runat="Server" Text='<%#Eval("street") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblOther" runat="Server" Text='<%#Eval("zip") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="btnAddFav" Text="Add Favorite" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>

        </asp:ListView>
    </div>
          </div>

    </section>


                    
                     </div>
                </div>

           </div>

    </div>

</asp:Content>
