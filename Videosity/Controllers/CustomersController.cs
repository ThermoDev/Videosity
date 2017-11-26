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
            var newCustomerViewModel = new CustomerFormViewModel{
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", newCustomerViewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer) {
            // Use ModelState.IsValid to change the flow of the program,
            // and return the same view if the form submitted is not valid.
            if (!ModelState.IsValid) {

                var viewModel = new CustomerFormViewModel {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
                if (customer.Id == 0) {
                    _context.Customers.Add(customer);
                }
                else {
                    var customerToUpdate = _context.Customers.Single(c => c.Id == customer.Id);

                    customerToUpdate.Name = customer.Name;
                    customerToUpdate.BirthDate = customer.BirthDate;
                    customerToUpdate.MembershipTypeId = customer.MembershipTypeId;
                    customerToUpdate.IsSubscribed = customer.IsSubscribed;

                    /* The property of the customer is updated using key:value pairs. */
                    //TryUpdateModel(customerToUpdate);
                }
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

        public ActionResult Edit (int id) {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null) {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

    }
}