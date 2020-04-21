<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="StudentManagerPro.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/AdminLogin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <div id="sysTitle">
                喜科堂学员管理系统
            </div>
            <div id="loginImg">
                <img src="Images/login.png" alt="" />
            </div>
            <div id="loginInput">
                <asp:Literal ID="ltaInfo" runat="server"></asp:Literal>
                <div class="loginItem">
                    用户名：<asp:TextBox ID="txtUserId"
                        runat="server" Width="150px"></asp:TextBox>
                </div>
                <div class="loginItem">
                    密&nbsp;&nbsp;&nbsp;&nbsp;码：<asp:TextBox
                        ID="txtPwd" CssClass="loginItemText" runat="server" TextMode="Password"
                        Width="150px"></asp:TextBox>
                </div>
                <div class="loginItem">
                    <asp:ImageButton ID="ibtnLogin" ImageUrl="~/Images/btnLogin.png" CssClass="loginItemText"
                        runat="server" BorderWidth="0px" OnClick="ibtnLogin_Click" />
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtUserId" Display="None" ErrorMessage="请输入用户名!"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txtPwd" Display="None" ErrorMessage="请输入密码!"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                    ShowMessageBox="True" ShowSummary="False" />
            </div>
        </div>
    </form>
</body>
</html>
