using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        //将数据库中的18位整数转换成字符串
        public string StudentIdNo { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentAddress { get; set; }
        public int ClassId { get; set; }
    }
}