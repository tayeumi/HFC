<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getTraffic.aspx.cs" Inherits="WebCM.getTraffic" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Mac:  "></asp:Label>
        <asp:TextBox ID="txtMac" runat="server"></asp:TextBox>
        <asp:Button ID="btnTim" runat="server" onclick="btnTim_Click" Text="Xem" />
        <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" 
            Text="Reset modem" Visible="False" />
        <br />
        <asp:Chart ID="ChartItem" runat="server" Height="146px" RightToLeft="Yes" 
            Width="731px">
            <series>
                <asp:Series ChartType="Spline" LabelToolTip="DS" Name="Series1">
                </asp:Series>
                <asp:Series ChartArea="ChartArea1" ChartType="Spline" LabelToolTip="US" 
                    Name="Series2">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <br />
        <asp:GridView ID="GridItem" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
            CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="737px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="DateTime" HeaderText="Date" />
                <asp:BoundField DataField="MacAddress" HeaderText="Mac Address" />
                <asp:BoundField DataField="DS" HeaderText="DS (KByte)" />
                <asp:BoundField DataField="US" HeaderText="US (KByte)" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
