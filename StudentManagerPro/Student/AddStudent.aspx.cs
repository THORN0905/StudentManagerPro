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
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlClass.DataSource = new StudentClassService().queryAllClass();
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();
            }
           
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            //1.验证码验证（暂缺）
            
            //2.查询该生是否已存在
            if (StudentServices.isExistedStudent(txtStuIdNo.Text))
            {
                ltaMsg.Text = "<script type='text/javascript'> alert('增加失败，该学生已存在！')</script>";
                return;
            }
            //3.封装学生对象
            Student stu = new Student();
            stu.StudentName=txtStuName.Text.Trim();
            stu.Gender=ddlGender.Text.Trim();
            stu.Birthday=Convert.ToDateTime(txtStuBirthday.Text.Trim());
            stu.ClassId=Convert.ToInt32(ddlClass.SelectedValue);
            stu.StudentIdNo=txtStuIdNo.Text.Trim();
            stu.PhoneNumber=txtPhoneNumber.Text.Trim();
            stu.StudentAddress=txtStuAddress.Text.Trim();

            //4.执行
            try
            {
                int stuid = StudentServices.AddStudent(stu);
                stu.StudentId = stuid;
                Response.Redirect("~/Student/UpLoadImage.aspx?id="+stuid);
                //Session["newStuId"] = stuid;
            }
            catch (Exception ex)
            {
                ltaMsg.Text = "<script type='text/javascript'> alert('增加失败：'"+ex.Message+")</script>";
            }
           
        }

  
    }
}