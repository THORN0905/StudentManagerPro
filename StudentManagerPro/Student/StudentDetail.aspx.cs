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
    public partial class StudentDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["StudentId"] == null)
                    Response.Redirect("~/Error.aspx");
                int StuId = Convert.ToInt32(Request.QueryString["StudentId"]);
                StudentExt stu = new StudentServices().QueryStudentById(StuId);
                ltaStudentId.Text = stu.StudentId.ToString();
                ltaStudentName.Text = stu.StudentName;
                ltaStudentIdNo.Text = stu.StudentIdNo;
                ltaGender.Text = stu.Gender;
                ltaClass.Text = stu.ClassName;
                ltaBirthday.Text = stu.Birthday.ToString("yyyy-MM-dd");
                ltaAddress.Text = stu.StudentAddress;
                ltaPhoneNumber.Text = stu.PhoneNumber;
                stuImg.ImageUrl = "~/Images/Student/" + Request.QueryString["StudentId"] + ".jpg";
            }
        }
    }
}