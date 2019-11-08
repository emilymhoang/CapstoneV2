<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateMessage.aspx.cs" Inherits="CreateMessage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
            width: 450px;
            height: 66px;
            background-color: white;
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Create a Message" AutoPostBack="true" />
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Panel ID="Panel1" runat="server" CssClass="modalpopup">
                    <asp:Label ID="Label2" runat="server" Text="Label">Create a Message</asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Send" />
                    <asp:Button ID="Button3" runat="server" Text="Cancel" />
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="Button1" BackgroundCssClass="modalBackground" CancelControlID="Button3">
                </ajaxToolkit:ModalPopupExtender>
        </div>
    </form>
</body>
</html>
