using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PartyInvites.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PartyInvites.Controllers
{
  [Route("api/[controller]")]
  public class RsvpController : Controller
  {
    [HttpGet]
    public IEnumerable<GuestResponse> GetAttendees()
    {
      return Repository.Responses.Where(x => x.WillAttend == true);
    }

    [HttpPost]
    public void PostResponse(GuestResponse response)
    {
      if (ModelState.IsValid)
      {
        Repository.Add(response);
      }
    }

  }
}
