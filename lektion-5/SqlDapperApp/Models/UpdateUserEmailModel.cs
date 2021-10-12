using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDapperApp.Models
{
    class UpdateUserEmailModel
    {
        public int SearchId { get; set; }
        public string Email { get; set; }
    }
}
