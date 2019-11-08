<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contract.aspx.cs" Inherits="Contract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
       h3 {
        font-family: 'Oswald', sans-serif;
        color: #CC6559;
        }
        </style>

   <header style="margin-top: 8rem;">b
      <div class="container">
            <h1 style="font-family: 'Oswald', sans-serif; color: black;">We made a sample agreement to make things easier for you.</h1>
      </div>
       
    
       
    </header>

    <section id="creation" style="margin-top: 4rem; font-family: 'Oswald', sans-serif; color: #756664;">
      <div class="container">
          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h2 style="font-family: 'Oswald', sans-serif; color: #53A39F;">RENTAL AGREEMENT</h2>
                <h3>Fair Housing for all is the cornerstone of RoomMagnet's  philosophy. Please refer to the Fair Housing  Act link  at the  end of this  agreement</h3>
                <label for="formGroupExampleInput">This is a good faith agreement between Tenant and Host (owner). It is intended to promote household harmony by clarifying the expectations and responsibilities of the Host(s) and Tenant. The Host and Tenant should review this document. Please be aware there are landlord-tenant laws that govern each state. Please refer to the link at the end of this agreement.</label>
            </div>
          </div> <!--end row class-->
          <br>
          
          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>1. Address of the home </h3>
                <label for="formGroupExampleInput">[HOME ADDRESS]</label>
            </div>
          </div> <!--end row class-->
          <br>


          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>2. Parties</h3>
                <h4>2.1 Owners</h4>
                <label for="formGroupExampleInput">[OWNER ( HOST)  NAMES]
</label>
                <h4>2.2 Tenant</h4>
                <label for="formGroupExampleInput">[TENANT (STUDENT) NAME]</label>
            </div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>3. Start Date</h3>
                <label for="formGroupExampleInput">  The Start Date of this lease is: [MOVE IN DATE]</label>
            </div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>4. Length of Agreement</h3>
                <label for="formGroupExampleInput"> (Specify the length of the agreement)________________________ ______________.The Tenant must provide at least 30 days written notice, signed by both parties, to cancel or change the Agreement.</label>
            </div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>5.  Rental Rate</h3>
                <label for="formGroupExampleInput">The  Base rental rate  for the  room  is $_______per month. The tenant will pay__________ to the host on a monthly basis and this reflects the base rental rate. If household tasks are part of this agreement the Tenant will pay the base rental rate and will work out any discounts directly with the host. </label>
            </div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>6. Conflict resolution</h3>
                <label for="formGroupExampleInput">Tenant will strive to develop mutual cooperation with the Owner. Should disagreements arise, each shall try to resolve the dispute in good faith using clear communication.</label>
            </div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>7.Utilities and Amenities</h3>
                <label for="formGroupExampleInput">Rent includes access to/use of, heat, air conditioning, hot and cold water, electricity, recycling and waste services.
Standard wired and wireless shared internet access is provided at no additional cost, with access granted on Start Date.</label>
 </div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>8.Room Alterations</h3>
                <label for="formGroupExampleInput">Tenant agrees to not alter, modify, or otherwise change Tenant Spaces or Common Areas. This includes, but is not limited to painting, remodeling, and "fixing" unless otherwise granted permission by Manager or Owner.
Tenant must leave the property in the same condition as when they moved in, barring normal wear and tear.
</label>
            </div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>9. Animal and Pet Policy</h3>
                <label for="formGroupExampleInput">Tenant agrees to not keep or allow anywhere on or about the premises any animals or pets of any kind, including, but not limited to cats, dogs, rodents, birds, and reptiles unless otherwise granted permission below by Owner upon execution of this agreement.
Owner agrees to pets______ Owner does not agree to pets______ ( PLEASE CHECK ONE)

</label>
            </div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>10. Drugs</h3>
                <label for="formGroupExampleInput">No illegal drugs are allowed on the property.</div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>11. Smoking</h3>
                <label for="formGroupExampleInput">No smoking within the property or within 25 feet of the property unless otherwise granted permission by Owner. Tenant must properly dispose of cigarette butts so as to not cause a fire hazard.</label>
            </div>
          </div> <!--end row class-->
          <br>


          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>12. Catastrophic Damage</h3>
                <label for="formGroupExampleInput">If the Home is damaged or destroyed, making it uninhabitable, then Owner and Tenants shall have the right to terminate this Agreement immediately if both parties agree. </div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>13. Insurance Disclaimer</h3>
                <label for="formGroupExampleInput">Tenants assume full responsibility for all personal property placed, stored or located on or about the premises. Tenants' personal property is not insured by Owner. Owner recommends that Tenants obtain renters insurance to protect against risk of loss from harm to Tenants' personal property. The owner shall not be responsible for any harm to Tenants' property resulting from fire, theft, burglary, strikes, riots, orders or acts of public authorities, acts of nature or any other circumstance or event beyond Owner’s control.</label>
            </div>
          </div> <!--end row class-->
          <br>


          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>14. Hold Harmless</h3>
                <label for="formGroupExampleInput">Tenants expressly release Owner from any and all liability for any damages or injury to Tenants, or any other person, or to any property, occurring on the premises unless such damage is the direct result of the negligence or unlawful act of Owner or Owner’s agents..</div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>15. Smoke Detectors</h3>
                <label for="formGroupExampleInput">The premises are equipped with a smoke detection device(s), and Tenants shall be responsible for reporting any problems, maintenance or repairs to Owner. Replacing batteries of smoke detectors in the primary bedroom of the Tenant is the responsibility of the Tenant.</label>
            </div>
          </div> <!--end row class-->
          <br>


          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>16. Lead Based Paint Disclosure</h3>
                <label for="formGroupExampleInput">Tenant acknowledges receipt of "Disclosure of Information on Lead-Based Paint or Lead-Based Paint Hazards" from Owner/agent. (Required for homes built before 1978) Available online at: 
http://www.epa.gov/region07/citizens/pdf/lead_disclosure_form_rentals.pdf
Tenant acknowledges receipt of the pamphlet Protect Your Family from Lead in Your Home (Required for homes built before 1978). Available online at:
http://www2.epa.gov/lead/protect-your-family-lead-your-home </label>
</div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>17. Subletting</h3>
                <label for="formGroupExampleInput">No portion of the premises shall be sublet nor this Agreement assigned without the prior written consent of the Owner. Any attempted subletting or assignment by Tenants shall, at the election of Owner, be a breach of this Agreement and cause for immediate termination as provided here and by law. </div>
          </div> <!--end row class-->
          <br>


          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>18. Individual Liability</h3>
                <label for="formGroupExampleInput">Each tenant who signs this Agreement, whether or not said person is or remains in the Home, shall be jointly and severally liable for the full performance of each and every obligation of this Agreement.</div>
          </div> <!--end row class-->
          <br>

           <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3>19. Modifications to this Agreement</h3>
                <label for="formGroupExampleInput">This agreement is the Whole Enchilada. This Agreement cannot be modified except in writing and must be signed by all parties. Neither Owner nor Tenants have made any promises or representations other than those set forth in this Agreement and those implied by law. By signing this agreement, the Tenant acknowledges having read and agreed to all of its provisions. Any additional agreements or amendments to this agreement between Tenant and Owner will not be considered binding unless it is in writing and signed by all parties.</label>
            </div>
          </div> <!--end row class-->
          <br>


          <div class="row" style="margin-bottom:2rem;">
            <div class="col">
                <h3> Sign and Date</h3>
                <label for="formGroupExampleInput">

     Tenant Signature: [TENANT SIGN]<br>


Date: [TENANT DATE]<br>




     Owner  Signature: [OWNER SIGN]<br>


Date: [OWNER DATE]<br>

This agreement adheres to the Federal Fair housing Act. Please read your rights as tenant and landlord.
https://portal.hud.gov/hudportal/HUD?src=/program_offices/fair_housing_equal_opp/FHLaws/your rights

The following are additional items that Tenant and Host may want to discuss as part of this agreement.<br><br>

Domestic tasks (if any)<br>
Guests ( staying or visiting)<br>
Tenant’s belongings left behind<br>
Owner Entry and Inspection<br>
Care and Cleaning of rental space<br>

This rental agreement is an example and provided as a courtesy to Roommagnet users.

</div>
          </div> <!--end row class-->
          <br>




      </div> <!--end container-->
    </section>
    </asp:Content>
    
