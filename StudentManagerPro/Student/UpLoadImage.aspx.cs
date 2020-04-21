using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagerPro.Students
{
    public partial class UpLoadImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                    Response.Redirect("~/Error.aspx");
                ViewState["id"] = Request.QueryString["id"];
            }
            ltaMsg.Text = "";
        }
        //上传照片
        protected void btnUpLoadImage_Click(object sender, EventArgs e)
        {
            //判断文件是否存在
            if (!fulStuImage.HasFile)
            {
                ltaMsg.Text = "<script type='text/javascript'>alert('请选择图片!')</script>";
                return;
            }
            //判断文件大小
            double theMaxphotoSize = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["theMaxphotoSize"])/1024;
            double fileSize = fulStuImage.FileContent.Length / (1024 * 1024);
            if (fileSize > theMaxphotoSize)
            {
                ltaMsg.Text = "<script type='text/javascript'>alert('文件图片不能超过"+theMaxphotoSize+"MB')</script>";
                return;
            }
            //判断文件后缀名
            string filename = fulStuImage.FileName.ToLower();
            filename = filename.Substring(filename.LastIndexOf("."));
            if ((filename != ".jpg")&&(filename != ".png"))
            {
                ltaMsg.Text = "<script type='text/javascript'>alert('图片后缀名必须为jpg或png')</script>";
                return;
            }
            //更改文件名
            filename = Convert.ToString(ViewState["id"])+".jpg";
            //获取文件路径
            string filepath=Server.MapPath("~/Images/Student");
            try
            {
                fulStuImage.SaveAs(filepath + "/" + filename);
                if (Request.QueryString["update"] == "1")
                    ltaMsg.Text = "<script type='text/javascript'>alert('头像更新成功');window.location.href='StudentManage.aspx'; </script>";
                else
                    ltaMsg.Text = "<script type='text/javascript'>alert('头像上传成功');window.location.href='AddStudent.aspx'; </script>";
            }
            catch (Exception ex)
            {
                ltaMsg.Text = "<script type='text/javascript'>alert('图片上传失败： "+ex.Message+"')</script>";
            }
        }


    }
}