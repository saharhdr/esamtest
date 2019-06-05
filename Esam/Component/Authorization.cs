using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Component
{
    public class Authorization : AuthorizeAttribute
    {
        public RoleType RequirePermissionsID { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string RequirePermission = RequirePermissionsID.ToString();

            if (SysProperty.Client.UserID == 0 || SysProperty.Client.Roles == null || !SysProperty.Client.Roles[RequirePermissionsID])
                    filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new { controller = "userauthorize", action = "adminlogin", area = "" }));
        }
    }
}