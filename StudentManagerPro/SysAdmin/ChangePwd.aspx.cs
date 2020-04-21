using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Models;

namespace StudentManagerPro
{
    public partial class ChangePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            SysAdmin user = new SysAdmin();
            user = (SysAdmin)Session["Currentuser"];
            string newpwd = txtNewPwd.Text.Trim();
            string oldpwd = txtOldPwd.Text.Trim();
            try
            {
                if (user.LoginPwd != oldpwd)
                    ltaMsg.Text = "<script>alert('原密码错误！')</script>";
                else
                {
                    AdminServices.ChangePwd(user, newpwd);
                    Session["Currentuser"] = user;
                    ltaMsg.Text = "<script>alert('修改成功！');location='../Default.aspx'</script>";
                }
            }
            catch (Exception ex)
            {
                ltaMsg.Text = "<script>alert('"+ex.Message+"')</script>";
                throw ex;
            }
            
        }
      
    }
}