<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contract.aspx.cs" Inherits="Contract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
       h3 {
        font-family: 'Oswald', sans-serif;
        font-size:24px;
        }
       h4{
        font-size: 18px;
       }
        </style>
   
    
       
    </header>

    <section id="creation" style="margin-top: 8rem;">
      <div class="container" style="font-family: 'oswald';">
          <div class="row" style="margin-bottom:1rem;">
            <div class="col-md-10">
                <h1 >Intent to Lease</h1> 
             </div>
              <div class="col-md-2">
                <a href="images/intent-to-lease.pdf" class="btn">Download as a PDF</a>
              </div>
            </div>
        <div style="margin-left: 1rem;">
          <div class="row">
            <p>Date: _____________________________</p>
        </div>
        <div class="row">
            <p>This letter of intent (letter of intent) sets forth the general terms of the proposal. The provisions of this
letter of intent shall serve as the basis for a lease agreement to be negotiated and entered into
between the tenant and landlord (the lease).</p>
        </div>
        <div class="row">
            <p>Tenant Name: _______________________________________</p>
            <p>Landlord Name: _______________________________________</p>
        </div>
          <div class="row">
            <p>Property Address: __________________________________  City: __________________________________ State: ________ </p>
            <p>Lease Term: _________________________________________________</p>
            <p>Available Date: _________________________________________________</p>
            <p>Rental Price: _________________________________________________</p><br />
        </div>
          <div class="row">
            <p>A security deposit is required upon check in.<br />
By writing your name below you agree to the terms set forth above.</p>
            </div>
            <div class="row">
            <p>Tenant:</p><p>______________________________</p><br />
            </div>
            <div class="row">
            <p>Landlord:</p><p >______________________________</p><br />
            <br />
            </div>
          <div class="row">
            <p>Send an executed copy of this intent to lease to the following link.<br />
Tenant shall be sent a stripe payment link to pay the first month’s lease payment to the landlord.<br />
Landlord’s will need to set up a stripe account using the following link.</p>
        </div>

        </div>

      </div> <!--end container-->
    </section>
    </asp:Content>
    
