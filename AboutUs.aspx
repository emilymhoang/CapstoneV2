<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <style type="text/css">       
    h3 {
        font-family: 'Oswald', sans-serif;
        color: #CC6559;
        }
        </style>

    <header style="margin-top: 8rem;">
      <div class="container">
        <h1 style="font-family: 'Oswald', sans-serif; color: #53A39F;">About Us</h1>
      </div>
    </header>

    <section id="creation" style="margin-top: 4rem; font-family: 'Oswald', sans-serif; color: #756664;">
      <div class="container">
          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>Why did we create RoomMagnet?</h3>
                <label for="formGroupExampleInput">RoomMagnet brings together a solution to two social problems that are of major concern to society and continue to escalate internationally.
The first is the cost of affordable housing. Costs for college students, interns and young professionals  continues to escalate at an alarming pace, making it more difficult to get a start on their careers.
Secondly, older adults and empty-nesters, as they get older, wish to age in place, and often need additional income and at times assistance with light domestic duties such as shopping, household duties, daily maintenance or just companionship.
Our goal is to bring professional and semi-professionals such as, graduate students, international students, doctoral and nursing interns as well as college students seeking affordable housing together with hosts who have extra room to share. Students can do light housekeeping and chores in exchange for reduced rent, while hosts enjoy having help available and earning income from their extra living space.</label>
            </div>
          </div> <!--end row class-->
          
          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>A common sense solution</h3>
                <label for="formGroupExampleInput">RoomMagnet connects tenants that have limited financial capital with hosts who wish to monetize their extra living space by having someone live in and assist either financially or in exchange for some light domestic duties.
How does RoomMagnet bring together two vastly different groups of people? We accomplish this by providing a beautifully designed, fully functional digital platform that matches tenants with hosts, enabling them to form a mutually beneficial relationship.
</label>
            </div>
          </div> <!--end row class-->


          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>Tenants</h3>
                <label for="formGroupExampleInput">Everyone has a right to affordable living.</label>
            </div>
          </div> <!--end row class-->

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>Hosts</h3>
                <label for="formGroupExampleInput">We share the world and we share our space.
Hosts develop lasting friendships, helping each other through the sharing economy. It's a win-win!
</label>
            </div>
          </div> <!--end row class-->
      </div> <!--end container-->
    </section>
</asp:Content>

