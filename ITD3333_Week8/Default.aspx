<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Select Author: 
            <asp:DropDownList ID="lastNameDropList" AutoPostBack="true" runat="server">
            </asp:DropDownList>
            </label><br /><br />
            <asp:Label ID="resultLbl" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
