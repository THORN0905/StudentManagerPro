using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using DAL;
using Models;
using NPOI.SS.UserModel;

namespace StudentManagerPro.Handler
{
    /// <summary>
    /// ExportToExcel 的摘要说明
    /// </summary>
    public class ExportToExcel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/x-excel";
            //将HTTP头添加到输出流，设置默认导出的文件名
            string ClassName = context.Request.QueryString["ClassName"].ToString();
            string filename = HttpUtility.UrlEncode(ClassName+"学生成绩表.xls");
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            //创建Excel工作簿和工作表
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet newsheet = workbook.CreateSheet("学生成绩表");
            //创建工作表的标题
            IRow rowHeader = newsheet.CreateRow(0);
            rowHeader.CreateCell(0, CellType.Numeric).SetCellValue("学号");
            rowHeader.CreateCell(1,CellType.String).SetCellValue("姓名");
            rowHeader.CreateCell(2, CellType.String).SetCellValue("性别");
            rowHeader.CreateCell(3, CellType.String).SetCellValue("班级");
            rowHeader.CreateCell(4, CellType.Numeric).SetCellValue("C#成绩");
            rowHeader.CreateCell(5, CellType.Numeric).SetCellValue("SQL Server成绩");
            //查询数据
            int ClassId = Convert.ToInt32(context.Request.QueryString["ClassId"]);
            List<StudentExt> stuScoreList = new ScoreListService().getScoreList(ClassId);
            //循环创建数据行
            for (int i = 0; i < stuScoreList.Count; i++)
            {
                IRow newRow = newsheet.CreateRow(i+1);
                newRow.CreateCell(0, CellType.Numeric).SetCellValue(stuScoreList[i].StudentId);
                newRow.CreateCell(1, CellType.Numeric).SetCellValue(stuScoreList[i].StudentName);
                newRow.CreateCell(2, CellType.Numeric).SetCellValue(stuScoreList[i].Gender);
                newRow.CreateCell(3, CellType.Numeric).SetCellValue(stuScoreList[i].ClassName);
                newRow.CreateCell(4, CellType.Numeric).SetCellValue(stuScoreList[i].CSharp);
                newRow.CreateCell(5, CellType.Numeric).SetCellValue(stuScoreList[i].SQLServerDB);
            }
            //将输出流写入Excel工作簿
            workbook.Write(context.Response.OutputStream);

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