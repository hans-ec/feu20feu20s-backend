using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Models.Customer;

namespace WebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SqlContext _context;

        public CustomersController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCustomer>>> GetCustomers()
        {
            var customers = new List<ReadCustomer>();

            foreach (var customer in await _context.Customers.ToListAsync())
                customers.Add(new ReadCustomer
                {
                    Id = customer.Id,
                    CustomerName = customer.CustomerName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber
                });

            return customers;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerEntity>> GetCustomerEntity(Guid id)
        {
            var customerEntity = await _context.Customers.Include(x => x.Cases).Where(x => x.Id == id).FirstOrDefaultAsync();

            customerEntity.Cases = customerEntity.Cases.OrderByDescending(x => x.Created).ToList();

            if (customerEntity == null)
            {
                return NotFound();
            }

            return customerEntity;
        }


        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerEntity>> PostCustomerEntity(CreateCustomer model)
        {

            var customer = await _context.Customers.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

            if(customer == null)
            {
                var customerEntity = new CustomerEntity
                {
                    Id = Guid.NewGuid(),
                    CustomerName = model.CustomerName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                _context.Customers.Add(customerEntity);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCustomerEntity", new { id = customerEntity.Id }, customerEntity);
            }

            return new ConflictResult();
        }

    }
}
