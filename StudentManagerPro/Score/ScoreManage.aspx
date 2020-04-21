<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="ScoreManage.aspx.cs" Inherits="StudentManagerPro.Score.ScoreManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/ScoreManage.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="QueryDiv">
        请选择要查询的班级：<asp:DropDownList ID="ddlClass" Width="120px" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnQuery" runat="server" Text="提交查询" OnClick="btnQuery_Click"  />
    &nbsp;&nbsp;
        <asp:Button ID="btnExporttoExcel" runat="server" OnClick="btnExporttoExcel_Click" Text="导出到Excel" />
    </div>
     <div id="ScoreListDiv">     
	     <asp:GridView ID="GridView1" class="ScoreTable" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
             <Columns>
                 <asp:BoundField DataField="StudentId" HeaderText="学号" />
                 <asp:BoundField DataField="StudentName" HeaderText="学生姓名" />
                 <asp:BoundField DataField="Gender" HeaderText="性别" />
                 <asp:BoundField DataField="CSharp" HeaderText="C#成绩" />
                 <asp:BoundField DataField="SQLServerDB" HeaderText="数据库成绩" />
                 <asp:HyperLinkField DataNavigateUrlFields="StudentId" DataNavigateUrlFormatString="~/Student/StudentDetail.aspx?StudentId={0}" HeaderText="学员信息" Text="详细信息" />
             </Columns>
         </asp:GridView>
         <br />
         <%--<table class="ScoreTable" cellspacing="0" rules="all" border="1" id="ContentPlaceHolder1_gvScoreList" style="border-collapse:collapse;">
		    <tr>
			    <th scope="col">学员姓名</th><th scope="col">性别</th><th scope="col">所在班级</th><th scope="col">C#成绩</th><th scope="col">数据库成绩</th><th scope="col">学员信息</th>
		    </tr>
            <tr onmouseover="currentcolor=this.style.backgroundColor;this.style.backgroundColor=&#39;#6699ff&#39;" onmouseout="this.style.backgroundColor=currentcolor">
			    <td>王小虎</td><td>男</td><td>软件1班</td><td>60</td><td>78</td><td><a href="../Student/StudentDetail.aspx?StudentId=100000" target="_blank">详细信息</a></td>
		    </tr>
            <tr onmouseover="currentcolor=this.style.backgroundColor;this.style.backgroundColor=&#39;#6699ff&#39;" onmouseout="this.style.backgroundColor=currentcolor">
			    <td>杜小丽</td><td>女</td><td>软件1班</td><td>62</td><td>88</td><td><a href="../Student/StudentDetail.aspx?StudentId=100004" target="_blank">详细信息</a></td>
		    </tr>
            <tr onmouseover="currentcolor=this.style.backgroundColor;this.style.backgroundColor=&#39;#6699ff&#39;" onmouseout="this.style.backgroundColor=currentcolor">
			    <td>李铭</td><td>男</td><td>软件1班</td><td>91</td><td>66</td><td><a href="../Student/StudentDetail.aspx?StudentId=100007" target="_blank">详细信息</a></td>
		    </tr>
	    </table>--%>
    </div>
</asp:Content>
