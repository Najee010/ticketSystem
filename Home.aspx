<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ticketSystem.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .center{
            border: 5px;
            text-align: center;
        }
    </style>
       <link href="css/bootstrap.min.css" rel="stylesheet" />
       <script src="Scripts/bootstrap.min.js"></script>
       <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="center">
            <h1>Home page</h1>
        </div>
        <div class = "center">
            <asp:Label ID="Welcome" runat="server" Text=" " ></asp:Label>
        
        <div style="margin-left: 0px; ">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ListBox ID="userTickets" runat="server" OnSelectedIndexChanged="userTickets_SelectedIndexChanged" style="margin-left: 0px" Width="200px" Height="100px"></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ListBox ID="unownedTickets" runat="server" OnSelectedIndexChanged="unownedTickets_SelectedIndexChanged" Height="100px" style="margin-left: 0px" Width="200px"></asp:ListBox>
        </div>
        <br />
        <br />
        <asp:Button ID="createButton" runat="server" Text="Create" OnClick="createButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="editButton" runat="server" Text="Edit" OnClick="editButton_Click" style="height: 26px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="deleteButton" runat="server" Text="Delete" OnClick="deleteButton_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Edit" runat="server" OnClick="Edit_Click" Text="Edit" style="margin-left: 136px" Width="77px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" style="margin-left: 0px" Width="81px" />
        <br />
        <br />
            </div>
    </form>
</body>
</html>
