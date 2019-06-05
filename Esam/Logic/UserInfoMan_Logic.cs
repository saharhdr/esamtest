using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Component;
using DataAccess.User;
using Esam.Models;

namespace Esam.Logic
{
    public class UserInfoMan_Logic
    {
        public string RequestCodeRegisetr(int UserID, string RequestString, int RefType)
        {
            User_cls_Service servic = new User_cls_Service();
            UserInfoMan_Logic logic = new UserInfoMan_Logic();

            return servic.RequestCodeRegister(UserID, RequestString, RefType);
        }
        public DataTable RequestCodeGet(int UserID, string RequestCode, int RefType)
        {
            User_cls_Service Service = new User_cls_Service();
            UserInfoMan_Logic Logic = new UserInfoMan_Logic();

            return Service.RequestCodeGet(UserID, RequestCode, RefType);
        }


        public Role GetRole(int userID)
        {
            SysClient sysClient = new SysClient();
            sysClient.UserID = userID;
            DataTable dt = null; //sysClient.GetRol();
            Role role = Role.Convert(dt);
            return role;
        }
        public DBmessage RegisterRole(int userID, Role role, int createBy)
        {
            User_cls_Service servic = new User_cls_Service();
            User_cls user = new User_cls() { UserID = userID, Roles = role, CreateBy = new User_cls() { UserID = createBy } };
            return servic.RegisterRole(user);
        }

        public DBmessage RegisterUser(User_cls user)
        {
            User_cls_Service servic = new User_cls_Service();

            DBmessage result = servic.Register(user);
            if (result.Type == DBMessageType.Sucsess)
            {
                result.Parameter["UserID"] = user.UserID;
            }
            return result;
        }
        public Models.ViewModel.CustomRegModel GetByUserID(int UserID)
        {
            User_cls_Service servic = new User_cls_Service();
            DataTable dt = servic.Get(UserID, "");

            return User_cls.Convert(dt);
        }

        public DBmessage UpdateVerifyAccount(int UserID, int VerifyAccount)
        {
            User_cls_Service servic = new User_cls_Service();
            return servic.UpdateVerifyAccount(UserID, VerifyAccount);
        }
    }

}