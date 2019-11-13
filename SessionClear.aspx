<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SessionClear.aspx.cs" Inherits="SessionClear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <script type ="text/javascript" >
     var clicked = false;
     var xmlHttp
     var browser = navigator.appName;
     

     function CheckBrowser() {


         if (clicked == false) {
             xmlHttp = GetXmlHttpObject();
             xmlHttp.open("GET", "SessionEnd.aspx", true);
             xmlHttp.onreadystatechange = function() {
                 if (xmlHttp.readyState == 4) {
                     // alert(xmlhttp.responseText)
                 }
             }
             xmlHttp.send(null)
             if (browser == "Netscape")
             {
             window.location=".../SessionEnd.aspx";
                 alert("Browser Terminated");
                 openInNewWindow();
                }
         }
         else {
             //alert("Redirected");
             clicked = false;
         }
     }


     function GetXmlHttpObject() {
         var xmlHttp = null;
         try {
             // Firefox, Opera 8.0+, Safari
             xmlHttp = new XMLHttpRequest();
         }
         catch (e) {
             //Internet Explorer
             try {
                 xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
             }
             catch (e) {
                 xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
             }
         }
         return xmlHttp;
     }


     function openInNewWindow()
     {
         // Change "_blank" to something like "newWindow" to load all links in the same new window
         var newWindow = window.open(".../SessionEnd.aspx");
         newWindow.focus();
         return false;
     }
 

   </script>
</asp:Content>

