using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    public IActionResult Rsvp()
    {
      return View();
    }


    [HttpPost]
    public IActionResult Rsvp(GuestResponse response)
    {
      if (ModelState.IsValid)
      {
        Repository.Add(response);
        return View("Thanks", response);
      }
      else
      {
        return View();
      }
    }

    /*
    A child action method renders inline HTML markup for part of a view instead of rendering a whole complete view.
    Unavaliable from url
    */

    // [ChildActionOnly]
    //public IActionResult Attendees()
    //{
    //  return View(Repository.Responses.Where(x => x.WillAttend == true));
    //}

  }
}
