namespace MvcMembership.Settings
{
    /// <summary>
    /// Registration Settings Interface
    /// </summary>
    public interface IRegistrationSettings
    {
        /// <summary>
        /// Gets a value indicating whether [requires unique email address].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [requires unique email address]; otherwise, <c>false</c>.
        /// </value>
        bool RequiresUniqueEmailAddress { get; }
    }
}