using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CleanArchitecture.Core.Events
{
    public class EntryAddedEvent:BaseDomainEvent
    {
        public int GuestBookID { get; set; }

        public GuestBookEntry Entry { get; set; }
 

        public EntryAddedEvent(int guestBookId, GuestBookEntry entry)
        {
            this.Entry = entry;
            this.GuestBookID = guestBookId;
             
        }

        
    }
}
