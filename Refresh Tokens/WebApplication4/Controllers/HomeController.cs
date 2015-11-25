using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      
      ViewBag.Title = "Home Page";
      return View();
    }

  }
}
