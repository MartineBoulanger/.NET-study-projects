namespace Tuincentrum.Constraints
{
    public class QueryStringConstraint : IRouteConstraint
    {
        private string[] verwachteParameters;
        public QueryStringConstraint(string[] verwachteParameters)
        {
            this.verwachteParameters = verwachteParameters;
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            foreach (string verwachteParameter in verwachteParameters)
            {
                if (!httpContext.Request.Query.Keys.Contains(verwachteParameter, StringComparer.OrdinalIgnoreCase)) return false;
            }
            return true;
        }
    }
}
