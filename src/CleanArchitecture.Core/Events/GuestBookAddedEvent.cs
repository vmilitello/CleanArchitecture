using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CleanArchitecture.Core.Events
{
    public class GuestBookAddedEvent:BaseDomainEvent
    {
        private GuestBook _guestbook;

        public IEnumerable<string> Subscribers { get; private set; }
        public string MailAddress { get;  }
        public GuestBookAddedEvent(GuestBook guestbook)
        {
            _guestbook = guestbook;
            Subscribers = guestbook.Entries.Where(p => p.DateTimeCreated.Date >= DateTime.Now.AddDays(-1)).Select(p => p.EmailAddress).ToList();
             
        }

        
    }
}
