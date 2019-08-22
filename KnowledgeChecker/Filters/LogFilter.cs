using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace KnowledgeChecker.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = (filterContext.Controller as Controller)?.User as ClaimsPrincipal;
            var id = user.Claims.FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            if (id != null)
            {
                logger.SetProperty("controller", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName);
                logger.SetProperty("action", filterContext.ActionDescriptor.ActionName);
                logger.Info(Environment.NewLine + DateTime.Now);
                logger.SetProperty("UserId", id);
            }
        }
    }
}