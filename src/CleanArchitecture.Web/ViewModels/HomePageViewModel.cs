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
        public List<BookeEntryModel> PreviousEntries { get; set; } = new List<BookeEntryModel>();
        public BookeEntryModel NewEntry { get; internal set; } = new BookeEntryModel();

        public class BookeEntryModel
        {
            public string EmailAddress { get; set; }

            public string Message { get; set; }
            public int Id { get; internal set; }
            public DateTimeOffset DateTimeCreated { get; internal set; }
        }

    }
}
