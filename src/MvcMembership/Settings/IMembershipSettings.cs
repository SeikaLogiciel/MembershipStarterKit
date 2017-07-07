namespace MvcMembership.Settings
{
    /// <summary>
    /// Membership Settings Interface
    /// </summary>
    public interface IMembershipSettings
    {
        /// <summary>
        /// Gets the registration.
        /// </summary>
        /// <value>
        /// The registration.
        /// </value>
        IRegistrationSettings Registration { get; }
        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        IPasswordSettings Password { get; }
        /// <summary>
        /// Gets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        ILoginSettings Login { get; }
    }
}