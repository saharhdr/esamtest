using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Component;
using Esam.DataAccess;

namespace DataAccess.User
{
    public class User_cls_Service
    {
        public User_cls_Service()
        {
        }

        public DBmessage UpdateVerifyAccount(int UserID, int VerifyAccount)
        {
            SqlConnection newcon = new SqlConnection(DBMan.EsamConnection);
            SqlCommand newcmd = new SqlCommand("UserUpdateVirifyAccount", newcon);
            newcmd.CommandType = CommandType.StoredProcedure;

            SqlParameter _UserID = new SqlParameter("@UserID", SqlDbType.Int);
            DBMan.SetParameterValue(_UserID, UserID);

            SqlParameter _VerifyAccount = new SqlParameter("@VerifyAccount", SqlDbType.Int);
            DBMan.SetParameterValue(_VerifyAccount, VerifyAccount);

            newcmd.Parameters.Add(_UserID);
            newcmd.Parameters.Add(_VerifyAccount);
            newcmd.Parameters.Add(DBMan.RetunParam);

            newcon.Open();
            newcmd.ExecuteNonQuery();
            newcon.Close();
            DBmessage ResultMessage = new DBmessage(Convert.ToInt32(newcmd.Parameters[DBMan.ReturnValue].Value));
            return ResultMessage;
        }

        public string RequestCodeRegister(int UserID, string Requestcode,int RefType)
        {
            SqlConnection newcon = new SqlConnection(DBMan.EsamConnection);
            SqlCommand newcmd = new SqlCommand("RequestCodeRegister", newcon);
            newcmd.CommandType = CommandType.StoredProcedure;

            SqlParameter _Request = new SqlParameter("@Request", SqlDbType.NVarChar);
            DBMan.SetParameterValue(_Request, Requestcode);

            SqlParameter _UserID = new SqlParameter("@UserID", SqlDbType.Int);
            DBMan.SetParameterValue(_UserID, UserID);

            SqlParameter _RefType = new SqlParameter("@RefType", SqlDbType.Int);
            DBMan.SetParameterValue(_RefType, RefType);

            newcmd.Parameters.Add(_UserID);
            newcmd.Parameters.Add(_Request);
            newcmd.Parameters.Add(_RefType);
            newcmd.Parameters.Add(DBMan.RetunParam);

            newcon.Open();
            newcmd.ExecuteNonQuery();
            newcon.Close();

            string Request = (Convert.ToString(newcmd.Parameters[DBMan.ReturnValue].Value));

            return Request;
        }
        public DataTable RequestCodeGet(int userid, string RequestCode,int RefType)
        {
            SqlConnection conn = new SqlConnection(DBMan.EsamConnection);
            SqlCommand newcmd = new SqlCommand("RequestCodeGet", conn);
            newcmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(newcmd);
            DataTable dt = new DataTable();

            SqlParameter _UserID = new SqlParameter("@UserID", SqlDbType.Int);
            DBMan.SetParameterValue(_UserID, userid);

            SqlParameter _RequestCode = new SqlParameter("@Request", SqlDbType.NVarChar);
            DBMan.SetParameterValue(_RequestCode, RequestCode);

            SqlParameter _RefType = new SqlParameter("@RefType", SqlDbType.Int);
            DBMan.SetParameterValue(_RefType, RefType);

            da.SelectCommand.Parameters.Add(_UserID);
            da.SelectCommand.Parameters.Add(_RequestCode);
            da.SelectCommand.Parameters.Add(_RefType);
            da.SelectCommand.Parameters.Add(DBMan.RetunParam);

            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable Get(int userid, string username)
        {
            SqlConnection conn = new SqlConnection(DBMan.EsamConnection);
            SqlCommand newcmd = new SqlCommand("UserGet", conn);
            newcmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(newcmd);
            DataTable dt = new DataTable();

            SqlParameter _userid = new SqlParameter("@UsrID", SqlDbType.Int);
            DBMan.SetParameterValue(_userid, userid);
           
            SqlParameter _userName = new SqlParameter("@UserName", SqlDbType.NVarChar);
            DBMan.SetParameterValue(_userName, username);

            da.SelectCommand.Parameters.Add(_userid);
            da.SelectCommand.Parameters.Add(_userName);
          
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DBmessage Register(User_cls user)
        {
            SqlConnection newcon = new SqlConnection(DBMan.EsamConnection);
            SqlCommand newcmd = new SqlCommand("UserRegister", newcon);
            newcmd.CommandType = CommandType.StoredProcedure;

            SqlParameter _userid = new SqlParameter("@UsrID", SqlDbType.Int);
            _userid.Direction = ParameterDirection.Output;

            SqlParameter _username = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);
            DBMan.SetParameterValue(_username, user.Username);

            SqlParameter _password = new SqlParameter("@Password", SqlDbType.NVarChar, 100);
            DBMan.SetParameterValue(_password, user.Password);

            SqlParameter _name = new SqlParameter("@Fname", SqlDbType.NVarChar, 50);
            DBMan.SetParameterValue(_name, user.Fname);

            SqlParameter _family = new SqlParameter("@Lname", SqlDbType.NVarChar, 50);
            DBMan.SetParameterValue(_family, user.Lname);


            SqlParameter _email = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            DBMan.SetParameterValue(_email, user.Email);

            //SqlParameter _CreateBy = new SqlParameter("@CreateBy", SqlDbType.Int);
            //DBMan.SetParameterValue(_CreateBy, user.CreateBy);

            newcmd.Parameters.Add(_userid);
            newcmd.Parameters.Add(_username);
            newcmd.Parameters.Add(_password);
            newcmd.Parameters.Add(_name);
            newcmd.Parameters.Add(_family);
            newcmd.Parameters.Add(_email);
            //newcmd.Parameters.Add(_CreateBy);
            newcmd.Parameters.Add(DBMan.RetunParam);

            newcon.Open();
            newcmd.ExecuteNonQuery();
            newcon.Close();
            user.UserID = Convert.ToInt32(newcmd.Parameters[_userid.ParameterName].Value);
            DBmessage ResultMessage = new DBmessage(Convert.ToInt32(newcmd.Parameters[DBMan.ReturnValue].Value));
            return ResultMessage;
        }

        public DBmessage RegisterRole(User_cls user)
        {
            SqlCommand cmd = new SqlCommand("RoleRegister", new SqlConnection(DBMan.EsamConnection));
            cmd.CommandType = CommandType.StoredProcedure;
          
            SqlParameter _admin = new SqlParameter("@Admin", SqlDbType.Bit);
            SqlParameter _customer = new SqlParameter("@Customer", SqlDbType.Bit);
            if (user.Roles != null)
            {
                _admin.Value = user.Roles[RoleType.Admin];
                _customer.Value = user.Roles[RoleType.Customer];
            }
            else
            {
                _admin.Value = DBNull.Value;
                _customer.Value = DBNull.Value;
            }
            SqlParameter _userID = new SqlParameter("@UserID", SqlDbType.Int);
            DBMan.SetParameterValue(_userID, user);

            SqlParameter _CreateBy = new SqlParameter("@CreateBy", SqlDbType.Int);
            _CreateBy.Value = user.CreateBy.UserID;
          
            cmd.Parameters.Add(_userID);
            cmd.Parameters.Add(_admin);
            cmd.Parameters.Add(_customer);
            cmd.Parameters.Add(_CreateBy);
            cmd.Parameters.Add(DBMan.RetunParam);
          
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return new DBmessage(System.Convert.ToInt32(cmd.Parameters[DBMan.ReturnValue].Value));
        }

    }
}
