using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Models;
using System.Web.SessionState;

namespace StudentManagerPro.Handler
{
    /// <summary>
    /// AdminLogin 的摘要说明
    /// </summary>
    public class AdminLogin : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            System.Threading.Thread.Sleep(3000);
            int username = Convert.ToInt32(context.Request.Params["username"]);
            string password = context.Request.Params["password"];
            SysAdmin user = new SysAdmin()
            {
                LoginId = username,
                LoginPwd = password
            };
            try
            {
                SysAdmin admin = AdminServices.LoginCheck(user);
                            if (admin == null)
                                context.Response.Write(0);
                            else
                            {
                                context.Session["CurrentUser"] = admin;
                                context.Response.Write(1);
                            }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}