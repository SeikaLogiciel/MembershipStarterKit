using System;
using System.Collections.Generic;
using System.Web.Security;
using MvcMembership.Settings;
using PagedList;

namespace MvcMembership
{
    /// <summary>
    /// Wrapper for AspNetMembershipProvider
    /// </summary>
    /// <seealso cref="MvcMembership.IUserService" />
    /// <seealso cref="MvcMembership.IPasswordService" />
    public class AspNetMembershipProviderWrapper : IUserService, IPasswordService
    {
        private readonly MembershipProvider _membershipProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetMembershipProviderWrapper"/> class.
        /// </summary>
        public AspNetMembershipProviderWrapper()
        {
            _membershipProvider = Membership.Provider;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetMembershipProviderWrapper"/> class.
        /// </summary>
        /// <param name="membershipProvider">The membership provider.</param>
        public AspNetMembershipProviderWrapper(MembershipProvider membershipProvider)
        {
            _membershipProvider = membershipProvider;
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public AspNetMembershipProviderSettingsWrapper Settings
        {
            get{ return new AspNetMembershipProviderSettingsWrapper(_membershipProvider); }
        }

        #region IPasswordService Members

        /// <summary>
        /// Unlocks the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Unlock(MembershipUser user)
        {
            user.UnlockUser();
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public string ResetPassword(MembershipUser user)
        {
            return user.ResetPassword();
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="passwordAnswer">The password answer.</param>
        /// <returns></returns>
        public string ResetPassword(MembershipUser user, string passwordAnswer)
        {
            return user.ResetPassword(passwordAnswer);
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="newPassword">The new password.</param>
        /// <exception cref="MembershipPasswordException">Could not change password.</exception>
        public void ChangePassword(MembershipUser user, string newPassword)
        {
            var resetPassword = user.ResetPassword();
            if(!user.ChangePassword(resetPassword, newPassword))
                throw new MembershipPasswordException("Could not change password.");
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <exception cref="MembershipPasswordException">Could not change password.</exception>
        public void ChangePassword(MembershipUser user, string oldPassword, string newPassword)
        {
            if (!user.ChangePassword(oldPassword, newPassword))
                throw new MembershipPasswordException("Could not change password.");
        }

        #endregion

        #region IUserService Members

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public IPagedList<MembershipUser> FindAll(int pageNumber, int pageSize)
        {
            // get one page of users
            int totalUserCount;
            var usersCollection = _membershipProvider.GetAllUsers(pageNumber - 1, pageSize, out totalUserCount);

            // convert from MembershipUserColletion to PagedList<MembershipUser> and return
            var converter = new EnumerableToEnumerableTConverter<MembershipUserCollection, MembershipUser>();
            var usersList = converter.ConvertTo<IEnumerable<MembershipUser>>(usersCollection);
            var usersPagedList = new StaticPagedList<MembershipUser>(usersList, pageNumber, pageSize, totalUserCount);
            return usersPagedList;
        }

        /// <summary>
        /// Finds the by email.
        /// </summary>
        /// <param name="emailAddressToMatch">The email address to match.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public IPagedList<MembershipUser> FindByEmail(string emailAddressToMatch, int pageNumber, int pageSize)
        {
            // get one page of users
            int totalUserCount;
            var usersCollection = _membershipProvider.FindUsersByEmail(emailAddressToMatch, pageNumber - 1, pageSize, out totalUserCount);

            // convert from MembershipUserColletion to PagedList<MembershipUser> and return
            var converter = new EnumerableToEnumerableTConverter<MembershipUserCollection, MembershipUser>();
            var usersList = converter.ConvertTo<IEnumerable<MembershipUser>>(usersCollection);
            var usersPagedList = new StaticPagedList<MembershipUser>(usersList, pageNumber, pageSize, totalUserCount);
            return usersPagedList;
        }

        /// <summary>
        /// Finds the name of the by user.
        /// </summary>
        /// <param name="userNameToMatch">The user name to match.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        public IPagedList<MembershipUser> FindByUserName(string userNameToMatch, int pageNumber, int pageSize)
        {
            // get one page of users
            int totalUserCount;
            var usersCollection = _membershipProvider.FindUsersByName(userNameToMatch, pageNumber - 1, pageSize, out totalUserCount);

            // convert from MembershipUserColletion to PagedList<MembershipUser> and return
            var converter = new EnumerableToEnumerableTConverter<MembershipUserCollection, MembershipUser>();
            var usersList = converter.ConvertTo<IEnumerable<MembershipUser>>(usersCollection);
            var usersPagedList = new StaticPagedList<MembershipUser>(usersList, pageNumber, pageSize, totalUserCount);
            return usersPagedList;
        }

        /// <summary>
        /// Gets the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public MembershipUser Get(string userName)
        {
            return _membershipProvider.GetUser(userName, false);
        }

        /// <summary>
        /// Gets the specified provider user key.
        /// </summary>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <returns></returns>
        public MembershipUser Get(object providerUserKey)
        {
            return _membershipProvider.GetUser(providerUserKey, false);
        }

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
        public MembershipUser Create(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved)
        {
            return Create(username, password, email, passwordQuestion, passwordAnswer, isApproved, Guid.NewGuid());
        }

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
        /// <exception cref="MembershipCreateUserException"></exception>
        public MembershipUser Create(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey)
        {
            MembershipCreateStatus status;
            var user = _membershipProvider.CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
            if(status != MembershipCreateStatus.Success)
                throw new MembershipCreateUserException(status);
            return user;
        }

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Update(MembershipUser user)
        {
            _membershipProvider.UpdateUser(user);
        }

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void Delete(MembershipUser user)
        {
            _membershipProvider.DeleteUser(user.UserName, false);
        }

        /// <summary>
        /// Deletes the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="deleteAllRelatedData">if set to <c>true</c> [delete all related data].</param>
        public void Delete(MembershipUser user, bool deleteAllRelatedData)
        {
            _membershipProvider.DeleteUser(user.UserName, deleteAllRelatedData);
        }

        /// <summary>
        /// Touches the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public MembershipUser Touch(MembershipUser user)
        {
            return _membershipProvider.GetUser(user.UserName, true);
        }

        /// <summary>
        /// Touches the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public MembershipUser Touch(string userName)
        {
            return _membershipProvider.GetUser(userName, true);
        }

        /// <summary>
        /// Touches the specified provider user key.
        /// </summary>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <returns></returns>
        public MembershipUser Touch(object providerUserKey)
        {
            return _membershipProvider.GetUser(providerUserKey, true);
        }

        /// <summary>
        /// Gets the total users.
        /// </summary>
        /// <value>
        /// The total users.
        /// </value>
        public int TotalUsers
        {
            get
            {
                int totalUsers;
                _membershipProvider.GetAllUsers(1, 1, out totalUsers);
                return totalUsers;
            }
        }

        /// <summary>
        /// Gets the users online.
        /// </summary>
        /// <value>
        /// The users online.
        /// </value>
        public int UsersOnline
        {
            get
            {
                return _membershipProvider.GetNumberOfUsersOnline();
            }
        }

        #endregion
    }
}