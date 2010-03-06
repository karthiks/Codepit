using System.Web.Mvc;

namespace MvcFiltersAndModelBinders.Models.Filters
{
    // Inherit from FilterAttribute, NOT Attribute
    public class QueryStringAuthFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // Check the QueryString for "Secret" Code
            var req = filterContext.RequestContext.HttpContext.Request;
            var qs = req.QueryString["pass"] ?? string.Empty;


            if (qs.ToLower() != "opensesame")
            {
                // HttpUnauthorizedResult Returns a HTTP 401 (Unauthorized)
                filterContext.Result =
                    new HttpUnauthorizedResult();
            }
        }
    }
}
