using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

static public class ServerDirectory
{
    static string host;
    public static string Host
    {
        set { host = value; }
        get
        {
            return host;
        }
    }
    static string physicalPath;

    public static string PhysicalPath
    {
        get { return ServerDirectory.physicalPath; }
        set { ServerDirectory.physicalPath = value; }
    }
}
