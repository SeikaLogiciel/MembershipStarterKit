using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcMembership
{
    /// <summary>
    /// User Service Factory InterfaceS
    /// </summary>
    public interface IUserServiceFactory
    {
        /// <summary>
        /// Makes this instance.
        /// </summary>
        /// <returns></returns>
        IUserService Make();
    }
}
