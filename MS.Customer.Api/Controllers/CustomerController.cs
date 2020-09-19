using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS.Customer.Application.Abstraction.src.Customer;
using MS.Customer.Application.Abstraction.src.Customer.Contracts;

namespace MS.Customer.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Action to get customer list from the database.
        /// </summary>
        /// <returns>Returns customer list</returns>
        /// <response code="200">Returns a list of all customers in the database</response>
        /// <response code="400">Returned if the customers couldn't be loaded</response>
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> Customer()
        {
            try
            {
                var result = await _customerService.GetCustomers().ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Action to create a new customer in the database.
        /// </summary>
        /// <param name="customerModel">Model to create a new customer</param>
        /// <returns>Returns the created customer</returns>
        /// /// <response code="200">Returned if the customer was created</response>
        /// /// <response code="400">Returned if the model couldn't be parsed or the customer couldn't be saved</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Customer([FromBody] CustomerDto customerModel)
        {
            try
            {
                var result = await _customerService.CreateCustomer(customerModel).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Action to update a new customer in the database.
        /// </summary>
        /// <param name="customerModel">Model to update a customer.</param>
        /// <returns>Returns the created customer</returns>
        /// /// <response code="200">Returned if the customer was updated</response>
        /// /// <response code="400">Returned if the model couldn't be parsed or the customer couldn't be updated</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult<CustomerDto>> Customer([FromBody] CustomerUpdateDto customerModel)
        {
            try
            {
                var result = await _customerService.UpdateCustomer(customerModel).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
