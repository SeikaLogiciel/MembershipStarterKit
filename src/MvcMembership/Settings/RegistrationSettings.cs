namespace MvcMembership.Settings
{
    /// <summary>
    /// Registration Settings
    /// </summary>
    /// <seealso cref="MvcMembership.Settings.IRegistrationSettings" />
    public class RegistrationSettings : IRegistrationSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationSettings"/> class.
        /// </summary>
        /// <param name="requiresUniqueEmailAddress">if set to <c>true</c> [requires unique email address].</param>
        public RegistrationSettings(bool requiresUniqueEmailAddress)
        {
            RequiresUniqueEmailAddress = requiresUniqueEmailAddress;
        }

        #region IRegistrationSettings Members

        /// <summary>
        /// Gets a value indicating whether [requires unique email address].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [requires unique email address]; otherwise, <c>false</c>.
        /// </value>
        public bool RequiresUniqueEmailAddress { get; private set; }

        #endregion
    }
}