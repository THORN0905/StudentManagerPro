<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="StudentManage.aspx.cs" Inherits="StudentManagerPro.Students.StudentManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/StudentManage.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="QueryDiv">
        请选择要查询的班级：<asp:DropDownList ID="ddlClass" Width="120px" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnQuery" runat="server" Text="提交查询" OnClick="btnQuery_Click" />
        <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
    </div>
    <asp:DataList ID="dlStuInfo" runat="server"  RepeatColumns="2">
        <ItemTemplate>
            <div class="stuInfo">
                <div class="stuImg">
                    <asp:Image ID="imgStu" runat="server" Height="136px" Width="150px" ImageUrl='<%#Eval("StudentId","~/Images/Student/{0}.jpg") %>' />
                </div>
                <div class="stuItem">
                    <span>姓名：</span><span style="width: 80px;"><%#Eval("StudentName") %></span>&nbsp;&nbsp;<span>性别：<%#Eval("Gender") %></span></div>
                <div class="stuItem">
                    <span>班级：</span><span style="width: 80px;"><%#Eval("ClassName") %></span>&nbsp;&nbsp;<span>出生日期：<%#Eval("Birthday","{0:yy-MM-dd}") %></span></div>
                <div class="stuItem">
                    <span>家庭住址：</span><span style="width: 80px;"><%#Eval("StudentAddress") %></span></div>
                <div class="stuItem">
                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#Eval("StudentId","~/Student/EditStudent.aspx?StudentId={0}") %>'
                runat="server" ForeColor="Blue">修改信息</asp:HyperLink>
                    &nbsp;
                    <asp:LinkButton ID="btnDel" CommandArgument='<%#Eval("StudentId")%>' OnClientClick="return confirm('确认删除该学生么？')"  OnClick="btnDel_Click"
                runat="server">删除学员</asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
   <%-- <div class="stuInfo">
        <div class="stuImg">
            <asp:Image ID="Image3" runat="server" Height="136px" Width="150px" ImageUrl="~/Images/Student/100002.jpg" />
        </div>
        <div class="stuItem">
            <span>姓名：</span><span style="width: 80px;">待定</span>&nbsp;&nbsp;<span>性别：待定</span>
        </div>
        <div class="stuItem">
            <span>班级：</span><span style="width: 80px;">待定</span>&nbsp;&nbsp;<span>出生日期：待定</span>
        </div>
        <div class="stuItem">
            <span>家庭住址：</span><span style="width: 80px;">待定</span>
        </div>
        <div class="stuItem">
            <asp:HyperLink ID="HyperLink4"
                runat="server" ForeColor="Blue">修改信息</asp:HyperLink>&nbsp;
            <asp:LinkButton ID="LinkButton3"
                runat="server">删除学员</asp:LinkButton>
        </div>
    </div>--%>

</asp:Content>
