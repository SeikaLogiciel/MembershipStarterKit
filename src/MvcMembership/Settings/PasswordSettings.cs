using System.Web.Security;

namespace MvcMembership.Settings
{
    /// <summary>
    /// Password Settings
    /// </summary>
    /// <seealso cref="MvcMembership.Settings.IPasswordSettings" />
    public class PasswordSettings : IPasswordSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordSettings"/> class.
        /// </summary>
        /// <param name="resetOrRetrieval">The reset or retrieval.</param>
        /// <param name="minimumLength">The minimum length.</param>
        /// <param name="minimumNonAlphanumericCharacters">The minimum non alphanumeric characters.</param>
        /// <param name="regularExpressionToMatch">The regular expression to match.</param>
        /// <param name="storageFormat">The storage format.</param>
        public PasswordSettings( IPasswordResetRetrievalSettings resetOrRetrieval, int minimumLength, int minimumNonAlphanumericCharacters, string regularExpressionToMatch, MembershipPasswordFormat storageFormat)
        {
            ResetOrRetrieval = resetOrRetrieval;
            MinimumLength = minimumLength;
            MinimumNonAlphanumericCharacters = minimumNonAlphanumericCharacters;
            RegularExpressionToMatch = regularExpressionToMatch;
            StorageFormat = storageFormat;
        }

        #region IPasswordSettings Members

        /// <summary>
        /// Gets the reset or retrieval.
        /// </summary>
        /// <value>
        /// The reset or retrieval.
        /// </value>
        public IPasswordResetRetrievalSettings ResetOrRetrieval { get; private set; }
        /// <summary>
        /// Gets the minimum length.
        /// </summary>
        /// <value>
        /// The minimum length.
        /// </value>
        public int MinimumLength { get; private set; }
        /// <summary>
        /// Gets the minimum non alphanumeric characters.
        /// </summary>
        /// <value>
        /// The minimum non alphanumeric characters.
        /// </value>
        public int MinimumNonAlphanumericCharacters { get; private set; }
        /// <summary>
        /// Gets the regular expression to match.
        /// </summary>
        /// <value>
        /// The regular expression to match.
        /// </value>
        public string RegularExpressionToMatch { get; private set; }
        /// <summary>
        /// Gets the storage format.
        /// </summary>
        /// <value>
        /// The storage format.
        /// </value>
        public MembershipPasswordFormat StorageFormat { get; private set; }

        #endregion
    }
}