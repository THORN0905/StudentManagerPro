<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="UpLoadImage.aspx.cs" Inherits="StudentManagerPro.Students.UpLoadImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AddStudent.css" rel="stylesheet" type="text/css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="StuInfoTable">
        <caption>
            第二步：上传学员照片</caption>     
        <tr>
            <td colspan="2">
                <asp:FileUpload ID="fulStuImage" runat="server" onchange="checkimg()"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnUpLoadImage" OnClientClick="return Checkful()"
                    runat="server"
                    Text="上传照片" OnClick="btnUpLoadImage_Click" />
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
    <script type="text/javascript">
        function checkimg() {
            var name = fulStuImage.value;
            name = name.toLowerCase().substr(name.lastIndexOf("."));
            if ((name != ".jpg") && (name != "png")) {
                fulStuImage.value = "";
                alert("上传图片仅支持jpg，png格式！");
            }
        }
        function checkful() {
            var ful = doucument.getElementById("<%=fulStuImage.ClientID%>");
        if (ful.value == "") {
            alert('请选择照片！');
            return false;
        } else return true;
    }
    </script>
</asp:Content>

