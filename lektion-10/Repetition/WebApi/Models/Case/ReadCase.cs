using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Entities;
using WebApi.Models.Customer;

namespace WebApi.Models.Case
{
    public class ReadCase
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }

        public virtual ReadCustomer Customer { get; set; }
    }
}
