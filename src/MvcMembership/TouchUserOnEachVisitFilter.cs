using System.Web.Mvc;

namespace MvcMembership
{
    /// <summary>
    /// Touch User On Each Visit Filter
    /// </summary>
    /// <seealso cref="System.Web.Mvc.ActionFilterAttribute" />
    public class TouchUserOnEachVisitFilter : ActionFilterAttribute
    {
        private readonly IUserServiceFactory _userServiceFactory;
        private IUserService _userService;

        private IUserService UserService
        {
            get { return _userService ?? (_userService = _userServiceFactory.Make()); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TouchUserOnEachVisitFilter"/> class.
        /// </summary>
        public TouchUserOnEachVisitFilter() : this(new AspNetMembershipProviderUserServiceFactory())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TouchUserOnEachVisitFilter"/> class.
        /// </summary>
        /// <param name="userServiceFactory">The user service factory.</param>
        public TouchUserOnEachVisitFilter(IUserServiceFactory userServiceFactory)
        {
            _userServiceFactory = userServiceFactory;
        }

        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.RequestContext.HttpContext.User;
            if (user.Identity.IsAuthenticated)
                UserService.Touch(user.Identity.Name);
        }
    }
}