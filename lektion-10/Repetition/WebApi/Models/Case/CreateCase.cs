using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Case
{
    public class CreateCase
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }
    }
}
