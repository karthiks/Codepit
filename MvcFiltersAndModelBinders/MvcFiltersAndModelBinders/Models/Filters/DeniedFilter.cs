using System.Web.Mvc;

namespace MvcFiltersAndModelBinders.Models.Filters
{
    // Inherit from FilterAttribute, NOT Attribute
    public class DeniedFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // HttpUnauthorizedResult Returns a HTTP 401 (Unauthorized)
            filterContext.Result = 
                new HttpUnauthorizedResult();
        }
    }
}
