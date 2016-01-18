<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getHistory.aspx.cs" Inherits="WebCM.getHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<meta name="viewport" content="width=device-width, initial-scale=1.0, target-densitydpi=device-dpi" />
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:GridView ID="gridItem" runat="server" AutoGenerateColumns="False" 
            Font-Size="Small" PageSize="5" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
            onrowdatabound="gridItem_RowDataBound">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="DateTime" HeaderText="Date Time" />
                <asp:BoundField DataField="Location" HeaderText="Location" />
                <asp:BoundField DataField="MacAddress" HeaderText="MacAddress" />
                <asp:BoundField DataField="IpPrivate" HeaderText="IpPrivate" />
                <asp:BoundField DataField="Value1" HeaderText="DS SNR" />
                <asp:BoundField DataField="Value2" HeaderText="US Tx" />
                <asp:BoundField DataField="Value3" HeaderText="DS Rx" />
                <asp:BoundField DataField="Value4" HeaderText="US SNR" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="IpPublic1" HeaderText="IpPublic1" />
                <asp:BoundField DataField="IpPublic2" HeaderText="PC Mac" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
    
    <div>
    
    </div>
    </form>
</body>
</html>
