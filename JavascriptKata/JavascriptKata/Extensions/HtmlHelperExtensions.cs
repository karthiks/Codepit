using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace JavascriptKata.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string ActionLink<T>(this HtmlHelper helper, string text, Expression<Action<T>> expression) where T: Controller
        {
            var methodInfo = ((MethodCallExpression) expression.Body).Method;

            if (methodInfo.ReturnType != typeof(ActionResult))
                throw new ArgumentException("Return Type of Method in Expression Should be ActionResult", "expression");
            
            var methodName = methodInfo.Name;
            var controllerName = typeof (T).Name.Replace("Controller", string.Empty);

            return helper.ActionLink(text, methodName, controllerName);
        }
    }
}
