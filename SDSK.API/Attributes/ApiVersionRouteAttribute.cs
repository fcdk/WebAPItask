using System.Collections.Generic;
using System.Web.Http.Routing;
using SDSK.API.Constraints;

namespace SDSK.API.Attributes
{
    public class ApiVersionRouteAttribute : RouteFactoryAttribute
    {
        public ApiVersionRouteAttribute(string template) : base(template) { }

        public override IDictionary<string, object> Constraints
        {
            get
            {
                var constraints = new HttpRouteValueDictionary();
                constraints.Add("VersionConstraint", new VersionConstraint());
                return constraints;
            }
        }
    }
}