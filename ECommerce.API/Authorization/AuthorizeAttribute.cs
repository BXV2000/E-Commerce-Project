using ECommerce.SharedDataModels;
using ECommerce.SharedDataModels.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.API.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<UserRole> _roles;

        public AuthorizeAttribute(params UserRole[] roles)
        {
            _roles = roles ?? new UserRole[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Skip authoriztion if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous) return;

            // Authorization
            var user = (UserDTO)context.HttpContext.Items["User"];

            if (user == null || _roles.Any() && !_roles.Contains(user.Role))
                // Not logged in
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        controller = "Home",
                        action = "Error",
                    }));
            //context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
