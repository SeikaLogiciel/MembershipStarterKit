namespace MvcMembership.Settings
{
    /// <summary>
    /// Password Reset Retrieval Settings
    /// </summary>
    /// <seealso cref="MvcMembership.Settings.IPasswordResetRetrievalSettings" />
    public class PasswordResetRetrievalSettings : IPasswordResetRetrievalSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordResetRetrievalSettings"/> class.
        /// </summary>
        /// <param name="canReset">if set to <c>true</c> [can reset].</param>
        /// <param name="canRetrieve">if set to <c>true</c> [can retrieve].</param>
        /// <param name="requiresQuestionAndAnswer">if set to <c>true</c> [requires question and answer].</param>
        public PasswordResetRetrievalSettings(bool canReset, bool canRetrieve, bool requiresQuestionAndAnswer)
        {
            CanReset = canReset;
            CanRetrieve = canRetrieve;
            RequiresQuestionAndAnswer = requiresQuestionAndAnswer;
        }

        #region IPasswordResetRetrievalSettings Members

        /// <summary>
        /// Gets a value indicating whether this instance can reset.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can reset; otherwise, <c>false</c>.
        /// </value>
        public bool CanReset { get; private set; }
        /// <summary>
        /// Gets a value indicating whether this instance can retrieve.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can retrieve; otherwise, <c>false</c>.
        /// </value>
        public bool CanRetrieve { get; private set; }
        /// <summary>
        /// Gets a value indicating whether [requires question and answer].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [requires question and answer]; otherwise, <c>false</c>.
        /// </value>
        public bool RequiresQuestionAndAnswer { get; private set; }

        #endregion
    }
}