<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TEST.aspx.cs" Inherits="StudentManagerPro.TEST" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="StudentId" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" PageSize="6">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                <asp:BoundField DataField="StudentId" HeaderText="StudentId" InsertVisible="False" ReadOnly="True" SortExpression="StudentId" />
                <asp:BoundField DataField="StudentName" HeaderText="StudentName" SortExpression="StudentName" />
                <asp:BoundField DataField="Birthday" HeaderText="Birthday" SortExpression="Birthday" />
                <asp:BoundField DataField="StudentIdNo" HeaderText="StudentIdNo" SortExpression="StudentIdNo" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                <asp:BoundField DataField="StudentAddress" HeaderText="StudentAddress" SortExpression="StudentAddress" />
                <asp:BoundField DataField="ClassId" HeaderText="ClassId" SortExpression="ClassId" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StudentManagerConnectionString %>" SelectCommand="SELECT [StudentId], [StudentName], [Birthday], [StudentIdNo], [PhoneNumber], [StudentAddress], [ClassId], [Gender] FROM [Students]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [Students] WHERE [StudentId] = @original_StudentId AND [StudentName] = @original_StudentName AND [Birthday] = @original_Birthday AND [StudentIdNo] = @original_StudentIdNo AND (([PhoneNumber] = @original_PhoneNumber) OR ([PhoneNumber] IS NULL AND @original_PhoneNumber IS NULL)) AND (([StudentAddress] = @original_StudentAddress) OR ([StudentAddress] IS NULL AND @original_StudentAddress IS NULL)) AND [ClassId] = @original_ClassId AND [Gender] = @original_Gender" InsertCommand="INSERT INTO [Students] ([StudentName], [Birthday], [StudentIdNo], [PhoneNumber], [StudentAddress], [ClassId], [Gender]) VALUES (@StudentName, @Birthday, @StudentIdNo, @PhoneNumber, @StudentAddress, @ClassId, @Gender)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [Students] SET [StudentName] = @StudentName, [Birthday] = @Birthday, [StudentIdNo] = @StudentIdNo, [PhoneNumber] = @PhoneNumber, [StudentAddress] = @StudentAddress, [ClassId] = @ClassId, [Gender] = @Gender WHERE [StudentId] = @original_StudentId AND [StudentName] = @original_StudentName AND [Birthday] = @original_Birthday AND [StudentIdNo] = @original_StudentIdNo AND (([PhoneNumber] = @original_PhoneNumber) OR ([PhoneNumber] IS NULL AND @original_PhoneNumber IS NULL)) AND (([StudentAddress] = @original_StudentAddress) OR ([StudentAddress] IS NULL AND @original_StudentAddress IS NULL)) AND [ClassId] = @original_ClassId AND [Gender] = @original_Gender">
            <DeleteParameters>
                <asp:Parameter Name="original_StudentId" Type="Int32" />
                <asp:Parameter Name="original_StudentName" Type="String" />
                <asp:Parameter Name="original_Birthday" Type="DateTime" />
                <asp:Parameter Name="original_StudentIdNo" Type="Decimal" />
                <asp:Parameter Name="original_PhoneNumber" Type="String" />
                <asp:Parameter Name="original_StudentAddress" Type="String" />
                <asp:Parameter Name="original_ClassId" Type="Int32" />
                <asp:Parameter Name="original_Gender" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="StudentName" Type="String" />
                <asp:Parameter Name="Birthday" Type="DateTime" />
                <asp:Parameter Name="StudentIdNo" Type="Decimal" />
                <asp:Parameter Name="PhoneNumber" Type="String" />
                <asp:Parameter Name="StudentAddress" Type="String" />
                <asp:Parameter Name="ClassId" Type="Int32" />
                <asp:Parameter Name="Gender" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="StudentName" Type="String" />
                <asp:Parameter Name="Birthday" Type="DateTime" />
                <asp:Parameter Name="StudentIdNo" Type="Decimal" />
                <asp:Parameter Name="PhoneNumber" Type="String" />
                <asp:Parameter Name="StudentAddress" Type="String" />
                <asp:Parameter Name="ClassId" Type="Int32" />
                <asp:Parameter Name="Gender" Type="String" />
                <asp:Parameter Name="original_StudentId" Type="Int32" />
                <asp:Parameter Name="original_StudentName" Type="String" />
                <asp:Parameter Name="original_Birthday" Type="DateTime" />
                <asp:Parameter Name="original_StudentIdNo" Type="Decimal" />
                <asp:Parameter Name="original_PhoneNumber" Type="String" />
                <asp:Parameter Name="original_StudentAddress" Type="String" />
                <asp:Parameter Name="original_ClassId" Type="Int32" />
                <asp:Parameter Name="original_Gender" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
