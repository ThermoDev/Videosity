using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Videosity.Models;
using Videosity.ViewModels;

namespace Videosity.Controllers
{
    public class CustomersController : Controller
    {
       
        // GET: Customers
        public ActionResult Index()
        {
            var indexCustomers = getIndexcustomers();


            var customers = new IndexCustomerViewModel() {};

            return View(customers);
        }

        [Route("customers/details/{id}")]
        public ActionResult SpecificCustomer(int id) {
            return View(getIndexcustomers().Customers[id]);
        }


        public IndexCustomerViewModel getIndexcustomers() {

            //var customerOne = new Customer() { Name = "Shrek Winfley" };
            //var customerTwo = new Customer() { Name = "Jensen Ackles" };

            var customers = new List<Customer>() {
                    new Customer {Id=0, Name = "Shrek Winfley" },
                    new Customer {Id=1, Name = "Jensen Ackles" }
            };

            var indexCustomers = new IndexCustomerViewModel() {
                Customers = customers
            };
            return indexCustomers;
        }
    }
}