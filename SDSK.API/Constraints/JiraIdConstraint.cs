using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http.Routing;
using SDSK.API.Regexes;

namespace SDSK.API.Constraints
{
    public class JiraIdConstraint : IHttpRouteConstraint
    {
        private readonly Regex _jiraIdRegex = new JiraIdRegex().Get();

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                var stringValue = value as string;
                if (stringValue == null)                
                    return false;                

                return _jiraIdRegex.IsMatch(stringValue);
            }
            return false;
        }
    }
}
