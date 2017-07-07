namespace MvcMembership.Settings
{
    /// <summary>
    /// PasswordResetRetrievalSettings Interface
    /// </summary>
    public interface IPasswordResetRetrievalSettings
    {
        /// <summary>
        /// Gets a value indicating whether this instance can reset.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can reset; otherwise, <c>false</c>.
        /// </value>
        bool CanReset { get; }
        /// <summary>
        /// Gets a value indicating whether this instance can retrieve.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can retrieve; otherwise, <c>false</c>.
        /// </value>
        bool CanRetrieve { get; }
        /// <summary>
        /// Gets a value indicating whether [requires question and answer].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [requires question and answer]; otherwise, <c>false</c>.
        /// </value>
        bool RequiresQuestionAndAnswer { get; }
    }
}