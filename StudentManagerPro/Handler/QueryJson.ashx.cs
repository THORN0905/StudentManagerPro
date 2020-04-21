using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Models;
using System.Web.Script.Serialization;

namespace StudentManagerPro.Handler
{
    /// <summary>
    /// QueryJson 的摘要说明
    /// </summary>
    public class QueryJson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string ClassName = context.Request.Params["ClassName"];
            int ClassId = Convert.ToInt32(context.Request.Params["ClassId"]);
            List<StudentExt> stus = new StudentServices().QueryStudentsByClass(ClassId);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string stulist = jss.Serialize(stus);
            context.Response.Write(stulist);
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