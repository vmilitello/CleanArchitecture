using CleanArchitecture.Core.Entities; //Is it completely correct?!? Turns out NO, and I was right
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ViewModels
{
    public class HomePageViewModel
    {
        public string GuestBookName { get; set; }

        //and this prop should map to the model 
        public List<BookEntryModel> PreviousEntries { get; private set; } = new List<BookEntryModel>();
        public BookEntryModel NewEntry { get; internal set; } = new BookEntryModel();

        public class BookEntryModel
        {
            public string EmailAddress { get; set; }

            public string Message { get; set; }
            public int Id { get; internal set; }
            public DateTimeOffset DateTimeCreated { get; internal set; }
        }

    }
}
