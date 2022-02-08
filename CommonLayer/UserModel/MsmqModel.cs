// <copyright file="MsmqModel.cs" company="Book Store Application">
//      MsmqModel copyright tag.
// </copyright>

namespace Common.UserModel
{
    using Experimental.System.Messaging;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Msmq and Smtp Class
    /// </summary>
    public class MsmqModel
    {
        MessageQueue msmq = new MessageQueue();

        /// <summary>
        /// MSMQs the sender.
        /// </summary>
        /// <param name="token">The token.</param>
        public void MsmqSender(string token)
        {
            try
            {
                msmq.Path = @".\private$\Token";
                if (!MessageQueue.Exists(msmq.Path))
                {
                    MessageQueue.Create(msmq.Path);
                }

                msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                msmq.ReceiveCompleted += MsmqReceiver;
                msmq.Send(token);
                msmq.BeginReceive();
                msmq.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// MSMQs the receiver.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ReceiveCompletedEventArgs"/> instance containing the event data.</param>
        private void MsmqReceiver(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                var msg = msmq.EndReceive(e.AsyncResult);
                string token = msg.Body.ToString();
                string Subject = "Book Store Application Password Reset";
                string Body = token;
                string receiverMail = DecodeJwt(token);

                MailMessage message = new MailMessage("vickytestsmtp@gmail.com", receiverMail);
                message.Body = Body;
                message.IsBodyHtml = true;
                message.Subject = Subject;

                //mail sending code

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                NetworkCredential credential = new NetworkCredential("vickytestsmtp@gmail.com", "TestSmtp");
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = credential;
                smtpClient.Send(message);

                //msmq receiver
                msmq.BeginReceive();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Decodes the JWT.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public static string DecodeJwt(string token)
        {
            try
            {
                var decodeToken = token;
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadJwtToken((decodeToken)) as JwtSecurityToken;
                var result = jsonToken.Claims.FirstOrDefault().Value;
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
