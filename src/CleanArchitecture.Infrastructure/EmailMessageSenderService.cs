using CleanArchitecture.Core.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Infrastructure
{
    public class EmailMessageSenderService : IMessageSender
    {
        void IMessageSender.SendGuestBookNotificationEmail(string toAddress, string messageBody)
        {
            string fromAddress = "donotreply@huestbook.com";
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("GuestBook", fromAddress));
            message.To.Add(new MailboxAddress(toAddress, toAddress));
            message.Subject = "New message on GuestBook";
            message.Body = new TextPart("plain") { Text = messageBody };
            using (var client = new SmtpClient())
            {
                client.Connect("localhost", 25);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
