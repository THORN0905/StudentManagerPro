using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace StudentManagerPro
{
    public partial class MainPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Currentuser"]==null)
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
            else
            {
                SysAdmin user=(SysAdmin)Session["Currentuser"];
                ltaUserName.Text = "欢迎您：" + user.AdminName;
            }
        }
    }
}