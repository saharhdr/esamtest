using Component;
using Esam.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class User_cls
{
    #region attribute
    public int _userid;
    public string _username;
    public string _password;
    public int _UsrStatus;
    public string _fname;
    public string _lname;
    public string _email;
    public bool _active;
    public string _fullname;
    User_cls _CreateBy;
    Role _roles;
    public VerifyAccountType _VerifyAccount;
    #endregion

    #region property
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
        get { return _active; }
        set { _active = value; }
    }
    public int UserID
    {
        set { _userid = value; }
        get { return _userid; }
    }
    public string Username
    {
        set { _username = value; }
        get { return _username; }
    }
    public string Password
    {
        set { value = value.Trim(); _password = value; }
        get { return _password; }
    }
    public string Fname
    {
        get { return _fname; }
        set { value = value.Trim(); _fname = value; }
    }
    public string Lname
    {
        get { return _lname; }
        set { value = value.Trim(); _lname = value; }
    }
    public string FullName
    {
        set { value = value.Trim(); _fullname = value; }
        get { return _fullname; }
    }
    public string Email
    {
        set { _email = value; }
        get { return _email; }
    }
    public User_cls CreateBy
    {
        get
        {
            return _CreateBy;
        }

        set
        {
            _CreateBy = value;
        }
    }
    public Role Roles
    {
        get
        {
            return _roles;
        }

        set
        {
            _roles = value;
        }
    }
    #endregion

    #region Static Member
    public static User_cls Convert(Esam.Models.ViewModel.CustomRegModel source)
    {
        User_cls user = new User_cls();
        user.Email = source.email;
        user.Username = source.email;
        user.Lname = source.lname;
        user.Fname = source.fname;
        user.Password = source.password;
        return user;
    }

    public static Esam.Models.ViewModel.CustomRegModel Convert(DataTable dt)
    {
        Esam.Models.ViewModel.CustomRegModel model = new Esam.Models.ViewModel.CustomRegModel();

        if (dt != null && dt.Rows.Count != 0)
        {
            model.fname = dt.Rows[0]["Fname"].ToString();
            model.lname = dt.Rows[0]["Lname"].ToString();
            model.email = dt.Rows[0]["Email"].ToString();
            model.password = dt.Rows[0]["UsrPassword"].ToString();
            model.VerifyAccount = new VerifyAccountType(System.Convert.ToInt32(dt.Rows[0]["VerifyAccount"]));
            model.active = System.Convert.ToBoolean(dt.Rows[0]["Active"]);
            model.userid = System.Convert.ToInt32(dt.Rows[0]["UsrID"]);
        }

        return model;
    }

    public static string ActiveStatus(bool active)
    {
        if (active)
            return "فعال";
        else
            return "غیر فعال";
    }
    public static User_cls ConvertToUser(DataTable dt)
    {
        User_cls user = new User_cls();
        foreach (DataRow item in dt.Rows)
        {
            if (item["UsrID"] != DBNull.Value)
                user.UserID = Int32.Parse(item["UsrID"].ToString());

            if (item["VerifyAccount"] != DBNull.Value)
                user.VerifyAccount = new VerifyAccountType(Int32.Parse(item["VerifyAccount"].ToString()));

            if (item["Fname"] != DBNull.Value)
                user.Fname = item["Fname"].ToString();

            if (item["Lname"] != DBNull.Value)
                user.Lname = item["Lname"].ToString();

            user.FullName = user.Fname + " " + user.Lname;

            if (item["Email"] != DBNull.Value)
                user.Email = item["Email"].ToString();

            if (item["Active"] != DBNull.Value)
            {
                if (item["Active"].ToString() == "True")
                    user.Active = true;
                else if (item["Active"].ToString() == "False")
                    user.Active = false;
            }

        }
        return user;

    }
    #endregion
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

    public static int VerifybyEmail
    { get { return 3; } }

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

    public static int ConfirmEmail
    { get { return 3; } }

}


