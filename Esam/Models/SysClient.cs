using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Component;
using System.Data;
using ERP.Models;

public class SysClient : User_cls
{
    private string _clientinfo;
    private Permission _permission;
    public Permission Permission
    {
        get { return this._permission; }
    }
    public string ClientInfo
    {
        get { return _clientinfo; }
        set { _clientinfo = value; }
    }


    public string Browser
    {
        get
        {
            System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
            return browser.Browser;
        }

    }

    public SysClient()
    {
        ClientInfo = "";
        Fname = "";
        Lname = "";
        FullName = "";
        _permission = new Permission();
    }

}
public class Role : Dictionary<RoleType, bool>
{
    public int ID
    {
        get;
        set;
    }
    public string RoleInString
    {
        get
        {
            string result = "";
            if (this[RoleType.Admin])
                result += Position.Convert(Position.Admin);

            if (this[RoleType.Customer])
                result += ", " + Position.Convert(Position.Customer);
            return result;
        }
    }
    public Role(bool x)
    {
        SetValue(x);
    }
   
    public Role()
    { SetValue(false); }
    private void SetValue(bool x)
    {
        base.Add(RoleType.Admin, x);
        base.Add(RoleType.Customer, x);
    }
 
    private void SetValue(RoleType key, bool Value)
    {
        base[key] = Value;
    }
   

    #region static member
    public static Role Convert(DataTable dt)
    {
        Role result = new Role();
        if (dt.Rows.Count == 0)
            return result;
        if (!DBNull.Value.Equals(dt.Rows[0]["Admin"]) && (bool)dt.Rows[0]["Admin"] == true)
            result.SetValue(RoleType.Admin, true);
        if (!DBNull.Value.Equals(dt.Rows[0]["Customer"]) && (bool)dt.Rows[0]["Customer"] == true)
            result.SetValue(RoleType.Customer, true);
        return result;
    }
    public bool JustHaveThisRole(RoleType role)
    {
        string[] roles = RoleInString.Split(',');
        if (roles.Length > 3)
            return false;
        else
            if (roles[0].Trim() == role.ToString() || roles[1].Trim() == role.ToString() || roles[2].Trim() == role.ToString())
            return true;
        return false;
    }
    public static Role Convert(string roles)
    {
        Role role = new Role();
        string[] userRoles = roles.Split(',');
        for (int i = 0; i < userRoles.Length; i++)
        {
            if (Position.Admin.ToString() == userRoles[i])
                role[RoleType.Admin] = true;

            else if (Position.Customer.ToString() == userRoles[i])
                role[RoleType.Customer] = true;


        }
        return role;
    }
    #endregion


}
public class Position
{

    public Position()
    { }
    public Position(int id)
    {
        this.ID = id;
    }

    int _id;

    public int ID
    {
        get { return _id; }
        set
        {
            _title = Position.Convert(value);
            _id = value;
        }
    }
    string _title;

    public string Title
    {
        get { return _title; }
        //set { _title = value; }
    }


    public static string Convert(int id)
    {
        switch (id)
        {
            case 1:
                return "Admin";
            case 2:
                return "Customer";
            default: throw new Exception("invalid Position id");
        }
    }
    public static int Admin
    {
        get { return 1; }
    }
    public static int Customer
    {
        get { return 2; }
    }

}
public enum RoleType
{
    Admin, Customer
}


