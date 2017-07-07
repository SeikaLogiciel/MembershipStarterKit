using System.Web.Security;

namespace MvcMembership.Settings
{
    /// <summary>
    /// Wrapper for AspNetMembershipProviderSettings
    /// </summary>
    /// <seealso cref="MvcMembership.Settings.IMembershipSettings" />
    public class AspNetMembershipProviderSettingsWrapper : IMembershipSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetMembershipProviderSettingsWrapper"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        public AspNetMembershipProviderSettingsWrapper(MembershipProvider provider)
            : this(
                new RegistrationSettings(provider.RequiresUniqueEmail),
                new PasswordSettings(
                    new PasswordResetRetrievalSettings(provider.EnablePasswordReset,
                                                       provider.EnablePasswordRetrieval,
                                                       provider.RequiresQuestionAndAnswer),
                    provider.MinRequiredPasswordLength,
                    provider.MinRequiredNonAlphanumericCharacters,
                    provider.PasswordStrengthRegularExpression,
                    provider.PasswordFormat),
                new LoginSettings(provider.MaxInvalidPasswordAttempts,
                                  provider.PasswordAttemptWindow)
                )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetMembershipProviderSettingsWrapper"/> class.
        /// </summary>
        /// <param name="registration">The registration.</param>
        /// <param name="password">The password.</param>
        /// <param name="login">The login.</param>
        public AspNetMembershipProviderSettingsWrapper(IRegistrationSettings registration, IPasswordSettings password, ILoginSettings login)
        {
            Registration = registration;
            Password = password;
            Login = login;
        }

        #region IMembershipSettings Members

        /// <summary>
        /// Gets the registration.
        /// </summary>
        /// <value>
        /// The registration.
        /// </value>
        public IRegistrationSettings Registration { get; private set; }
        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public IPasswordSettings Password { get; private set; }
        /// <summary>
        /// Gets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        public ILoginSettings Login { get; private set; }

        #endregion
    }
}