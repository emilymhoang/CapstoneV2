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
    <div class="col-md-6">
        <h1><asp:Label ID="dashboardTitle" runat="server" Text=""></asp:Label></h1>
      </div>
    <div class="col-md-6" style="float:right;">
        <asp:Button ID="logoutButton" onClick="logout" style="margin-top: 1rem; float:right;  margin-right:.5rem;" runat="server" Text="Logout" AutoPostBack="true" type="submit" class="btn"/>
        
        <a href="Search.aspx" class="btn " style="margin-top: 1rem;  margin-right:.5rem; float:right;">Search Properties</a>
        <a href="CreateLoginAdmin.aspx" class="btn " style="margin-top: 1rem;  margin-right:.5rem; float:right;">Add Admin Account</a>
      </div>
      
    </div><!-- end div row -->  
    
    
   <div class="row " style="margin-top: 2rem;">
    <div class="col-md-6" style="border: solid; border-color: white;">
        <div class="row">
            <div class="col-md-6">
               <h2 >Admin Data</h2> 
            </div>
        </div>
           <%--    begin file container--%>
        <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; overflow:auto !important; height:500px !important; border-radius:25px;" >
        <%--    end profile container--%>

            <%-- tableau start --%>
    <div class="col-md-12"  style="border: solid; border-color: white;">
    <h3 style="margin-top:1rem;">Revenue</h3>
    <div class="row " style="background-color: #ebebeb; ">
        <div class="col-md-6"  style=" margin-top: 1rem;">

            <div class='tableauPlaceholder' id='viz1575346278229' style='position: relative'><noscript><a href='#'><img alt=' ' src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Re&#47;Revenue_15753462301940&#47;Dashboard1&#47;1_rss.png' style='border: none' /></a></noscript><object class='tableauViz'  style='display:none;'><param name='host_url' value='https%3A%2F%2Fpublic.tableau.com%2F' /> <param name='embed_code_version' value='3' /> <param name='site_root' value='' /><param name='name' value='Revenue_15753462301940&#47;Dashboard1' /><param name='tabs' value='no' /><param name='toolbar' value='yes' /><param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Re&#47;Revenue_15753462301940&#47;Dashboard1&#47;1.png' /> <param name='animate_transition' value='yes' /><param name='display_static_image' value='yes' /><param name='display_spinner' value='yes' /><param name='display_overlay' value='yes' /><param name='display_count' value='yes' /><param name='filter' value='publish=yes' /></object></div>                <script type='text/javascript'>                    var divElement = document.getElementById('viz1575346278229');                    var vizElement = divElement.getElementsByTagName('object')[0];                    vizElement.style.width='527px';vizElement.style.height='429px';                    var scriptElement = document.createElement('script');                    scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js';                    vizElement.parentNode.insertBefore(scriptElement, vizElement);                </script>
        </div>
            </div>
        </div>


       



        </div>
      </div>



        <div class="col-md-6"  style="border: solid; border-color: white;">
            <h2 >Verify Background Checks</h2> 
            <div class="row" style="background-color: #ebebeb; margin-top: 1rem; margin-bottom: 1rem; overflow:auto !important; height:500px !important; border-radius:25px;" >
            <div class="col-md-12" style="margin-top: 1rem;">
            <asp:Label ID="backgroundChecklbl" runat="server"></asp:Label>
        <div class="list-group" style="margin-top: 1rem; height: 570px;">
        <asp:ListView id="lvBackgroundResults" runat="server" Visible="true" >
            <LayoutTemplate>
                <table id="tbl1" runat="server">
                    <tr id="itemPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <table style="margin-top: 1rem;">
                        <tr>
                            <td style="width: 150px">
                                <asp:Image ID="image7" style="object-fit: cover; width:100px; height:100px;" ImageUrl='<%#Eval("resultImageV2") %>' class="img-fluid" runat="server" />
                            </td>
                            <td style="width: 200px">
                            <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 30px;" ID="lblResultName" Text='<%#Eval("resultName") %>'></asp:Label> <asp:Label runat="server" Text=" "></asp:Label><asp:Image ID="backgroundcheck" ImageUrl='<%#Eval("backgroundCheckResult")%>' style="max-width: 30px; margin-bottom: 1rem;" class="img-fluid" runat="server" /></br>
                                <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px;" ID="Label3" Text='<%#Eval("resultPhone") %>'></asp:Label></br>
                                <asp:Label runat="server" ID="Label4" style="font-family: 'Raleway', sans-serif; line-height: 1.3; font-size: 18px;" Text='<%#Eval("resultEmail") %>'></asp:Label></br>
                            </td>
                            <td style="width: 100px">
                                <asp:Button runat="server" class="btna" ID="btnApprove" style="font-size: 18px;" AutoPostBack="true" OnClick="approveApplicant" Text="&#10003; Approve"/> 
                                <asp:Button runat="server" class="btna" style="margin-top: .25rem; font-size: 18px;" ID="btnReject" AutoPostBack="true" OnClick="rejectApplicant" Text="&#x02A2F; Reject"/>
                            </td>
                        </tr>
<%--                        <tr>
                            <td>
                                <asp:Button runat="server" class="btn" ID="btnApprove" AutoPostBack="true" OnClick="approveApplicant" Text="Approve"/>
                            </td>
                        </tr>--%>
                </table>
            </ItemTemplate>

        </asp:ListView>
    </div>
            </div>
            </div>
            </div>
      </div>      <!-- end big row -->
    

     <div class="col-md-12"  style="border: solid; border-color: white;">
    <div class="row " style="margin-top: 1rem; background-color: #ebebeb; margin-bottom: 3rem; overflow:auto !important; height:500px !important; border-radius:25px;">
        <div class="col-md-6"  style=" margin-top: 1rem;">
               <h4 >Host Age</h4>
            <div class='tableauPlaceholder' id='viz1574210700643' style='position: relative'><noscript><a href='#'><img alt=' ' src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Ho&#47;Hostsbyage-5yrs&#47;Dashboard1&#47;1_rss.png' style='border: none' /></a></noscript><object class='tableauViz'  style='display:none;'><param name='host_url' value='https%3A%2F%2Fpublic.tableau.com%2F' /> <param name='embed_code_version' value='3' /> <param name='site_root' value='' /><param name='name' value='Hostsbyage-5yrs&#47;Dashboard1' /><param name='tabs' value='no' /><param name='toolbar' value='yes' /><param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Ho&#47;Hostsbyage-5yrs&#47;Dashboard1&#47;1.png' /> <param name='animate_transition' value='yes' /><param name='display_static_image' value='yes' /><param name='display_spinner' value='yes' /><param name='display_overlay' value='yes' /><param name='display_count' value='yes' /><param name='filter' value='publish=yes' /></object></div>                <script type='text/javascript'>                    var divElement = document.getElementById('viz1574210700643');                    var vizElement = divElement.getElementsByTagName('object')[0];                    vizElement.style.width='500px';vizElement.style.height='427px';                    var scriptElement = document.createElement('script');                    scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js';                    vizElement.parentNode.insertBefore(scriptElement, vizElement);                </script></div>
             <div class="col-md-6"  style=" margin-top: 1rem;">
                  <h4 >Tenant Age</h4>
                 <div class='tableauPlaceholder' id='viz1574043308719' style='position: relative'><noscript><a href='#'><img alt=' ' src='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Nu&#47;NumberofTenents&#47;Dashboard1&#47;1_rss.png' style='border: none' /></a></noscript><object class='tableauViz'  style='display:none;'><param name='host_url' value='https%3A%2F%2Fpublic.tableau.com%2F' /> <param name='embed_code_version' value='3' /> <param name='site_root' value='' /><param name='name' value='NumberofTenents&#47;Dashboard1' /><param name='tabs' value='no' /><param name='toolbar' value='yes' /><param name='static_image' value='https:&#47;&#47;public.tableau.com&#47;static&#47;images&#47;Nu&#47;NumberofTenents&#47;Dashboard1&#47;1.png' /> <param name='animate_transition' value='yes' /><param name='display_static_image' value='yes' /><param name='display_spinner' value='yes' /><param name='display_overlay' value='yes' /><param name='display_count' value='yes' /><param name='filter' value='publish=yes' /></object></div>                <script type='text/javascript'>                    var divElement = document.getElementById('viz1574043308719');                    var vizElement = divElement.getElementsByTagName('object')[0];                    vizElement.style.width='500px';vizElement.style.height='427px';                    var scriptElement = document.createElement('script');                    scriptElement.src = 'https://public.tableau.com/javascripts/api/viz_v1.js';                    vizElement.parentNode.insertBefore(scriptElement, vizElement);                </script>
             </div>
             </div>
        </div>
<%-- tableau end --%>
    
    <div class="col-md-12"  style="border: solid; border-color: white;">
    <h2 >Search for Properties</h2>
    <div class="row " style="margin-top: 1rem; background-color: #ebebeb; margin-bottom: 3rem; overflow:auto !important; height:410px !important; border-radius:25px;">
        <div class="col-md-10"  style=" margin-top: 1rem;">
       <asp:Textbox ID="searchTextbox" type="text" style="font-size: 22px; height:40px;" class="form-control" placeholder="Enter a zipcode or a city e.g. Arlington" runat="server"></asp:Textbox>
              <asp:Label ID="lblInvalidSearch" runat="server"></asp:Label>
        </div>
        <div class="col-md-2">
                <asp:Button ID="searchButton" style="margin-top: 1rem;" onClick="search_Click" AutoPostBack="false" runat="server" Text="Search" class="btn"/>
        </div>
        <div class="list-group" style=" height: 500px;">
        <div style="margin-left: 1rem; margin-top:1rem;">
        <asp:ListView id="lvSearchResultsAdmin" runat="server" Visible="true" >

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
                                        <asp:Label runat="server" style="font-family: 'Oswald', sans-serif; font-size: 20px; color: #B23325" ID="lblShowHost" Text='<%#Eval("showHost") %>'></asp:Label> </br>
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
                                        <asp:Button runat="server" class="btn" ID="hideProperty" OnClick="hideProperties" AutoPostBack="true" Text="Mark as Unavailable"/>
                                        &nbsp;
                                        <asp:Button runat="server" class="btn" ID="btnViewProfile" onClick="viewProperty" Text="View Profile" />
                                         &nbsp;
                                        <asp:Button runat="server" class="btn" ID="btnHideHost" AutoPostBack="true" onClick="hideHost" Text="Hide Host"></asp:Button>
                                    </td
                                </tr>
                             </table>
                        </td>
                        <td>
                            <div class="row" style="margin:auto; margin-bottom: 1rem;" >
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
                              </div>
                        </td>
                    </tr>
                </table>

                
            </ItemTemplate>

        </asp:ListView>
    </div>
    </div><!-- end div big row -->  
</div><!-- end div big row -->  
</div><!-- end div container! -->
        </div>
            

</asp:Content>

