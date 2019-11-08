<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <style type="text/css">
       h1 {
        font-family: 'Oswald', sans-serif;
        color: #CC6559;
        font-size: 50px;
        }

        .btn {
           font-family: 'Oswald', sans-serif;
           color: white; 
           font-size: 20px;
       }
        </style>

    <header style="margin-top: 8rem;">
      <div class="container">
        <h1>Search by City or ZIP Code</h1>
      </div>
       
       <div class="row">
           <div class="col-md-6 promar" >
           </div>
       </div>
       
       
    </header>
    <section id="creation" style="margin-top: 4rem; font-family: 'Oswald', sans-serif; color: #756664; font-size:20px">
      <div class="container">
          <div class="row">
            <div class="col">
              <asp:Textbox ID="searchTextbox" type="text" style="font-size: 30px; height:75px;" class="form-control" placeholder="Enter a zipcode or a city e.g. Arlington" runat="server"></asp:Textbox>
              <asp:Label ID="lblInvalidSearch" runat="server"></asp:Label>
            </div>
              <!--end col-->
          </div> <!--end row class-->
          <br>
          <div class="row">
            <div class="col">
              <label style="font-size: 32px" for="formGroupExampleInput">Add preferences to your search to find a place perfect for your specific needs</label><br/><br />
                <label  style="font-size: 30px; color: black;" for="formGroupExampleInput">Search for...</label>
            </div>
             <!--end col-->
          </div> <!--end row class-->
          <br>
          <div class="row">
            <div class="col">

              <asp:CheckBox ID="singleRoomCheck" type=" checkbox" name="Single Room" value="Single Room" runat="server"></asp:Checkbox> Single Room<br>
               <asp:CheckBox ID="privateRoomCheck" type=" checkbox" name="Private Room" value="Private Room" runat="server"></asp:Checkbox> Private Room<br>
                <asp:CheckBox ID="privateAptCheck" type="checkbox" name="Private Aprtment" value="Private Aprtment" runat="server"></asp:Checkbox> Private Room<br>
            </div>
              <div class="col">
              <asp:CheckBox ID="furnishedCheck" type="checkbox" name="Furnished" value="Furnished" runat="server"></asp:Checkbox>Furnished<br>
               <asp:CheckBox ID="privateBathroomCheck" type="checkbox" name="Private Bathroom" value="Private Bathroom" runat="server"></asp:Checkbox> Private Bathroom<br>
                <asp:CheckBox ID="closetCheck" type="checkbox" name="Closet/Storage Space" value="Closet/Storage Space" runat="server"></asp:Checkbox> Closet/ Storage Space<br>
            </div>
              <div class="col">
              <asp:CheckBox ID="nonSmokerCheck" type="checkbox" name="Non-Smokers" value="Non-Smokers" runat="server"></asp:Checkbox> Non-Smokers<br>
               <asp:CheckBox ID="petsCheck" type="checkbox" name="Pets" value="Pets" runat="server"></asp:CheckBox> Pets<br>
                <asp:CheckBox ID="noPetsCheck" type="checkbox" name="No Pets" value="No Pets" runat="server"></asp:Checkbox> No Pets<br>
            </div>
             <!--end col-->
          </div> <!--end row class-->
        <br>
        
        <div class="row" style="margin-bottom: 3rem;"> 
          <div class="col-md-6"></div>
            

             <div class="col-md-6"><asp:Button ID="searchButton" text="Submit" runat="server" class="btn" type="submit" onClick="search_Click" style="float: right;"></asp:Button></div>
            
        </div>
      </div> <!--end container-->


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

    </section>
</asp:Content>
