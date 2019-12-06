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
          
         <%-- <div class="row">
            <div class="col">
              <label style="font-size: 28px" for="formGroupExampleInput">Add preferences to your search to find a place perfect for your specific needs.</label><br/><br />
                <label  style="font-size: 24px; color: black;" for="formGroupExampleInput">Search for...</label>
            </div>
             <!--end col-->
          </div> <!--end row class-->--%>
          
<%--          <div class="row">
            <div class="col-md-4" >at
              <p ><asp:CheckBox ID="singleRoomCheck" type=" checkbox" name="Single Room" value="Single Room" runat="server"></asp:Checkbox> Single Room<br>
               <asp:CheckBox ID="privateRoomCheck" type=" checkbox" name="Private Room" value="Private Room" runat="server"></asp:Checkbox> Private Room<br>
                <asp:CheckBox ID="privateAptCheck" type="checkbox" name="Private Apartment" value="Private Apartment" runat="server"></asp:Checkbox> Private Room<br></p>
            </div>--%>
          <%-- <div class="row">  
          <div class="col-md-4">
              <p><asp:CheckBox ID="furnishedCheck" type="checkbox" name="Furnished" value="y" runat="server"></asp:Checkbox>Furnished<br>
               <asp:CheckBox ID="privateBathroomCheck" type="checkbox" name="Private Bathroom" value="y" runat="server"></asp:Checkbox> Private Bathroom<br>
                <asp:CheckBox ID="closetCheck" type="checkbox" name="Closet/Storage Space" value="y" runat="server"></asp:Checkbox> Closet/ Storage Space<br></p>
            </div>
              <div class="col-md-4">
              <p ><asp:CheckBox ID="nonSmokerCheck" type="checkbox" name="Non-Smokers" value="y" runat="server"></asp:Checkbox> Non-Smokers<br>
               <asp:CheckBox ID="kitchenCheck" type="checkbox" name="Kitchen" value="y" runat="server"></asp:CheckBox> Kitchen<br>
                <asp:CheckBox ID="privateEntranceCheck" type="checkbox" name="Private Entrance" value="y" runat="server"></asp:Checkbox> Private Entrance
                  <br></p>
            </div>
             <!--end col-->
          </div> <!--end row class-->--%>
        
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
