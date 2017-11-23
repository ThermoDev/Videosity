using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using Videosity.Models;
using Videosity.ViewModels;

namespace Videosity.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        
        // Constructor
        public CustomersController() {
            _context = new ApplicationDbContext();
        }

        // Dispose of the _context
        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        public ActionResult New() {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newCustomerViewModel = new NewCustomerViewModel{
                MembershipTypes = membershipTypes
            };

            return View(newCustomerViewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer) {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ActionResult Index()
        {
            var IndexCustomers = new IndexCustomerViewModel() {
                // Customers is set to the list of customers found in the context, including the customers membership type.
                Customers = _context.Customers.Include(c => c.MembershipType).ToList()
            };

            return View(IndexCustomers);
        }

        // GET: Customers/Details/<id>
        [Route("customers/details/{id}")]
        public ActionResult SpecificCustomer(int id) {
            return View(_context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id));
        }

    }
}