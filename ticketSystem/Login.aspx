<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ticketSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        #form1 {
            height: 376px;
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
        <div class ="center">
            <h1>Login Page</h1>
            <asp:Label ID="info" runat="server" Text="Please Login to begin"></asp:Label>
            <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtUser" runat="server" style="margin-top: 0px" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUser" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtPass" runat="server" style="margin-top: 0px" Width="152px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="*"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        &nbsp;
        <asp:Button ID="Logins" runat="server" OnClick="Logins_Click" Text="Login" style="height: 26px" Height="25px" Width="77px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Register" runat="server" OnClick="Register_Click" Text="Register" Height="25px" Width="77px" />
        <br />
        </div>
    </form>
</body>
</html>
