using System.Linq;
using Microsoft.AspNet.Mvc;
using PartyInvites.Models;

/*
    View components
    http://www.asp.net/vnext/overview/aspnet-vnext/vc#intro
*/

namespace PartyInvites.ViewComponents
{
  public class AttendeesViewComponent : ViewComponent
  {
    public IViewComponentResult Invoke()
    {
      return View(Repository.Responses.Where(x => x.WillAttend == true));
    }
  }
}
