using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Customer.Application.Abstraction.src.Customer.Contracts
{
    public class CustomerUpdateDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
