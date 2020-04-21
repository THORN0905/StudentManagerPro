using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DAL.Helper
{

    class SQLServerHelper
    {

        private static string connstr = ConfigurationManager.ConnectionStrings["connstr"].ToString();


        #region 不带参数的SQL语句
        //增删改操作
        public int update(string sql, bool isStoreProcedure)
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (isStoreProcedure)
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                writeLog("调用public int update(string sql)时出现错误："+ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        //返回单一结果
        public static object getSingleResult(string sql, bool isStoreProcedure)
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (isStoreProcedure)
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                writeLog("调用public static object getSingleResult(string sql)时出现错误：" + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }

        }

        //返回查询结果集
        public static SqlDataReader getAllResults(string sql, bool isStoreProcedure)
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (isStoreProcedure)
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                writeLog("调用public static SqlDataReader getAllResults(string sql)出现错误：" + ex.Message);
                throw;
            }
        }


        #endregion


         #region 带参数的SQL语句

        //增删改操作
        public static int update(String sql, SqlParameter[] param,bool isStoreProcedure)
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (isStoreProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                writeLog("调用public static int update(String sql, SqlParameter[] param)时出错：" + ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }
        }


        //查询返回单一结果
        public static object getSingleResult(string sql, SqlParameter[] param, bool isStoreProcedure)
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (isStoreProcedure)
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                writeLog("调用 public static object getSingleResult(string sql, SqlParameter[] param)时出错：" + ex.Message);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        //查询结果返回结果集
        public static SqlDataReader getAllResults(string sql, SqlParameter[] param,bool isStoreProcedure)
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            if (isStoreProcedure)
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                writeLog("调用public static SqlDataReader getAllResult(string sql, SqlParameter[] param)时出现错误：" + ex.Message);
                throw ex;
            }
        }
        
        #endregion


        #region 写入日志
        private static void writeLog(String msg)
        {
            FileStream fs = new FileStream("D:/网络教育资源设计与开发/ASP.NET Files/StudentManagerPro_Log/ProjectLog.log", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + msg);
            sw.Close();
            fs.Close();
        }

        #endregion



    }
}
