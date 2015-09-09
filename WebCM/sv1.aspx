<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sv1.aspx.cs" Inherits="WebCM.sv1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;<asp:TextBox ID="txtCommand" runat="server" Width="82px"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" />    
        <asp:Label ID="lblKQ" runat="server" Font-Size="14px"></asp:Label>
    
    </div>
    </form>
</body>
</html>
