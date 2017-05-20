using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Services
{
    public class GuestbookNotificationHandler : IHandle<EntryAddedEvent>
    {
        private readonly IMessageSender _messageSender;

        IRepository<GuestBook> _guestBookRepository;

        public GuestbookNotificationHandler(IRepository<GuestBook> guestBookRepository,  IMessageSender messageSender)
        {
            _messageSender = messageSender;
            _guestBookRepository = guestBookRepository;
        }
        public void Handle(EntryAddedEvent domainEvent)
        {
            var guestBook = _guestBookRepository.GetById(domainEvent.GuestBookID);
            var entry = domainEvent.Entry;
            var emailToNotify = guestBook.Entries.Where(p => p.DateTimeCreated.Date >= DateTime.Now.AddDays(-1)).Select(p => p.EmailAddress).ToList();
            emailToNotify.ForEach(p => _messageSender.SendGuestBookNotificationEmail(p, $"{entry.Message} - {p}" ));

        }
    }
}
