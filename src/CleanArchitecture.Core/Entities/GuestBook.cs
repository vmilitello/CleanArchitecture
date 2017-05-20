using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class GuestBook : BaseEntity
    {
        public string Name { get; set; }

        public List<GuestBookEntry> Entries { get; private set; } = new List<GuestBookEntry>();

        public void AddEntry(GuestBookEntry entry)
        {
            Entries.Add(entry);
            Events.Add(new EntryAddedEvent( this.Id , entry));
        }

    }
}