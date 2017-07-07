namespace MvcMembership.Settings
{
    /// <summary>
    /// Logging Settings
    /// </summary>
    /// <seealso cref="MvcMembership.Settings.ILoginSettings" />
    public class LoginSettings : ILoginSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSettings"/> class.
        /// </summary>
        /// <param name="maximumInvalidPasswordAttempts">The maximum invalid password attempts.</param>
        /// <param name="passwordAttemptWindowInMinutes">The password attempt window in minutes.</param>
        public LoginSettings(int maximumInvalidPasswordAttempts, int passwordAttemptWindowInMinutes)
        {
            MaximumInvalidPasswordAttempts = maximumInvalidPasswordAttempts;
            PasswordAttemptWindowInMinutes = passwordAttemptWindowInMinutes;
        }

        #region ILoginSettings Members

        /// <summary>
        /// Gets the maximum invalid password attempts.
        /// </summary>
        /// <value>
        /// The maximum invalid password attempts.
        /// </value>
        public int MaximumInvalidPasswordAttempts { get; private set; }
        /// <summary>
        /// Gets the password attempt window in minutes.
        /// </summary>
        /// <value>
        /// The password attempt window in minutes.
        /// </value>
        public int PasswordAttemptWindowInMinutes { get; private set; }

        #endregion
    }
}