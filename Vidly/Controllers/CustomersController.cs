using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
 
        // Constructor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            var viewModal = new CustomersViewModal()
            {
                Customers = _context.Customers.ToList()
            };
                
            return View(viewModal);
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
            {
                id = 0;
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            return View(customer);
        }
    }
}