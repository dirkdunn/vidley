using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                Customers = _context.Customers.Include(c => c.MembershipType).ToList()
            };
                
            return View(viewModal);
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
            {
                id = 1;
            }

            Customer customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }
    }
}