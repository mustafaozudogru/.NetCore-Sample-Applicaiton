using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MS.Customer.Api.Controllers;
using MS.Customer.Application.Abstraction.src.Customer;
using MS.Customer.Application.Abstraction.src.Customer.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace MS.Customer.Test.Controllers
{
    public class CustomerControllerTest
    {
        private readonly CustomerController _customerTest;
        private readonly CustomerDto _customerModel;
        private readonly List<CustomerDto> _customerListModel;
        private readonly CustomerUpdateDto _customerUpdateModel;
        private readonly ICustomerService _customerService;
        private readonly Guid _id = Guid.Parse("5224ed94-6d9c-42ec-ba93-dfb11fe68931");

        public CustomerControllerTest()
        {
            _customerService = A.Fake<ICustomerService>();

            _customerTest = new CustomerController(_customerService);

            _customerModel = new CustomerDto()
            {
                FirstName = "Name",
                LastName = "LastName",
                Address = "Adres",
                Birthday = new DateTime(1989, 02, 16),
            };

            _customerUpdateModel = new CustomerUpdateDto()
            {
                Id = _id,
                FirstName = "Name",
                LastName = "LastName",
                Address = "Adres",
                Birthday = new DateTime(1989, 02, 16),
            };

            _customerListModel = new List<CustomerDto>
            {
                new CustomerDto {FirstName = "Name1",LastName = "LastName1",Address = "Adres1",Birthday = new DateTime(1989, 02, 16) },
                new CustomerDto {FirstName = "Name2",LastName = "LastName2",Address = "Adres2",Birthday = new DateTime(1989, 02, 16)},
                new CustomerDto {FirstName = "Name3",LastName = "LastName3",Address = "Adres3",Birthday = new DateTime(1989, 02, 16) }
            };

            A.CallTo(() => _customerService.CreateCustomer(A<CustomerDto>._)).Returns(_customerModel);
            A.CallTo(() => _customerService.UpdateCustomer(A<CustomerUpdateDto>._)).Returns(_customerModel);
            A.CallTo(() => _customerService.GetCustomers()).Returns(_customerListModel);
        }

        [Theory]
        [InlineData("CustomerCreateAsync: Customer is null")]
        public async void Post_WhenAnExceptionOccurs_ShouldReturnBadRequest(string message)
        {
            var result = await _customerTest.Customer(_customerModel);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(message);
        }

        [Theory]
        [InlineData("CustomerUpdateAsync: Customer is null")]
        public async void Put_WhenAnExceptionOccurs_ShouldReturnBadRequest(string message)
        {
            var result = await _customerTest.Customer(_customerUpdateModel);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(message);
        }

        [Theory]
        [InlineData("GetCustomer: Customer is null")]
        public async void Get_WhenAnExceptionOccurs_ShouldReturnBadRequest(string message)
        {
            var result = await _customerTest.Customer();

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
            (result.Result as BadRequestObjectResult)?.Value.Should().Be(message);
        }

        [Fact]
        public async void Post_ShouldReturnCustomer()
        {
            var result = await _customerTest.Customer(_customerModel);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<CustomerDto>();
        }

        [Fact]
        public async void Put_ShouldReturnCustomer()
        {
            var result = await _customerTest.Customer(_customerUpdateModel);

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value.Should().BeOfType<CustomerDto>();
        }

        [Fact]
        public async void Get_ShouldReturnCustomer()
        {
            var result = await _customerTest.Customer();

            (result.Result as StatusCodeResult)?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Value?.Should().HaveCountGreaterThan(0, "Customer found");
            result.Value.Should().BeOfType<List<CustomerDto>>();
        }
    }
}