<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDetail.aspx.cs"
    Inherits="StudentManagerPro.Students.StudentDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学员详细信息</title>
    <link href="../Styles/StudentDetail.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function btnCloseWindow() {
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">
     <div id="StudentDetail">
            <table class="StuTable">
                <tr>
                    <td colspan="2">
                        <asp:Image ID="stuImg" runat="server" Height="128px" Width="116px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        学员学号：
                    </td>
                    <td>
                        <asp:Literal ID="ltaStudentId" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        学员姓名：
                    </td>
                    <td>
                        <asp:Literal ID="ltaStudentName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        学员性别：
                    </td>
                    <td>
                        <asp:Literal ID="ltaGender" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        出生日期：
                    </td>
                    <td>
                        <asp:Literal ID="ltaBirthday" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        所在班级：
                    </td>
                    <td>
                        <asp:Literal ID="ltaClass" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        身份证号：
                    </td>
                    <td>
                        <asp:Literal ID="ltaStudentIdNo" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        联系电话：
                    </td>
                    <td>
                        <asp:Literal ID="ltaPhoneNumber" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        家庭住址：
                    </td>
                    <td>
                        <asp:Literal ID="ltaAddress" runat="server"></asp:Literal>
                    </td>
                </tr>
                 <tr>
                    <td>
                       
                    </td>
                    <td>
                        <input id="btnClose" type="button" value="关闭窗口" onclick="btnCloseWindow()"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
