using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web.ViewModels;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var Guestbook = new GuestBook() { Name = "My GuestBook" };
            Func<string, string, Nullable<DateTimeOffset>, GuestBookEntry> newEntry = (mail, message, appDateTime) =>
               {
                   var retval = new GuestBookEntry() { EmailAddress = mail, Message = message };
                   if (appDateTime != null)
                       retval.DateTimeCreated = appDateTime.Value;
                   return retval;
               };

            Guestbook.Entries.Add(newEntry("steve@deviq.com", "Hi", DateTime.UtcNow.AddHours(-2)));

            Guestbook.Entries.Add(newEntry("mark@deviq.com", "Hi", DateTime.UtcNow.AddHours(-2)));

            Guestbook.Entries.Add(newEntry("michelle@deviq.com", "Hi", null));

            var viewmodel = new HomePageViewModel();
            viewmodel.GuestBookName = Guestbook.Name;
            viewmodel.PreviousEntries.AddRange(Guestbook.Entries);
            return View(viewmodel);

        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
