using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class GuestBook : BaseEntity
    {
        public string Name { get; set; }

        public List<GuestBookEntry> Entries { get; set; } = new List<GuestBookEntry>();
    }
}