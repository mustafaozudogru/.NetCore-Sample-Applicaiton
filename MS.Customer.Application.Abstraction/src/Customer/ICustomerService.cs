using MS.Customer.Application.Abstraction.src.Customer.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Customer.Application.Abstraction.src.Customer
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetCustomers();

        Task<CustomerDto> GetCustomersById(Guid customerId);

        Task<CustomerDto> CreateCustomer(CustomerDto customer);

        Task<CustomerDto> UpdateCustomer(CustomerUpdateDto customer);
    }
}
