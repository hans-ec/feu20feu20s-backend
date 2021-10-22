using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApi.Data;
using WebApi.Data.Entities;
using WebApi.Models.Case;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly SqlContext _context;

        public CasesController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Cases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadCase>>> GetCases()
        {
            var cases = new List<ReadCase>();

            foreach (var item in await _context.Cases.Include(x => x.Customer).ToListAsync())
                cases.Add(new ReadCase
                {
                    Id = item.Id,
                    Created = item.Created,
                    Description = item.Description,
                    Customer = new Models.Customer.ReadCustomer
                    {
                        Id = item.Customer.Id,
                        CustomerName = item.Customer.CustomerName,
                        Email = item.Customer.Email,
                        PhoneNumber = item.Customer.PhoneNumber
                    }
                });

            return cases.OrderByDescending(x => x.Created).ToList();

        }

        // GET: api/Cases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseEntity>> GetCaseEntity(Guid id)
        {
            var caseEntity = await _context.Cases.Include(x => x.Customer).Where(x => x.Id == id).FirstOrDefaultAsync();

            if (caseEntity == null)
            {
                return NotFound();
            }

            return new OkObjectResult(new ReadCase
            {
                Id = caseEntity.Id,
                Created = caseEntity.Created,
                Description = caseEntity.Description,
                Customer = new Models.Customer.ReadCustomer
                {
                    Id = caseEntity.Customer.Id,
                    CustomerName = caseEntity.Customer.CustomerName,
                    Email = caseEntity.Customer.Email,
                    PhoneNumber = caseEntity.Customer.PhoneNumber
                }
            });
        }


        // POST: api/Cases
        [HttpPost]
        public async Task<ActionResult<CaseEntity>> PostCaseEntity(CreateCase model)
        {
            var customer = await _context.Customers.FindAsync(model.CustomerId);

            if(customer != null)
            {
                var caseEntity = new CaseEntity
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customer.Id,
                    Created = DateTime.Now,
                    Description = model.Description
                };

                _context.Cases.Add(caseEntity);
                await _context.SaveChangesAsync();

                return new CreatedResult("", new { });
            }

            return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "Customer couldn't be found." }));
        }


    }
}
