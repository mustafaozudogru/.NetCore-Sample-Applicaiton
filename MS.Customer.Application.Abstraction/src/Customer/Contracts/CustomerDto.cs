using System;

namespace MS.Customer.Application.Abstraction.src.Customer.Contracts
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
