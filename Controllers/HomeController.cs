using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System;
using System.Linq;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            this.ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return this.View("Index");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return this.View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return this.View("Thanks", guestResponse);
            }
            else
            {
                // there is some validation error so
                return this.View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(response => response.WillAttend == true));
        }
    }
}
