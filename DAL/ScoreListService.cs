using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ScoreListService
    {
        public List<StudentExt> getScoreList(int ClassId)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@ClassId",ClassId)
            };
            List<StudentExt> stu = new List<StudentExt>();
            SqlDataReader result = Helper.SQLServerHelper.getAllResults("usp_QueryScoreByClassId",param,true);
            try
            {
                while (result.Read())
                {
                    stu.Add(new StudentExt
                    {
                        StudentId = Convert.ToInt32(result["StudentId"]),
                        StudentName = result["StudentName"].ToString(),
                        Gender=result["Gender"].ToString(),
                        CSharp=result["CSharp"].ToString(),
                        SQLServerDB=result["SQLServerDB"].ToString(),
                        ClassName = result["ClassName"].ToString(),
                        StudentIdNo = result["StudentIdNo"].ToString(),
                        Birthday = Convert.ToDateTime(result["Birthday"]),
                        PhoneNumber = result["PhoneNumber"].ToString(),
                        StudentAddress = result["StudentAddress"].ToString()
                    });                    
                }
                return stu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
