using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace People.WebUI.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizationFilter:ActionFilterAttribute
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);


            string cookieName = FormsAuthentication.FormsCookieName;//获取登录授权的cookie名称
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];

            FormsAuthenticationTicket authTicket = null;

            try
            {
                authTicket = FormsAuthentication.Decrypt(cookie.Value);

            }
            catch (Exception ex)
            {
                return;
            }
            if (authTicket != null && filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = authTicket.Name;
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.HttpContext.Response.RedirectToRoute(new RouteValueDictionary() { { "Controller", "Home" }, { "Action", "Index" }, { "", "" } });
            }
        }
    }
}