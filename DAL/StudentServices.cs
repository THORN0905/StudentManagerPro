using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Models;

namespace DAL
{
    public class StudentServices
    {

        /// <summary>
        /// 查询学生是否存在
        /// </summary>
        /// <param name="StudentIdNo">学生身份证号</param>
        /// <returns>存在为true，不存在为false</returns>
        public static bool isExistedStudent(string StudentIdNo)
        {
            string sql = "select count(*) from Students where StudentIdNo=@StudentIdNo";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@StudentIdNo",StudentIdNo)
            };
            int result = Convert.ToInt32(Helper.SQLServerHelper.getSingleResult(sql, para, false));
            if (result > 0)
                return true;
            else
                return false;
        }

        
        /// <summary>
        /// 增加学生信息
        /// </summary>
        /// <param name="stu">参数</param>
        /// <returns>返回学生学号</returns>
        public static int AddStudent(Student stu)
        {
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@StudentName",stu.StudentName),
                new SqlParameter("@Gender",stu.Gender),
                new SqlParameter("@Birthday",stu.Birthday),
                new SqlParameter("@StudentIdNo",stu.StudentIdNo),
                new SqlParameter("@PhoneNumber",stu.PhoneNumber),
                new SqlParameter("@StudentAddress",stu.StudentAddress),
                new SqlParameter("@ClassId",stu.ClassId),
            };
            return Convert.ToInt32(Helper.SQLServerHelper.getSingleResult("usp_addStudent", para, true));
        }


        /// <summary>
        /// 按班级查询学生信息
        /// </summary>
        /// <param name="ClassName">班级名</param>
        /// <returns>学生信息集合</returns>
        public List<StudentExt> QueryStudentsByClass(int ClassId)
        {
            string sql = "Select StudentId,StudentName,ClassName,Gender,Birthday,StudentAddress from Students ";
            sql += "join StudentClass on StudentClass.ClassId=Students.ClassId ";
            sql += " where Students.ClassId=@ClassId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ClassId",ClassId)
            };
            List<StudentExt> StuList = new List<StudentExt>();
            SqlDataReader result = Helper.SQLServerHelper.getAllResults(sql, param, false);
            while (result.Read())
            {
                StuList.Add(new StudentExt()
                {
                    StudentId=Convert.ToInt32(result["StudentId"]),
                    StudentName = result["StudentName"].ToString(),
                    ClassName = result["ClassName"].ToString(),
                    Gender = result["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(result["Birthday"]),
                    StudentAddress = result["StudentAddress"].ToString()
                });
            }
            result.Close();
            return StuList;
        }


        /// <summary>
        /// 按学号查找学生
        /// </summary>
        /// <param name="StuId">学号</param>
        /// <returns>学生个人信息</returns>
        public StudentExt QueryStudentById(int StuId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select StudentId,StudentName,Gender,Birthday,ClassName,StudentIdNo,Students.ClassId,PhoneNumber,StudentAddress");
            sql.Append(" from Students join StudentClass on Students.ClassId=StudentClass.ClassId");
            sql.Append(" where StudentId=@StuId");
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@StuId",StuId)
            };
            SqlDataReader result = Helper.SQLServerHelper.getAllResults(sql.ToString(),param,false);
            StudentExt stu = null;
            if (result.Read())
            {
                stu = new StudentExt
                {
                    StudentId=Convert.ToInt32(result["StudentId"]),
                    StudentName = result["StudentName"].ToString(),
                    Gender = result["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(result["Birthday"]),
                    ClassName = result["ClassName"].ToString(),
                    StudentIdNo = result["StudentIdNo"].ToString(),
                    ClassId = Convert.ToInt32(result["ClassId"]),
                    PhoneNumber = result["PhoneNumber"].ToString(),
                    StudentAddress = result["StudentAddress"].ToString(),
                };
            }
            result.Close();
            return stu;
        }


        /// <summary>
        /// 修改时判断数据库中是否存在其他相同的身份证号
        /// </summary>
        /// <param name="StudentIdNo"></param>
        /// <param name="stuId"></param>
        /// <returns></returns>
        public static bool isExistedStudent(string StudentIdNo, int stuId)
        {
            string sql = "select count(*) from Students where StudentIdNo=@StudentIdNo and StudentId<>@StudentId";
            SqlParameter[] para = new SqlParameter[]{
                new SqlParameter("@StudentIdNo",StudentIdNo),
                new SqlParameter("@StudentId",stuId)
            };
            int result = Convert.ToInt32(Helper.SQLServerHelper.getSingleResult(sql, para, false));
            if (result > 0)
                return true;
            else
                return false;
        }


        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="stu">新的学生信息</param>
        /// <returns>成功为1，失败为0</returns>
        public int updateStudent(Student stu)
        {
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@StudentName",stu.StudentName),
                new SqlParameter("@Gender",stu.Gender),
                new SqlParameter("@Birthday",stu.Birthday),
                new SqlParameter("@StudentIdNo",stu.StudentIdNo),
                new SqlParameter("@PhoneNumber",stu.PhoneNumber),
                new SqlParameter("@StudentAddress",stu.StudentAddress),
                new SqlParameter("@ClassId",stu.ClassId),
                new SqlParameter("@StudentId",stu.StudentId)
            };

            return Convert.ToInt32(Helper.SQLServerHelper.update("usp_updateStudent", param, true));
        }


        /// <summary>
        /// 按学号删除学生
        /// </summary>
        /// <param name="StuId">学号</param>
        /// <returns></returns>
        public int deleteStudent(int StuId)
        {
            string sql = "delete from Students where StudentId=@StuId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@StuId",StuId)
            };
            try
            {
                return Helper.SQLServerHelper.update(sql, param, false);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("该学号被其他实体引用，无法直接删除！");
                else
                    throw new Exception("数据库异常！");
            }
            catch (Exception ex){
                throw new Exception("数据库操作异常！");
                throw ex;
            }
            
        }
    }
}
