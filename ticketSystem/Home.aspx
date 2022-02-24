<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ticketSystem.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
       <link href="css/bootstrap.min.css" rel="stylesheet" />
       <script src="Scripts/bootstrap.min.js"></script>
       <script src="js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server"> 
    <!-- first welcome -->
   <div class ="row">
       <div class="col-md-12">
        <h1> Welcome to the home page :)</h1>
        </div>
      </div>

    <!-- Custom welcome for user -->
        <div class ="row">
       <div class="col-md-12">
            <asp:Label ID="Welcome" runat="server" Text=" Welcome Again " ></asp:Label>
        </div>
      </div>
    <!--Bootstrap organizing of elements -->
    <div class="row"> 
        <div class="col-md-6">
            <!-- Owned Tickets Listbox and Buttons -->
            <h3> Owned Tickets All Tickets</h3>
            <asp:ListBox ID="userTickets" runat="server" OnSelectedIndexChanged="userTickets_SelectedIndexChanged" style="margin-left: 0px" Width="315px" Height="100px"></asp:ListBox>
            <br /> 
            <asp:Button ID="createButton" runat="server" Text="Create" OnClick="createButton_Click" Height="25px" Width="77px" />
            <asp:Button ID="editButton" runat="server" Text="Edit" OnClick="editButton_Click" Height="25px" Width="77px" />
            <asp:Button ID="deleteButton" runat="server" Text="Delete" OnClick="deleteButton_Click" Height="25px" Width="77px" padding="1em"/>
        </div>

        <div class="col-md-6">
            <!-- unowned Tickets Listbox and Buttons -->
            <h3 > Unowned Tickets </h3>
            <asp:ListBox ID="unownedTickets" runat="server" OnSelectedIndexChanged="unownedTickets_SelectedIndexChanged" Height="100px" style="margin-left: 3px" Width="300px"></asp:ListBox>
            <br />
            <asp:Button ID="Edit" runat="server" OnClick="Edit_Click" Text="Edit" style="margin-left: 0px" Width="77px" Height="25px" />
            <asp:Button ID="Delete" runat="server" Text="Delete" OnClick="Delete_Click" style="margin-left: 0px" Width="77px" Height="25px" />
        </div>
    </div>


        



  

        

        

    </form>
</body>
</html>
