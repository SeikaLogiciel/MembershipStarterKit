using System.Web.Security;

namespace MvcMembership
{
    /// <summary>
    /// Password Service Interface
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Unlocks the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        void Unlock(MembershipUser user);
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        string ResetPassword(MembershipUser user);
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="passwordAnswer">The password answer.</param>
        /// <returns></returns>
        string ResetPassword(MembershipUser user, string passwordAnswer);
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="newPassword">The new password.</param>
        void ChangePassword(MembershipUser user, string newPassword);
        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        void ChangePassword(MembershipUser user, string oldPassword, string newPassword);
    }
}