namespace MvcMembership.Settings
{
    /// <summary>
    /// Logging Settings Interface
    /// </summary>
    public interface ILoginSettings
    {
        /// <summary>
        /// Gets the maximum invalid password attempts.
        /// </summary>
        /// <value>
        /// The maximum invalid password attempts.
        /// </value>
        int MaximumInvalidPasswordAttempts { get; }
        /// <summary>
        /// Gets the password attempt window in minutes.
        /// </summary>
        /// <value>
        /// The password attempt window in minutes.
        /// </value>
        int PasswordAttemptWindowInMinutes { get; }
    }
}