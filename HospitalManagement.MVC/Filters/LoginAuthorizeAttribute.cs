using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HospitalManagement.MVC.Filters
{
    public class LoginAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isLoggedIn = context.HttpContext.Session.GetString("IsloggedIn");

            if(isLoggedIn != "true")
            {
                context.Result = new RedirectToActionResult("LoginPro", "Login", null);

                return;
            }

            base.OnActionExecuting(context);
        }
        
    }
}
