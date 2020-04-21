using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public  class StudentClassService
    {
        public  List<StudentClass> queryAllClass(){
            string  sql = "select *from StudentClass";
            SqlDataReader result = Helper.SQLServerHelper.getAllResults(sql,false);
            List<StudentClass> list=new List<StudentClass>();
            while (result.Read())
            {
                list.Add(new StudentClass()
                {
                    ClassId=Convert.ToInt32(result["ClassId"]),
                    ClassName=result["ClassName"].ToString()
                });
            }
            result.Close();
            return list;
        }
        

    }
}
