namespace MvcMembership
{
    /// <summary>
    /// Factory for AspNetMembershipProviderUserService
    /// </summary>
    /// <seealso cref="MvcMembership.IUserServiceFactory" />
    public class AspNetMembershipProviderUserServiceFactory : IUserServiceFactory
    {
        #region IUserServiceFactory Members

        /// <summary>
        /// Makes this instance.
        /// </summary>
        /// <returns></returns>
        public IUserService Make()
        {
            return new AspNetMembershipProviderWrapper();
        }

        #endregion
    }
}