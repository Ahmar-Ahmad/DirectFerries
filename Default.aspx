<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <p>
                Full Name :
                <asp:Textbox runat="server" ID="txtFullName"></asp:Textbox>
            </p>
            <br />
            <p>
                DOB :
                <asp:Textbox runat="server" ID="txtDOB"></asp:Textbox>
            </p>
            <br />
            <p>
                <asp:Button runat="server" class="btn btn-default" id="Button1" onclick="Button1_Click" Text="Proceed >>" /></asp:Button>
            </p>
       

    
            <asp:Label ID="lblMessage" runat="server" Text=""> </asp:Label>
   </form>
</body>
</html>
