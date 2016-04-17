using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using log4net;

namespace SDSK.API.Filters
{
    public class LogPerformanceActionFilter : ActionFilterAttribute, IFilter
    {
        private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DateTime _onActionExecutingTime;
        private DateTime _onResultExecuted;

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _onActionExecutingTime = DateTime.UtcNow;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionContext)
        {
            _onResultExecuted = DateTime.UtcNow;
            var controllerName = actionContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName = actionContext.ActionContext.ActionDescriptor.ActionName;
            Log4Net.Info(
                   $"Action {actionName} in {controllerName} controller was executed for {_onResultExecuted - _onActionExecutingTime}");
        }
    }
}