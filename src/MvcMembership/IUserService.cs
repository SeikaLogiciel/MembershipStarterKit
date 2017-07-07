using System.Web.Security;
using PagedList;

namespace MvcMembership
{
    /// <summary>
    /// User Service Interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets the total users.
        /// </summary>
        /// <value>
        /// The total users.
        /// </value>
        int TotalUsers { get; }
        /// <summary>
        /// Gets the users online.
        /// </summary>
        /// <value>
        /// The users online.
        /// </value>
        int UsersOnline { get; }
        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        IPagedList<MembershipUser> FindAll(int pageNumber, int pageSize);
        /// <summary>
        /// Finds the by email.
        /// </summary>
        /// <param name="emailAddressToMatch">The email address to match.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        IPagedList<MembershipUser> FindByEmail(string emailAddressToMatch, int pageNumber, int pageSize);
        /// <summary>
        /// Finds the name of the by user.
        /// </summary>
        /// <param name="userNameToMatch">The user name to match.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        IPagedList<MembershipUser> FindByUserName(string userNameToMatch, int pageNumber, int pageSize);
        /// <summary>
        /// Gets the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        MembershipUser Get(string userName);
        /// <summary>
        /// Gets the specified provider user key.
        /// </summary>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <returns></returns>
        MembershipUser Get(object providerUserKey);
        /// <summary>
        /// Creates the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="email">The email.</param>
        /// <param name="passwordQuestion">The password question.</param>
        /// <param name="passwordAnswer">The password answer.</param>
        /// <param name="isApproved">if set to <c>true</c> [is approved].</param>
        /// <returns></returns>
        MembershipUser Create(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved);
        /// <summary>
        /// Creates the specified username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="email">The email.</param>
        /// <param name="passwordQuestion">The password question.</param>
        /// <param name="passwordAnswer">The password answer.</param>
        /// <param name="isApproved">if set to <c>true</c> [is approved].</param>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <returns></returns>
        MembershipUser Create(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey);
        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        void Update(MembershipUser user);
        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        void Delete(MembershipUser user);
        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="deleteAllRelatedData">if set to <c>true</c> [delete all related data].</param>
        void Delete(MembershipUser user, bool deleteAllRelatedData);
        /// <summary>
        /// Touches the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        MembershipUser Touch(MembershipUser user);
        /// <summary>
        /// Touches the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        MembershipUser Touch(string userName);
        /// <summary>
        /// Touches the specified provider user key.
        /// </summary>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <returns></returns>
        MembershipUser Touch(object providerUserKey);
    }
}