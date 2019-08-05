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
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

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
        public ActionResult Details(int? id, string sortBy)
        {
            if (!id.HasValue)
            {
                id = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            Movie movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
         
            var viewModal = new MoviesViewModal
            {
                Movies = movies
            };

            return View(viewModal);
        }
    }
}