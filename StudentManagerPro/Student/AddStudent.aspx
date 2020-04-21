<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="AddStudent.aspx.cs" Inherits="StudentManagerPro.Students.AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AddStudent.css" rel="stylesheet" type="text/css" />
    <script src="../JS/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../JS/GVerify/index.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="StuInfoTable">
        <caption>
            第一步：填写学员基本信息</caption>
        <tr>
            <td>
                学员姓名：
            </td>
            <td>
                <asp:TextBox ID="txtStuName" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtStuName" ErrorMessage="请填写学员姓名!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                学员性别：
            </td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem>男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                出生日期：
            </td>
            <td>
                <asp:TextBox ID="txtStuBirthday" runat="server" Width="100px" onclick="WdatePicker()"></asp:TextBox>
                (请点击文本框选择日期)<asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="txtStuBirthday" ErrorMessage="请选择日期!" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                所在班级：
            </td>
            <td>
                <asp:DropDownList ID="ddlClass" Width="100px" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                身份证号：
            </td>
            <td>
                <asp:TextBox ID="txtStuIdNo" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtStuIdNo" Display="Dynamic" ErrorMessage="请填写身份证号！" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtStuIdNo" Display="Dynamic" ErrorMessage="身份证号不符合要求！" 
                    ForeColor="Red" ValidationExpression="\d{17}[\d|X]|\d{15}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                联系电话：
            </td>
            <td>
                <asp:TextBox ID="txtPhoneNumber" runat="server" Width="320px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                家庭住址：
            </td>
            <td>
                <asp:TextBox ID="txtStuAddress" runat="server" Width="320px"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
            请输入验证码：
            </td>
            <td>
                 <asp:TextBox  ID="txtValidateCode"  runat="server" Width="50px" ></asp:TextBox>
               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtValidateCode" ErrorMessage="请输入验证码!" ForeColor="Red" 
                     Display="Dynamic"></asp:RequiredFieldValidator>
                 <div id="v_container" style="width: 200px;height: 50px;"></div>
               
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnAddStudent" runat="server" Text="提交到数据库" OnClientClick="return codeCheck();" OnClick="btnAddStudent_Click"  />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        var verifyCode = new GVerify("v_container");
        function codeCheck() {
            var res = verifyCode.validate(document.getElementById("<%=txtValidateCode.ClientID%>").value);
            if (res) {
                return true;
            } else {
                alert("验证码错误");
                return false;
            }
        }
</script>
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
</asp:Content>
