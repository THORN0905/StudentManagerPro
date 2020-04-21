using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Models;

namespace StudentManagerPro.Students
{
    public partial class EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //显示班级下拉框
                ddlClass.DataSource = new StudentClassService().queryAllClass();
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();

                //显示原来的信息
                int StudentId = Convert.ToInt32(Request.QueryString["StudentId"]);
                if (Request.QueryString["StudentId"] == null)
                    Response.Redirect("~/Error.aspx");
                else
                {
                    StudentExt stu = new StudentServices().QueryStudentById(StudentId);
                    ltaStudentId.Text = stu.StudentId.ToString();
                    txtStuName.Text = stu.StudentName.ToString();
                    txtStuIdNo.Text = stu.StudentIdNo.ToString();
                    txtStuBirthday.Text = stu.Birthday.ToString("yyyy-MM-dd");
                    txtStuAddress.Text = stu.StudentAddress.ToString();
                    txtPhoneNumber.Text = stu.PhoneNumber.ToString();
                    ddlClass.SelectedIndex = stu.ClassId-1;
                }
            }
            
        }

        protected void btnEditStudent_Click(object sender, EventArgs e)
        {
            int stuId=Convert.ToInt32(Request.QueryString["StudentId"]);
            String StuIdNo = txtStuIdNo.Text.ToString();
            if (StudentServices.isExistedStudent(StuIdNo,stuId))
            {
                 ltaMsg.Text = "<script type='text/javascript'>alert('该身份证已存在！');</script>";
                 return;
            }
            else   
            {
                StudentExt stu = new StudentExt()
                {
                    StudentId = stuId,
                    StudentName = txtStuName.Text.ToString(),
                    Gender=ddlGender.Text.ToString(),
                    StudentIdNo=txtStuIdNo.Text.ToString(),
                    StudentAddress=txtStuAddress.Text.ToString(),
                    Birthday=Convert.ToDateTime(txtStuBirthday.Text),
                    PhoneNumber=txtPhoneNumber.Text.ToString(),
                    ClassId=Convert.ToInt32(ddlClass.SelectedValue)
                };
               
                    int result = new StudentServices().updateStudent(stu);
                    if (result > 0)
                    {
                        Response.Redirect("~/Student/UpLoadImage.aspx?update=1&id=" + stuId);
                    }
                    else
                    {
                        ltaMsg.Text = "<script type='text/javascript'>alert('更新失败')</script>";
                        return;
                    }
                }
          
        }
    
    }
}