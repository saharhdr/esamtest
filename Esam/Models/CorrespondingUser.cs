using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class CorrespondingUser
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string AlternativeUserName { get; set; }
        public string AlternativePassword { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        //
        public static List<CorrespondingUser> Convert(DataTable dt)
        {
            List<CorrespondingUser> result = new List<CorrespondingUser>();
            CorrespondingUser temp = null;
            foreach (DataRow item in dt.Rows)
            {
                temp = new CorrespondingUser();
                if (item.Table.Columns.Contains("ID") && item["ID"] != null)
                    temp.ID = System.Convert.ToInt32(item["ID"].ToString());
                if (item.Table.Columns.Contains("UserID") && item["UserID"] != null)
                    temp.UserID = System.Convert.ToInt32(item["UserID"].ToString());
                if (item.Table.Columns.Contains("AlternativeUserName") && item["AlternativeUserName"] != null)
                    temp.AlternativeUserName = item["AlternativeUserName"].ToString();
                if (item.Table.Columns.Contains("AlternativePassword") && item["AlternativePassword"] != null)
                    temp.AlternativePassword = item["AlternativePassword"].ToString();
                if (item.Table.Columns.Contains("Description") && item["Description"] != null)
                    temp.Description = item["Description"].ToString();
                if (item.Table.Columns.Contains("Type") && item["Type"] != null)
                    temp.Type = System.Convert.ToInt32(item["Type"].ToString());
                result.Add(temp);
            }
            return result;
        }
    }
    public static class CorrespondingUserType
    {
        /// <summary>
        /// اساتید در سیستم آموزش
        /// </summary>
        public static int Teacher
        {
            get { return 1; }
        }
        /// <summary>
        /// کارکنان در سیستم حضور و غیاب
        /// </summary>
        public static int Personnel
        {
            get { return 2; }
        }
        /// <summary>
        /// مدیر گروه ها
        /// </summary>
        public static int DepartmentHead
        {
            get { return 3; }
        }
        /// <summary>
        /// دانشجویان در سیستم آموزش
        /// </summary>
        public static int Student
        {
            get { return 4; }
        }
        /// <summary>
        /// سیستم پیغام
        /// </summary>
        public static int Message
        {
            get { return 5; }
        }
        /// <summary>
        /// دفتر نظارت و ارزیابی
        /// </summary>
        public static int AmoozeshAdmin
        {
            get { return 6; }
        }
        /// <summary>
        /// کارمندان آموزش
        /// </summary>
        public static int AmoozeshEmployee
        { get { return 7; } }
    }
}