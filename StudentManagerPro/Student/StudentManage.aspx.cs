using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DAL;

namespace StudentManagerPro.Students
{
    public partial class StudentManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltaMsg.Text = "";
            if (!IsPostBack)
            {
                ddlClass.DataSource = new StudentClassService().queryAllClass();
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            dlStuInfo.DataSource = new StudentServices().QueryStudentsByClass(Convert.ToInt32(ddlClass.SelectedValue));
            dlStuInfo.DataBind();
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            int StuId = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            try
            {
                int result = new StudentServices().deleteStudent(StuId);
                if (result ==1)
                {
                    File.Delete(Server.MapPath("~/images/Student/" + StuId + ".jpg"));
                    ltaMsg.Text = "<script type='text/javascript'>alert('删除成功');</script>";
                    //刷新页面
                    btnQuery_Click(null, null);
                }
                else
                {
                    ltaMsg.Text = "<script type='text/javascript'>alert('删除失败');</script>";
                }
            }
            catch (Exception ex)
            {
                ltaMsg.Text = "<script type='text/javascript'>alert('数据库异常');</script>";
            }
        }
      
      
    }
}