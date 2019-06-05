using Component;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Esam.Logic;

public class SysProperty
{
    private static TimeSpan _expirationForSubmitOnline;
    private static TimeSpan _expirationForSelectReferee;
    private static string _interimCodePaper;
    private static string _permanentCodePaper;
    private static string _systemEmailHostName;
    private static string _systemName;
    private static string _systemNamePersian;
    private static string _systemNameEnglish;
    private static string _systemEmailDisplayName;
    private static int _theMinimumReferees;
    public string _ActionName;
    public string _ControllerName;

    public SysProperty()
    {
    }

    public static int TheMinimumReferees
    {
        get
        {
            if (_theMinimumReferees == 0)
                _theMinimumReferees = System.Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TheMinimumReferees"]);
            return _theMinimumReferees;
        }
    }

    public static string GetActionName
    {
        get
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();
        }
    }
    public static string GetControllerName
    {
        get
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        }
    }

    public static string SystemEmailHostName
    {
        get
        {
            if (_systemEmailHostName == string.Empty || _systemEmailHostName == null)
                _systemEmailHostName = System.Configuration.ConfigurationManager.AppSettings["SystemEmailHostName"].ToString();
            return _systemEmailHostName;
        }
    }

    public static string InterimCodePaper
    {
        get
        {
            if (_interimCodePaper == string.Empty || _interimCodePaper == null)
                _interimCodePaper = System.Configuration.ConfigurationManager.AppSettings["InterimCodePaper"].ToString();
            return _interimCodePaper;
        }
    }
  
    public static string PermanentCodePaper
    {
        get
        {
            if (_permanentCodePaper == string.Empty || _permanentCodePaper == null)
                _permanentCodePaper = System.Configuration.ConfigurationManager.AppSettings["PermanentCodePaper"].ToString();
            return _permanentCodePaper;
        }

    }
   
    public static TimeSpan ExpirationForSubmitOnline
    {
        get
        {
            if (_expirationForSubmitOnline == null || _expirationForSubmitOnline == TimeSpan.Zero)
                _expirationForSubmitOnline = new TimeSpan(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ExpirationForSubmitOnline"]), 0, 0, 0, 0);
            return _expirationForSubmitOnline;
        }
    }
    public static TimeSpan ExpirationForSelectReferee
    {
        get
        {
            if (_expirationForSelectReferee == null || _expirationForSelectReferee == TimeSpan.Zero)
                _expirationForSelectReferee = new TimeSpan(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ExpirationForSelectReferee"]), 0, 0, 0, 0);
            return _expirationForSelectReferee;
        }
    }
   
    public static string SystemName
    {
        get
        {
            if (_systemName == null || _systemName == string.Empty)
                if (SysProperty.SiteLanguage == Languages.English)
                    _systemName = System.Configuration.ConfigurationManager.AppSettings["SiteNameInEnglish"].ToString();
                else if (SysProperty.SiteLanguage == Languages.Persion)
                    _systemName = System.Configuration.ConfigurationManager.AppSettings["SiteNameInPersian"].ToString();
            return _systemName;
        }
    }

    public static string SystemNameEnglish
    {
        get
        {
            if (_systemNameEnglish == string.Empty || _systemNameEnglish == null)
                _systemNameEnglish = System.Configuration.ConfigurationManager.AppSettings["SiteNameInEnglish"].ToString();
            return _systemNameEnglish;
        }
        //set
        //{
        //    Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
        //    //Get the required section of the web.config file by using configuration object.
        //    AppSettingsSection sec = (AppSettingsSection)config.GetSection("appSettings");
        //    sec.Settings["SiteNameInEnglish"].Value = value;
        //    _permanentCodePaper = value.Trim();
        //    //config.Save();
        //}
    }

    public static string SystemNamePersian
    {
        get
        {
            if (_systemNamePersian == string.Empty || _systemNamePersian == null)
                _systemNamePersian = System.Configuration.ConfigurationManager.AppSettings["SiteNameInPersian"].ToString();
            return _systemNamePersian;
        }
        //set
        //{
        //    Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
        //    //Get the required section of the web.config file by using configuration object.
        //    AppSettingsSection sec = (AppSettingsSection)config.GetSection("appSettings");
        //    sec.Settings["SiteNameInPersian"].Value = value;
        //    _permanentCodePaper = value.Trim();
        //    //config.Save();
        //}
    }
    
    public static string OrginazeNamePersian
    {
        get
        {
              return   System.Configuration.ConfigurationManager.AppSettings["OrganizeName"].ToString();
        }
    }
    public static string SystemEmailDisplayName
    {
        get
        {
            if (_systemEmailDisplayName == string.Empty || _systemEmailDisplayName == null)
                _systemEmailDisplayName = System.Configuration.ConfigurationManager.AppSettings["SystemEmailDisplayName"].ToString();
            return _systemEmailDisplayName;
        }
        //set
        //{
        //    Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
        //    //Get the required section of the web.config file by using configuration object.
        //    AppSettingsSection sec = (AppSettingsSection)config.GetSection("appSettings");

        //    sec.Settings["SystemEmailDisplayName"].Value = value.Trim();
        //    _systemEmailDisplayName = value.Trim();
        //    //config.Save();
        //}
    }

    public static SysClient Client
    {
        get { return (SysClient)HttpContext.Current.Session[SessionType.Client]; }
        set { HttpContext.Current.Session[SessionType.Client] = value; }
    }

    public static int EsamSubSystemID
    {
        get { return 4; }
    }


    public static Languages SiteLanguage
    {
        get { return (Languages)HttpContext.Current.Session["SL"]; }
    }

    public static void ChangeSiteLanguage(Languages language)
    {
        HttpContext.Current.Session["SL"] = language;
    }

    public static void SaveConfig(WebConfig saveConfig)
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
        AppSettingsSection sec = (AppSettingsSection)config.GetSection("appSettings");

        sec.Settings["SystemEmailDisplayName"].Value = saveConfig.systemEmailDisplayName;
        sec.Settings["SystemEmailHostName"].Value = saveConfig.systemEmailHostName;

        sec.Settings["SiteNameInPersian"].Value = saveConfig.systemNamePersian;
        sec.Settings["SiteNameInEnglish"].Value = saveConfig.systemNameEnglish;

        sec.Settings["InterimCodePaper"].Value = saveConfig.interimCodePaper;
        sec.Settings["PermanentCodePaper"].Value = saveConfig.permanentCodePaper;

        sec.Settings["ExpirationForSelectReferee"].Value = saveConfig.expirationForSelectReferee.ToString();
        sec.Settings["ExpirationForSubmitOnline"].Value = saveConfig.expirationForSubmitOnline.ToString(); ;

        config.Save();

        _systemEmailDisplayName = null;
        _systemEmailHostName = null;
        _systemNameEnglish = null;
        _systemNamePersian = null;
        _interimCodePaper = null;
        _permanentCodePaper = null;
        _expirationForSelectReferee = TimeSpan.Zero;
        _expirationForSubmitOnline = TimeSpan.Zero;

    }
}

public enum Languages
{
    Persion,
    English
}

public class WebConfig
{
    public TimeSpan expirationForSubmitOnline;
    public TimeSpan expirationForSelectReferee;
    public string interimCodePaper;
    public string permanentCodePaper;
    public string systemEmailHostName;
    public string systemNamePersian;
    public string systemNameEnglish;
    public string systemEmailDisplayName;
    public int theMinimumReferees;
    public static WebConfig showConfig()
    {
        WebConfig webConfig = new WebConfig();

        webConfig.expirationForSelectReferee = SysProperty.ExpirationForSelectReferee;
        webConfig.expirationForSubmitOnline = SysProperty.ExpirationForSubmitOnline;
        webConfig.interimCodePaper = SysProperty.InterimCodePaper;
        webConfig.permanentCodePaper = SysProperty.PermanentCodePaper;
        webConfig.systemEmailHostName = SysProperty.SystemEmailHostName;
        webConfig.systemNamePersian = SysProperty.SystemNamePersian;
        webConfig.systemNameEnglish = SysProperty.SystemNameEnglish;
        webConfig.systemEmailDisplayName = SysProperty.SystemEmailDisplayName;
        webConfig.theMinimumReferees = SysProperty.TheMinimumReferees;
        return webConfig;
    }
}

