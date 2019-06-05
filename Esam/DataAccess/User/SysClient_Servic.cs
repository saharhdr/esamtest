using Component;
using Esam.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;


namespace DataAccess.User
{
    public class SysClient_Servic
    {
        public static bool Login(SysClient sysclient,int Status=0)
        {
            SqlConnection newcon = new SqlConnection(DBMan.EsamConnection);
            SqlCommand newcmd = new SqlCommand();
            SqlDataAdapter newda = new SqlDataAdapter();
            DataSet newds = new DataSet();
            if(Status==1)  newcmd = new SqlCommand("UserLoginHashPass", newcon);
            else newcmd = new SqlCommand("UserLogin", newcon);
            newcmd.CommandType = CommandType.StoredProcedure;

            SqlParameter _username = new SqlParameter("@Username", SqlDbType.NVarChar, 50);
            _username.Value = sysclient.Username;

            SqlParameter _pass = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            _pass.Value = sysclient.Password;

            SqlParameter _userid = new SqlParameter("@UserID", SqlDbType.Int);
            _userid.Direction = ParameterDirection.Output;

            SqlParameter _name = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            _name.Direction = ParameterDirection.Output;

            SqlParameter _family = new SqlParameter("@Family", SqlDbType.NVarChar, 50);
            _family.Direction = ParameterDirection.Output;

            //SqlParameter _cookiestring = new SqlParameter("@CookieString", SqlDbType.NVarChar, 50);
            //_cookiestring.Direction = ParameterDirection.Output;

            newcmd.Parameters.Add(_username);
            newcmd.Parameters.Add(_pass);
            newcmd.Parameters.Add(_userid);
            newcmd.Parameters.Add(_name);
            newcmd.Parameters.Add(_family);
            //newcmd.Parameters.Add(_cookiestring);
            newda.SelectCommand = newcmd;

            newcon.Open();
            newda.Fill(newds);
            newcon.Close();
            newcmd = newda.SelectCommand;

            if (newcmd.Parameters[_userid.ParameterName].Value.ToString() == "")
                return false;

            sysclient.UserID = Convert.ToInt32(newcmd.Parameters[_userid.ParameterName].Value);
            sysclient.Fname = newcmd.Parameters[_name.ParameterName].Value.ToString();
            sysclient.Lname = newcmd.Parameters[_family.ParameterName].Value.ToString();
            sysclient.FullName = sysclient.Fname + " " + sysclient.Lname;
            //sysclient.ClientInfo = newcmd.Parameters[_cookiestring.ParameterName].Value.ToString();


            return true;
        }

        public static DataTable GetRol(int userid)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("RolGet", new SqlConnection(DBMan.EsamConnection));
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter _userid = new SqlParameter("@UserID", SqlDbType.Int);
            _userid.Value = userid;

            cmd.Parameters.Add(_userid);

            da.SelectCommand = cmd;
            cmd.Connection.Open();
            da.Fill(dt);
            cmd.Connection.Close();

            return dt;
        }
    }
}
