using System.Web.Security;

namespace MvcMembership.Settings
{
    /// <summary>
    /// Password Settings Interface
    /// </summary>
    public interface IPasswordSettings
    {
        /// <summary>
        /// Gets the reset or retrieval.
        /// </summary>
        /// <value>
        /// The reset or retrieval.
        /// </value>
        IPasswordResetRetrievalSettings ResetOrRetrieval { get; }
        /// <summary>
        /// Gets the minimum length.
        /// </summary>
        /// <value>
        /// The minimum length.
        /// </value>
        int MinimumLength { get; }
        /// <summary>
        /// Gets the minimum non alphanumeric characters.
        /// </summary>
        /// <value>
        /// The minimum non alphanumeric characters.
        /// </value>
        int MinimumNonAlphanumericCharacters { get; }
        /// <summary>
        /// Gets the regular expression to match.
        /// </summary>
        /// <value>
        /// The regular expression to match.
        /// </value>
        string RegularExpressionToMatch { get; }
        /// <summary>
        /// Gets the storage format.
        /// </summary>
        /// <value>
        /// The storage format.
        /// </value>
        MembershipPasswordFormat StorageFormat { get; }
    }
}