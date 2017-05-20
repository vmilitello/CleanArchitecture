using CleanArchitecture.Core.Entities; //Is it completely correct?!?
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ViewModels
{
    public class HomePageViewModel
    {
        public string GuestBookName { get; set; }

        public List<GuestBookEntry> PreviousEntries { get; set; } = new List<GuestBookEntry>();
        public GuestBookEntry NewEntry { get; internal set; }
    }
}
