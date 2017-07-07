using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMembership
{
    /// <summary>
    /// Attribute definition for AuthorizeUnlessOnlyUser
    /// </summary>
    /// <seealso cref="System.Web.Mvc.AuthorizeAttribute" />
    public class AuthorizeUnlessOnlyUserAttribute : AuthorizeAttribute
    {
        private static bool _hasAtLeastTwoUsers;
        private static bool _hasAtLeastOneRole;
        private readonly IRolesService _rolesService;
        private readonly IUserService _userService;
        private string[] _rolesSplit;
        private string[] _usersSplit;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeUnlessOnlyUserAttribute"/> class.
        /// </summary>
        public AuthorizeUnlessOnlyUserAttribute() : this(new AspNetMembershipProviderWrapper(), new AspNetRoleProviderWrapper())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeUnlessOnlyUserAttribute"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="rolesService">The roles service.</param>
        public AuthorizeUnlessOnlyUserAttribute(IUserService userService, IRolesService rolesService)
        {
            _userService = userService;
            _rolesService = rolesService;
        }

        /// <summary>
        /// When overridden, provides an entry point for custom authorization checks.
        /// </summary>
        /// <param name="httpContext">The HTTP context, which encapsulates all HTTP-specific information about an individual HTTP request.</param>
        /// <returns>
        /// true if the user is authorized; otherwise, false.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">httpContext</exception>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            //never authorize someone who isn't logged in
            var user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
                return false;

            //allow anyone access if there are less than two users, otherwise
            // - use normal logic (and cache this finding in a static variable)
            if (_hasAtLeastTwoUsers || _userService.TotalUsers > 1)
                _hasAtLeastTwoUsers = true;
            else
                return true;

            //MSFT wasn't kind enough to make these protected, so on the first request go ahead and recacl these
            if (_usersSplit == null)
                _usersSplit = SplitString(Users);
            if (_rolesSplit == null)
                _rolesSplit = SplitString(Roles);

            //same user check as MSFT - not sure that anyone actually uses this feature though...
            if (_usersSplit.Any() && !_usersSplit.Contains(user.Identity.Name, StringComparer.OrdinalIgnoreCase))
                return false;

            //added the check for whether the role service is enabled or not. if it isn't, don't validate on that
            if (_hasAtLeastOneRole || _rolesService.FindAll().Any())
                _hasAtLeastOneRole = true;
            if (!_rolesService.Enabled || !_rolesSplit.Any() || !_hasAtLeastOneRole)
                return true;

            //is this user in one of the necessary roles?
            return _rolesSplit.Any(user.IsInRole);
        }

        private static string[] SplitString(string original)
        {
            if (String.IsNullOrEmpty(original))
                return new string[0];

            var split = from piece in original.Split(',')
                        let trimmed = piece.Trim()
                        where !String.IsNullOrEmpty(trimmed)
                        select trimmed;
            return split.ToArray();
        }
    }
}