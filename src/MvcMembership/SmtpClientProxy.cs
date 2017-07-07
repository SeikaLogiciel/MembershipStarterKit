using System.Net.Mail;

namespace MvcMembership
{
    /// <summary>
    /// SMTP Client Proxy
    /// </summary>
    /// <seealso cref="MvcMembership.ISmtpClient" />
    public class SmtpClientProxy : ISmtpClient
    {
        private readonly SmtpClient _smtpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SmtpClientProxy"/> class.
        /// </summary>
        public SmtpClientProxy()
        {
            _smtpClient = new SmtpClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmtpClientProxy"/> class.
        /// </summary>
        /// <param name="smtpClient">The SMTP client.</param>
        public SmtpClientProxy(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        #region ISmtpClient Members

        /// <summary>
        /// Sends the specified mail message.
        /// </summary>
        /// <param name="mailMessage">The mail message.</param>
        public void Send(MailMessage mailMessage)
        {
            _smtpClient.Send(mailMessage);
        }

        #endregion
    }
}