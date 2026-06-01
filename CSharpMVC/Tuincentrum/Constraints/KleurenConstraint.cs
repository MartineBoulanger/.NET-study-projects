namespace Tuincentrum.Constraints
{
    public class KleurenConstraint : IRouteConstraint
    {
        private static readonly string[] GekendeKleuren = new[] { "oranje", "rood", "geel", "bruin", "wit", "blauw", "groen",
            "ongekend", "paars", "gemengd", "lila", "violet", "roze" };

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return GekendeKleuren.Contains(values[routeKey]?.ToString()?.ToLowerInvariant());
        }
    }
}
