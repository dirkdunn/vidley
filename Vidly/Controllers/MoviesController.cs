using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        [HttpGet]
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer> {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
            //return Content("Hello World!");
            //return HttpNotFound();
            //return EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1});
            //return Json(new {
            //    testing =" test",
            //    array = new string[] { "hello", "array" },
            //    subObject = new { itemName = "something here" }
            //}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //movies
        public ActionResult Details(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            var movies = new List<Movie> {
                new Movie { Id = 0, Name = "Shrek"},
                new Movie { Id = 1, Name = "Lion King" }
            };

            var viewModal = new MoviesViewModal
            {
                Movies = movies
            };

            return View(viewModal);
        }
    }
}