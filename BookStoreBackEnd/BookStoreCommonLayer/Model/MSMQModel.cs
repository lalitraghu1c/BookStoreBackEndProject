using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using Experimental.System.Messaging;
using System.Xml.Linq;

namespace BookStoreCommonLayer.Model
{
    public class MSMQModel
    {
        MessageQueue messageQueue = new MessageQueue();
        public void sendData2Queue(string token)
        {
            messageQueue.Path = @".\private$\BookStore";
            if (!MessageQueue.Exists(messageQueue.Path))
            {
                MessageQueue.Create(messageQueue.Path);
            }

            messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted;  //Delegate
            messageQueue.Send(token);
            messageQueue.BeginReceive();
            messageQueue.Close();
        }

        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e) //Event
        {
            var msg = messageQueue.EndReceive(e.AsyncResult);
            var token = msg.Body.ToString();
            string subject = "Book Store Application Reset Link";
            string body = token;
            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("samrat.raghu1c@gmail.com", "cxoabkamufdvqerv"),
                EnableSsl = true
            };
            smtp.Send("samrat.raghu1c@gmail.com", "samrat.raghu1c@gmail.com", subject, body);
            messageQueue.BeginReceive();
        }
    }
}
