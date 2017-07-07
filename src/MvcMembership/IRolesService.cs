using System.Collections.Generic;
using System.Web.Security;

namespace MvcMembership
{
    /// <summary>
    /// Roles Service Interface
    /// </summary>
    public interface IRolesService
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="IRolesService"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        bool Enabled { get; }
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> FindAll();
        /// <summary>
        /// Finds the roles by user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        IEnumerable<string> FindByUser(MembershipUser user);
        /// <summary>
        /// Finds the roles by username.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        IEnumerable<string> FindByUserName(string userName);
        /// <summary>
        /// Finds the user names by role.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns></returns>
        IEnumerable<string> FindUserNamesByRole(string roleName);
        /// <summary>
        /// Adds to role.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        void AddToRole(MembershipUser user, string roleName);
        /// <summary>
        /// Removes from role.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        void RemoveFromRole(MembershipUser user, string roleName);
        /// <summary>
        /// Removes from all roles.
        /// </summary>
        /// <param name="user">The user.</param>
        void RemoveFromAllRoles(MembershipUser user);
        /// <summary>
        /// Determines whether [is in role] [the specified user].
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <returns>
        ///   <c>true</c> if [is in role] [the specified user]; otherwise, <c>false</c>.
        /// </returns>
        bool IsInRole(MembershipUser user, string roleName);
        /// <summary>
        /// Creates the specified role name.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        void Create(string roleName);
        /// <summary>
        /// Deletes the specified role name.
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        void Delete(string roleName);
    }
}