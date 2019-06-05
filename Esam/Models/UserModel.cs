using Component;
using Esam.DataAccess;
using Esam.Logic;
using Esam.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Esam.Models
{
    public class UserModel
    {
        #region
        protected int _UserID;
        protected string _UserName;
        protected string _Password;
        protected int _UsrStatus;
        protected string _Fname;
        protected string _Lname;
        protected string _Mobile;
        protected string _Email;
        protected string _Phone;
        protected bool _Active;
        protected Role _Roles;
        protected PersianDateTime _CreateDate;
        protected VerifyAccountType _VerifyAccount;
        protected string _FulLname;
        #endregion

        #region 
        public string Fname
        {
            get { return _Fname; }
            set { value = value.Trim(); _Fname = value; }
        }
        public string Lname
        {
            get { return _Lname; }
            set { value = value.Trim(); _Lname = value; }
        }
        public int UserID
        {
            set { _UserID = value; }
            get { return _UserID; }
        }
        public string UserName
        {
            set { value = value.Trim(); _UserName = value; }
            get { return _UserName; }
        }
        public string Password
        {
            set { value = value.Trim(); _Password = value; }
            get { return _Password; }
        }
        public int UsrStatus
        {
            get { return _UsrStatus; }
            set { _UsrStatus = value; }
        }
        public VerifyAccountType VerifyAccount
        {
            get { return _VerifyAccount; }
            set { _VerifyAccount = value; }
        }
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        public string FulLname
        {
            set { value = value.Trim(); _FulLname = value; }
            get { return _FulLname; }
        }
        public string Phone
        {
            set { _Phone = value; }
            get { return _Phone; }
        }
        public string Email
        {
            set { _Email = value; }
            get { return _Email; }
        }
        public Role Roles
        {
            get
            {
                return _Roles;
            }

            set
            {
                _Roles = value;
            }
        }
        public string Mobile
        {
            get
            {
                return _Mobile;
            }

            set
            {
                _Mobile = value;
            }
        }
        public PersianDateTime CreateDate
        {
            get
            {
                return _CreateDate;
            }

            set
            {
                _CreateDate = value;
            }
        }
        #endregion
     
        public UserModel()
        {
        }
    }

    namespace DataAccess
    {
        internal static class UserModelDataProvider
        {
            #region Helper Methods
            public static UserModel GetObjectFromDataReader(SqlDataReader reader)
            {
                UserModel Value = new UserModel();
                if (reader != null && !reader.IsClosed)
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("UserID"))) Value.UserID = reader.GetInt32(reader.GetOrdinal("UserID"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UserName"))) Value.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Password"))) Value.Password = reader.GetString(reader.GetOrdinal("Password"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UsrStatus"))) Value.UsrStatus = reader.GetInt32(reader.GetOrdinal("UsrStatus"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Fname"))) Value.Fname = reader.GetString(reader.GetOrdinal("Fname"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Lname"))) Value.Lname = reader.GetString(reader.GetOrdinal("Lname"));
                    if (!reader.IsDBNull(reader.GetOrdinal("FulLname"))) Value.FulLname = reader.GetString(reader.GetOrdinal("FulLname"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Mobile"))) Value.Mobile = reader.GetString(reader.GetOrdinal("Mobile"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Email"))) Value.Email = reader.GetString(reader.GetOrdinal("Email"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Phone"))) Value.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Active"))) Value.Active = reader.GetBoolean(reader.GetOrdinal("Active"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VerifyAccount"))) Value.VerifyAccount =new VerifyAccountType(reader.GetInt32(reader.GetOrdinal("VerifyAccount")));
                    if (!reader.IsDBNull(reader.GetOrdinal("CreateDate"))) Value.CreateDate = new PersianDateTime(reader.GetDateTime(reader.GetOrdinal("CreateDate")));

                    return Value;
                }
                return null;
            }

            #endregion Helper Methods

            #region Select Methods

            public static bool Login(SysClient sysclient)
            {
                SqlConnection newcon = new SqlConnection(DBMan.EsamConnection);
                SqlCommand newcmd = new SqlCommand();
                SqlDataAdapter newda = new SqlDataAdapter();
                DataSet newds = new DataSet();
                newcmd = new SqlCommand("UserLogin", newcon);
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

                SqlParameter _cookiestring = new SqlParameter("@CookieString", SqlDbType.NVarChar, 50);
                _cookiestring.Direction = ParameterDirection.Output;

                newcmd.Parameters.Add(_username);
                newcmd.Parameters.Add(_pass);
                newcmd.Parameters.Add(_userid);
                newcmd.Parameters.Add(_name);
                newcmd.Parameters.Add(_family);
                newcmd.Parameters.Add(_cookiestring);
                newda.SelectCommand = newcmd;

                newcon.Open();
                newda.Fill(newds);
                newcon.Close();
                newcmd = newda.SelectCommand;
                sysclient.UserID = Convert.ToInt32(newcmd.Parameters[_userid.ParameterName].Value);
                sysclient.Fname = newcmd.Parameters[_name.ParameterName].Value.ToString();
                sysclient.Lname = newcmd.Parameters[_family.ParameterName].Value.ToString();
                sysclient.FullName = sysclient.Fname + " " + sysclient.Lname;
                sysclient.ClientInfo = newcmd.Parameters[_cookiestring.ParameterName].Value.ToString();

                if (sysclient.Fname == "")
                    return false;
                else
                    return true;
            }
            public static bool LoginHashPassword(SysClient sysclient)
            {
                SqlConnection newcon = new SqlConnection(DBMan.EsamConnection);
                SqlCommand newcmd = new SqlCommand();
                SqlDataAdapter newda = new SqlDataAdapter();
                DataSet newds = new DataSet();
                newcmd = new SqlCommand("UserLoginHashPass", newcon);
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

                SqlParameter _cookiestring = new SqlParameter("@CookieString", SqlDbType.NVarChar, 50);
                _cookiestring.Direction = ParameterDirection.Output;

                newcmd.Parameters.Add(_username);
                newcmd.Parameters.Add(_pass);
                newcmd.Parameters.Add(_userid);
                newcmd.Parameters.Add(_name);
                newcmd.Parameters.Add(_family);
                newcmd.Parameters.Add(_cookiestring);
                newda.SelectCommand = newcmd;

                newcon.Open();
                newda.Fill(newds);
                newcon.Close();
                newcmd = newda.SelectCommand;
                sysclient.UserID = Convert.ToInt32(newcmd.Parameters[_userid.ParameterName].Value);
                sysclient.Fname = newcmd.Parameters[_name.ParameterName].Value.ToString();
                sysclient.Lname = newcmd.Parameters[_family.ParameterName].Value.ToString();
                sysclient.FullName = sysclient.Fname + " " + sysclient.Lname;
                sysclient.ClientInfo = newcmd.Parameters[_cookiestring.ParameterName].Value.ToString();
                if (newds.Tables.Count != 0)
                {
                    if (newds.Tables[0].Rows.Count != 0)
                    {

                    }
                }
                if (sysclient.Fname == "")
                    return false;
                else
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

            #endregion Select Methods

            #region Insert Methods
            public static int Insert(UserModel Value)
            {
                SqlCommand Cmd = new SqlCommand("ShippingCostRegister", new SqlConnection(DBMan.EsamConnection));
                Cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter _RefID = new SqlParameter("@RefID", SqlDbType.Int);
                DBMan.SetParameterValue(_RefID, Value.RefID.ID);

                SqlParameter _Cost = new SqlParameter("@Cost", SqlDbType.Decimal);
                DBMan.SetParameterValue(_Cost, Value.Cost);

                SqlParameter _Description = new SqlParameter("@Description", SqlDbType.NVarChar);
                DBMan.SetParameterValue(_Description, Value.Description);

                SqlParameter _Status = new SqlParameter("@Status", SqlDbType.Int);
                DBMan.SetParameterValue(_Status, Value.Status);

                Cmd.Parameters.Add(_RefID);
                Cmd.Parameters.Add(_Cost);
                Cmd.Parameters.Add(_Description);
                Cmd.Parameters.Add(_Status);

                try
                {
                    Cmd.Connection.Open();
                    return GeneralTable.ExecuteCommand(Cmd);
                }
                finally
                {
                    Cmd.Connection.Close();
                }
            }
            #endregion Insert Methods

       
        }
    }

    namespace BusinessLogic
    {
        public static class UserModelProvider
        {


            public Role GetRol(int userid)
            {
                DataTable dt = SysClient_Servic.GetRol(userid);
                if (dt.Rows.Count > 1)
                    throw new Exception("role table for this client is more than one record!!! this is invalid data");
                return Role.Convert(dt);
            }
            public bool Login(string username, string password)
            {
                SysProperty.Client.Username = username;
                SysProperty.Client.Password = password;
                if (SysClient_Servic.Login(SysProperty.Client))
                {
                    userauthorizeMan_Logic u = new userauthorizeMan_Logic();
                    SysProperty.Client.Roles = u.GetRol(SysProperty.Client.UserID);
                    return true;
                }
                SysProperty.Client = new SysClient();
                return false;
            }

            public bool LoginHashPassword(string username, string password)
            {
                SysProperty.Client.Username = username;
                SysProperty.Client.Password = password;
                if (SysClient_Servic.LoginHashPassword(SysProperty.Client))
                {
                    userauthorizeMan_Logic u = new userauthorizeMan_Logic();
                    SysProperty.Client.Roles = u.GetRol(SysProperty.Client.UserID);
                    return true;
                }
                SysProperty.Client = new SysClient();
                return false;
            }

            public bool SessionCheck()
            {
                SysClient session = SysProperty.Client;
                //return session.SessionCheck();
                return false;
            }
            public void Logout()
            {
                SysProperty.Client = new SysClient();
                HttpContext.Current.Response.Redirect(ServerDirectory.Host + "/home/index");
            }
            public void Logoutwithoutredirect()
            {
                SysProperty.Client = new SysClient();
            }


            #region Select Methods
            public static List<UserModel> List(int ID, int RefID)
            {
                return UserModelDataProvider.List(ID, RefID);
            }

            public static long GetCost(int RefID)
            {
                return UserModelDataProvider.GetCost(RefID);
            }

            #endregion Select Methods

            #region Insert Methods
            public static int Insert(UserModel Value)
            {
                return UserModelDataProvider.Insert(Value);
            }
            #endregion Insert Methods

            #region Upadet Methods
            public static int Update(UserModel Value)
            {
                return UserModelDataProvider.Update(Value);
            }
            #endregion Update Methods

        }
    }


    public class RequestCodeType
    {
        int _ID;
        string _Title;

        public int ID
        {
            get
            {
                return _ID;
            }
        }

        public string Title
        {
            get
            {
                return _Title;
            }

            set
            {
                _Title = value;
            }
        }

        public RequestCodeType()
        {
        }

        public static int ForgotPassword
        { get { return 1; } }
        public static int ConfirmMobile
        { get { return 2; } }
        public static int ConfirmEmail
        { get { return 3; } }

    }

    public class VerifyAccountType
    {
        int _ID;
        string _Title;

        public int ID
        {
            get
            {
                return _ID;
            }
        }

        public string Title
        {
            get
            {
                return _Title;
            }

            set
            {
                _Title = value;
            }
        }

        public VerifyAccountType(int ID)
        {
            this._Title = Convert(ID);
            this._ID = ID;
        }

        public static string Convert(int id)
        {
            switch (id)
            {
                case 0:
                    return "تایید نشده";
                case 2:
                    return "تایید شماره همراه";
                case 3:
                    return "تایید پست الکترونیکی";
                case 4:
                    return "تایید شماره همراه و پست الکترونیکی";
                default:
                    return "تایید نشده";
            }
        }

        public static int NotVerified
        { get { return 0; } }
        public static int VerifybyMobile
        { get { return 2; } }
        public static int VerifybyEmail
        { get { return 3; } }
        public static int VerifybyEmailandMob
        { get { return 4; } }
    }

}

