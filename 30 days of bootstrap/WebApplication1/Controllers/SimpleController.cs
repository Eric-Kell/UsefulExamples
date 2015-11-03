using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using WebApplication1.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
  public class SimpleController : Controller
  {
    // GET: /<controller>/
    public IActionResult Index()
    {
      var person = new Person
      {
        FirstName = "Billy Jo",
        LastName = "McGuffery",
        BirthDate = new DateTime(1990, 6, 1),
        LikesMusic = true,
        Skills = new List<string>() {"Math", "Science", "History"}
      };

      return View(person);
    }
  }
}
