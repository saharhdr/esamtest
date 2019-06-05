using DataAccess.User;
using Esam.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace Esam.Logic
{
    public class userauthorizeMan_Logic
    {
        public userauthorizeMan_Logic()
        {
        }

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
            if (SysClient_Servic.Login(SysProperty.Client,1))
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
            return false;
        }
        public void Logout()
        {
            SysProperty.Client = new SysClient();
            HttpContext.Current.Response.Redirect(ServerDirectory.Host+ "/userauthorize/signup");
        }
        public void Logoutwithoutredirect()
        {
            SysProperty.Client = new SysClient();
        }
    }
}