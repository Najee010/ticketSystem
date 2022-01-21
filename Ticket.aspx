<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="ticketSystem.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 368px;
        }
    </style>
       <link href="css/bootstrap.min.css" rel="stylesheet" />
       <script src="Scripts/bootstrap.min.js"></script>
       <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 47px">
            <h1>Ticket Page</h1>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Author"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Author" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Content"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="Content" runat="server" Height="37px" style="margin-top: 2px" Width="247px"></asp:TextBox>
        <br />
        <br />
        Status&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="Status" runat="server" style="margin-left: 0px">
            <asp:ListItem Value="Open"></asp:ListItem>
            <asp:ListItem>Owned</asp:ListItem>
            <asp:ListItem>Closed</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <br />
        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="editButton" runat="server" Text="Save Edit" OnClick="editButton_Click"  autopostback="false" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label" runat="server" Text=" "></asp:Label>
    </form>
</body>
</html>
