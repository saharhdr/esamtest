using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using Component;

namespace Esam.DataAccess
{
    public class DBMan
    {
        public static string EsamConnection
        {
            get { return System.Web.Configuration.WebConfigurationManager.ConnectionStrings["EsamConnection"].ConnectionString; }
        }

        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataAdapter da;
        protected DataTable dt;
        protected DBmessage ResultMessage;
        public static SqlParameter RetunParam
        {
            get
            {
                SqlParameter _returnvalue = new SqlParameter();
                _returnvalue.ParameterName = ReturnValue;
                _returnvalue.Direction = ParameterDirection.ReturnValue;
                return _returnvalue;
            }
        }
        static public string ReturnValue
        { get { return "ReturnValue"; } }
        protected SqlParameter CreateBy
        {
            get
            {
                SqlParameter result = new SqlParameter("@CreateBy", SqlDbType.Int);
                result.Value = SysProperty.Client.UserID;
                return result;
            }
        }
        protected DBMan()
        {


        }
        
        public static SqlParameter SetParameterValue(SqlParameter param, int value)
        {
            if (value == 0)
                param.Value = DBNull.Value;
            else
                param.Value = value;
            return param;
        }
        public static SqlParameter SetParameterValue(SqlParameter param, int value,int status)
        {
            if (status == -1)
            {
                if (value == 0)
                    param.Value = 0;
                else
                    param.Value = value;
            }
            if (value == 0)
                param.Value = DBNull.Value;
            else
                param.Value = value;
            return param;
        }
     
        public static SqlParameter SetParameterValue(SqlParameter param, long value)
        {
            if (value == 0)
                param.Value = DBNull.Value;
            else
                param.Value = value;
            return param;
        }
        public static SqlParameter SetParameterValue(SqlParameter param, string value)
        {
            if (value == "" || value == null || value == string.Empty)
                param.Value = DBNull.Value;
            else
                param.Value = value;
            return param;
        }
        public static SqlParameter SetParameterValue(SqlParameter param, PersianDateTime value)
        {
            if (value == null)
                param.Value = DBNull.Value;
            else
                param.Value = value.Datetime;
            return param;
        }
        public static SqlParameter SetParameterValue(SqlParameter param, bool value)
        {
            param.Value = value;
            return param;
        }
        public static SqlParameter SetParameterValue(SqlParameter param, decimal value)
        {
            param.Value = value;
            return param;
        }
        public static SqlParameter SetParameterValue(SqlParameter param, User_cls value)
        {
            if (value == null)
                param.Value = DBNull.Value;
            else
            {
                SetParameterValue(param, value.UserID);
            }
            return param;
        }

    }
}
