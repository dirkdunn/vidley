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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            // You can also create a custom model for what is to be updated (UpdateCustomerDto) with Automapper.
            // New Customer
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            // Existing Customer to add to DB
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                // Microsoft Approach (Security Holes)
                // TryUpdateModel(customerInDb, "", new string[] {"Name", "Email"});
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
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

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}