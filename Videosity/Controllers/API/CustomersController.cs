using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Videosity.DTO;
using Videosity.Models;

namespace Videosity.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController() {
            _context = new ApplicationDbContext();
        }

        // GET: /api/customers
        public IEnumerable<CustomerDTO> GetCustomers() {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        // GET: /api/customers/1
        public IHttpActionResult GetCustomer(int id) {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null) {
                return NotFound();
            }

            return Ok( Mapper.Map<Customer, CustomerDTO>(customer));
        }


        // POST: /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto){
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            
            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto );
        }

        // PUT: /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto) {
            if (!ModelState.IsValid) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDatabase = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDatabase == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDatabase);

            _context.SaveChanges();
        }

        // DELETE: /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id) {
            var customerInDatabase = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDatabase == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDatabase);
            _context.SaveChanges();
        }
    }
}
