using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Models;


namespace StudentManagerPro
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            int LoginId = Convert.ToInt32(txtUserId.Text);
            String LoginPwd = Convert.ToString(txtPwd.Text).Trim();
            SysAdmin user = new SysAdmin();
            user.LoginId = LoginId;
            user.LoginPwd = LoginPwd;
            user = AdminServices.LoginCheck(user);
            if (user == null)
                ltaInfo.Text = "<script type='text/javascript'> alert('账号或密码错误，请重试！')</script>";
            else
            {
                Session["CurrentUser"] = user;
                Response.Redirect("~/Default.aspx");
            }
               

        }
    }
}