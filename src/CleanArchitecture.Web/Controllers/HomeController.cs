using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web.ViewModels;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<GuestBook> _guestBookRepo;

        public HomeController(IRepository<GuestBook> repo)
        {
            _guestBookRepo = repo;

        }
        public IActionResult Index()
        {
            if (!_guestBookRepo.List().Any())
            {
                var newGuestBook = new GuestBook() { Name = "My GuestBook" };
                Func<string, string, Nullable<DateTimeOffset>, GuestBookEntry> newEntry = (mail, message, appDateTime) =>
                {
                    var retval = new GuestBookEntry() { EmailAddress = mail, Message = message };
                    if (appDateTime != null)
                        retval.DateTimeCreated = appDateTime.Value;
                    return retval;
                };

                newGuestBook.Entries.Add(newEntry("steve@deviq.com", "Hi", DateTime.UtcNow.AddHours(-2)));
                _guestBookRepo.Add(newGuestBook);
            }

            var viewmodel = new HomePageViewModel();
            var Guestbook = _guestBookRepo.GetById(1);
            viewmodel.GuestBookName = Guestbook.Name;


            viewmodel.PreviousEntries.AddRange(Guestbook.Entries.Select(p=> new HomePageViewModel.BookEntryModel() { Message = p.Message, DateTimeCreated = p.DateTimeCreated, Id = p.Id, EmailAddress = p.EmailAddress }).ToList());
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

        [HttpPost]
        public IActionResult Index(HomePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guestbook = _guestBookRepo.GetById(1);

                guestbook.Add( new GuestBookEntry() { Message = model.NewEntry.Message, EmailAddress = model.NewEntry.EmailAddress, Id = model.NewEntry.Id, DateTimeCreated = DateTime.UtcNow });

                _guestBookRepo.Update(guestbook);
                model.PreviousEntries.Clear();
                
                model.PreviousEntries.AddRange(guestbook.Entries.Select(p => new HomePageViewModel.BookEntryModel() { Message = p.Message, DateTimeCreated = p.DateTimeCreated, Id = p.Id, EmailAddress = p.EmailAddress }).ToList());

            }
            return View(model);
        }
    }
}
