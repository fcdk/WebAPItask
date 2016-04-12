using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using log4net;

namespace SDSK.API
{
    public class ExceptionLogger : IExceptionLogger
    {
        private static readonly ILog Log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Log4Net.Error(
                    $"Unhandled exception thrown in {context.Request.Method} for request {context.Request.RequestUri}: {context.Exception}");
            });
        }
    }
}
