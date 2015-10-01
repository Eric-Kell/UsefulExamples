﻿using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
  public class ProductController : Controller
  {
    private IProductRepository repository;

    // get from Ninject
    public ProductController(IProductRepository productRepository)
    {
      this.repository = productRepository;
    }

    public ViewResult List()
    {
      return View(repository.Products);
    }
  }
}