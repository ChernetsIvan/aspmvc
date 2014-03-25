using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo) //также для Ninject
        {
            repository = repo;
        }

<<<<<<< HEAD
        public ViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
=======
        public PartialViewResult Menu()
        {
>>>>>>> styling
            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
<<<<<<< HEAD
            return View(categories);
=======
            return PartialView(categories);
>>>>>>> styling
        }

    }
}
