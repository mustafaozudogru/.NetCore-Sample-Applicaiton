using AutoMapper;
using FakeItEasy;
using MS.Customer.Application.Abstraction.src.Customer.Contracts;
using MS.Customer.Application.src.CustomerServices;
using MS.Customer.Persistence.src.Repository;
using Xunit;

namespace MS.Customer.Service.Test.Services
{
    public class CustomerServiceTest
    {
        private readonly CustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Customer> _repository;

        public CustomerServiceTest()
        {
            _mapper = A.Fake<IMapper>();
            _repository = A.Fake<IRepository<Domain.Customer>>();
            _customerService = new CustomerService(_mapper, _repository);
        }

        [Fact]
        public async void Post_ShouldCallCreateCustomer()
        {
            await _customerService.CreateCustomer(new CustomerDto());

            A.CallTo(() => _repository.AddAsync(A<Domain.Customer>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async void Put_ShouldCallUpdateCustomer()
        {
            await _customerService.UpdateCustomer(new CustomerUpdateDto());

            A.CallTo(() => _repository.UpdateAsync(A<Domain.Customer>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async void Get_ShouldCallGetAllCustomer()
        {
            await _customerService.GetCustomers();

            A.CallTo(() => _repository.GetAll()).MustHaveHappenedOnceExactly();
        }
    }
}