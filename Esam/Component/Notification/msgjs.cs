using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
namespace Component
{
    public class msgjs
    {
        public static string jsmodel(string message, int type, string title, bool close = true)
        {
            return "showmodal('" + message + "', 1, '" + title + "', " + close + ");";
        }
        public static string jsalert(string message, int type, int time,string redirect)
        {
            return "showalert('" + message + "'," + type + "," + time +","+redirect+ ",1);";
        }
        public static string jsalert(string message, int type, int time)
        {
            return "showalert('" + message + "'," + type + "," + time +",'',0);";
        }
    }

}