using System.Net.Mail;

namespace MvcMembership
{
    /// <summary>
    /// SmtpClient Interface
    /// </summary>
    public interface ISmtpClient
    {
        /// <summary>
        /// Sends the specified mail message.
        /// </summary>
        /// <param name="mailMessage">The mail message.</param>
        void Send(MailMessage mailMessage);
    }
}