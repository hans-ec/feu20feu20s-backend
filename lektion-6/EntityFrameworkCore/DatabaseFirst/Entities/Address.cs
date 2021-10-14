using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseFirst.Entities
{
    public partial class Address
    {
        public Address()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string AddressLine { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
