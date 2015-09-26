using System;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
  public class HomeController : Controller
  {
    public string Index() {
      return "Navigate to a URL to show an example";
    }

    public ViewResult AutoProperty()
    {
      // create a new Product object
      Product myProduct = new Product();
      // set the property value
      myProduct.Name = "Kayak";
      // get the property
      string productName = myProduct.Name;
      // generate the view
      return View("Result",
      (object)String.Format("Product name: {0}", productName));
    }

    public ViewResult CreateProduct()
    {
      // create a new Product object
      Product myProduct = new Product();
      // set the property values
      myProduct.ProductID = 100;
      myProduct.Name = "Kayak";
      myProduct.Description = "A boat for one person";
      myProduct.Price = 275M;
      myProduct.Category = "Watersports";
      return View("Result", (object)String.Format("Category: {0}", myProduct.Category));
    }

  }
}