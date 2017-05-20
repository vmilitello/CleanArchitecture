using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CleanArchitecture.Core.Services
{
    public class GuestBookAddedEventService : IHandle<GuestBookAddedEvent>
    {
        private readonly IMessageSender _messageSender;

        public GuestBookAddedEventService(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }
        public void Handle(GuestBookAddedEvent domainEvent)
        {
            domainEvent.Subscribers.ToList().ForEach(p => _messageSender.SendGuestBookNotificationEmail(p, "Guess What?!? You got a new entry"));

        }
    }
}
