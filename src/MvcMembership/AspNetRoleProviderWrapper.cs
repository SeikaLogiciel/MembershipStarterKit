using System;
using System.Collections.Generic;
using System.Web.Security;

namespace MvcMembership
{
    /// <summary>
    /// Wrapper for AspNetRoleProvider
    /// </summary>
    /// <seealso cref="MvcMembership.IRolesService" />
    public class AspNetRoleProviderWrapper : IRolesService
    {
        private readonly RoleProvider _roleProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetRoleProviderWrapper"/> class.
        /// </summary>
        public AspNetRoleProviderWrapper()
        {
            if (Roles.Enabled)
                _roleProvider = Roles.Provider;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetRoleProviderWrapper"/> class.
        /// </summary>
        /// <param name="roleProvider">The role provider.</param>
        public AspNetRoleProviderWrapper(RoleProvider roleProvider)
        {
            _roleProvider = roleProvider;
        }

        #region IRolesService Members

        /// <summary>
        /// Gets a value indicating whether this <see cref="IRolesService" /> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled
        {
            get { return _roleProvider != null; }
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> FindAll()
        {
            return _roleProvider.GetAllRoles();
        }

        /// <summary>
        /// Finds the roles by user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public IEnumerable<string> FindByUser(MembershipUser user)
        {
            return _roleProvider.GetRolesForUser(user.UserName);
        }

        /// <summary>
        /// Finds the roles by username.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public IEnumerable<string> FindByUserName(string userName)
        {
            return _roleProvider.GetRolesForUser(userName);
        }

        /// <summary>
        /// Finds the user names by role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        public IEnumerable<string> FindUserNamesByRole(string roleName)
        {
            return _roleProvider.GetUsersInRole(roleName);
        }

        /// <summary>
        /// Adds to role.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        public void AddToRole(MembershipUser user, string roleName)
        {
            _roleProvider.AddUsersToRoles(new[] {user.UserName}, new[] {roleName});
        }

        /// <summary>
        /// Removes from role.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        public void RemoveFromRole(MembershipUser user, string roleName)
        {
            _roleProvider.RemoveUsersFromRoles(new[] {user.UserName}, new[] {roleName});
        }

        /// <summary>
        /// Removes from all roles.
        /// </summary>
        /// <param name="user">The user.</param>
        public void RemoveFromAllRoles(MembershipUser user)
        {
            var roles = FindByUser(user);
            foreach(var role in roles)
                RemoveFromRole(user, role);
        }

        /// <summary>
        /// Determines whether [is in role] [the specified user].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>
        ///   <c>true</c> if [is in role] [the specified user]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInRole(MembershipUser user, string roleName)
        {
            return _roleProvider.IsUserInRole(user.UserName, roleName);
        }

        /// <summary>
        /// Creates the specified role name.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        public void Create(string roleName)
        {
            _roleProvider.CreateRole(roleName);
        }

        /// <summary>
        /// Deletes the specified role name.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        public void Delete(string roleName)
        {
            _roleProvider.DeleteRole(roleName, false);
        }

        #endregion
    }
}