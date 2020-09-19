using System;

namespace MS.Customer.Domain
{
    public class Customer
    {
        public virtual Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
