using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure.Binders
{
  public class CartModelBinder : IModelBinder
  {
    private const string sessionKey = "Cart";

    // The ControllerContext provides access to all the information that the controller class has,
    // which includes details of the request from the client. 

    // The ModelBindingContext gives you information about the model object you are being asked to build
    // and some tools for making the binding process easier.
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
      // get the Cart from the session
      Cart cart = null;
      if (controllerContext.HttpContext.Session != null)
      {
        cart = (Cart) controllerContext.HttpContext.Session[sessionKey];
      }
      // create the Cart if there wasn't one in the session data
      if (cart == null)
      {
        cart = new Cart();
        if (controllerContext.HttpContext.Session != null)
        {
          controllerContext.HttpContext.Session[sessionKey] = cart;
        }
      }
      // return the cart
      return cart;
    }
  }
}