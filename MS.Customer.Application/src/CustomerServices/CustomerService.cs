using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MS.Customer.Application.Abstraction.src.Customer;
using MS.Customer.Application.Abstraction.src.Customer.Contracts;
using MS.Customer.Persistence.src.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Customer.Application.src.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Domain.Customer> repository;

        public CustomerService(IMapper mapper, IRepository<Domain.Customer> repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            var customer = this.mapper.Map<Domain.Customer>(customerDto);

            var result = await this.repository.AddAsync(customer).ConfigureAwait(false);

            return this.mapper.Map<CustomerDto>(result);
        }

        public async Task<List<CustomerDto>> GetCustomers()
        {
            var customerList = await this.repository.GetAll().ToListAsync().ConfigureAwait(false);

            return this.mapper.Map<List<CustomerDto>>(customerList);
        }

        public async Task<CustomerDto> GetCustomersById(Guid customerId)
        {
            var result = await this.repository.GetAll().FirstOrDefaultAsync(m => m.Id == customerId);

            return this.mapper.Map<CustomerDto>(result);
        }

        public async Task<CustomerDto> UpdateCustomer(CustomerUpdateDto customerDto)
        {
            var customer = this.mapper.Map<Domain.Customer>(customerDto);

            var result = await this.repository.UpdateAsync(customer).ConfigureAwait(false);

            return this.mapper.Map<CustomerDto>(result);
        }
    }
}
