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
        private List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 0, Name = "Sally Slinger"},
            new Customer { Id = 1, Name ="Bobby Brown" }
        };

        // GET: Customers
        public ActionResult Index()
        {
            
            var viewModal = new CustomersViewModal {
                Customers = customers
            };

            return View(viewModal);
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
            {
                id = 0;
            }

            Customer customer = customers.Find(customerObject => customerObject.Id == id);

            return View(customer);
        }
    }
}