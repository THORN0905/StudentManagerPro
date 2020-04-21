using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;
using DAL.Helper;

namespace DAL
{
    public class AdminServices
    {
        public static SysAdmin LoginCheck(SysAdmin user)
        {
            String sql = "select AdminName from Admins where LoginId=@LoginId and LoginPwd=@LoginPwd";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("LoginId",user.LoginId),
                new SqlParameter("LoginPwd",user.LoginPwd)
            };
            object name = SQLServerHelper.getSingleResult(sql, param,false);
            if (name == null)
                user = null;
            else
                user.AdminName = Convert.ToString(name);
            return user;
        }

        public static int ChangePwd(SysAdmin user,string newPwd)
        {
            string sql = "update Admins set LoginPwd = @newpwd where LoginId=@LoginId";
             SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("newpwd",newPwd),
                new SqlParameter("LoginId",user.LoginId)
            };
            return SQLServerHelper.update(sql, param,false);
        }
    }
}
