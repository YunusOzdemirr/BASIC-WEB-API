using CustomerHomework.Entities.Dtos;
using CustomerHomework.Services.Abstract;
using CustomerHomework.Shared.Utilities.Results.ComplexTypes;
using CustomerHomework.Shared.Utilities.Results.Abstract;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace CustomerHomework.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
           this._customerService = customerService;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("[action]")]
        public IActionResult AddCustomer(CustomerAddDto customerAddDto)
        {
            var customer = _customerService.AddCustomer(customerAddDto);
            return Ok(customer);
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("[action]")]
        public IActionResult GetCustomer(int customId)
        {
            var customer = _customerService.GetCustomer(customId);
            return Ok(customer);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCustomer(CustomerUpdateDto customerUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var updateResult = await _customerService.UpdateCustomer(customerUpdateDto);
                switch (updateResult.ResultStatus)
                {
                    case ResultStatus.Warning:
                        return BadRequest(new ApiResult
                        {
                            ResultStatus = updateResult.ResultStatus,
                            Data = updateResult.Data,
                            Detail = updateResult.Message,
                            Message = updateResult.Message,
                            Href = Url.Link("", new { Controller = "Customers", Action = "Update" }),
                            ValidationErrors = updateResult.ValidationErrors,
                            StatusCode = HttpStatusCode.BadRequest,
                        });
                    case ResultStatus.Error:
                        return StatusCode(500, new ApiResult
                        {
                            ResultStatus = updateResult.ResultStatus,
                            Data = updateResult.Data,
                            Detail = updateResult.Exception.StackTrace,
                            Message = updateResult.Message,
                            Href = Url.Link("", new { Controller = "Customers", Action = "Update" }),
                            ValidationErrors = updateResult.ValidationErrors,
                            StatusCode = HttpStatusCode.InternalServerError
                        });
                    default: //ResultStatus.Success
                        return Ok(new ApiResult
                        {
                            ResultStatus = updateResult.ResultStatus,
                            Data = updateResult.Data,
                            Message = updateResult.Message,
                            Detail = updateResult.Message,
                            Href = Url.Link("", new { Controller = "Customers", Action = "Update" }),
                            ValidationErrors = updateResult.ValidationErrors,
                            StatusCode = HttpStatusCode.OK
                        });
                }
            }
            return Ok(new ApiResult
            {
                ResultStatus = ResultStatus.Error,
                Data = null,
                Message = $"Lütfen modeli doğru formatta gönderiniz.",
                Detail = $"Lütfen modeli doğru formatta gönderiniz.",
                Href = Url.Link("", new { Controller = "Customers", Action = "Update" }),
                ValidationErrors = null,
                StatusCode = HttpStatusCode.BadRequest
            });
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("[action]")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            if (ModelState.IsValid)
            {
                var deleteResult = await _customerService.DeleteCustomer(customerId);
                switch (deleteResult.ResultStatus)
                {
                    case ResultStatus.Warning:
                        return BadRequest(new ApiResult
                        {
                            ResultStatus = deleteResult.ResultStatus,
                            Data = deleteResult.Data,
                            Detail = deleteResult.Message,
                            Message = deleteResult.Message,
                            Href = Url.Link("", new { Controller = "Customers", Action = "Delete" }),
                            ValidationErrors = deleteResult.ValidationErrors,
                            StatusCode = HttpStatusCode.BadRequest,
                        });
                    case ResultStatus.Error:
                        return StatusCode(500, new ApiResult
                        {
                            ResultStatus = deleteResult.ResultStatus,
                            Data = deleteResult.Data,
                            Detail = deleteResult.Exception.StackTrace,
                            Message = deleteResult.Message,
                            Href = Url.Link("", new { Controller = "Customers", Action = "Delete" }),
                            ValidationErrors = deleteResult.ValidationErrors,
                            StatusCode = HttpStatusCode.InternalServerError
                        });
                    default: //ResultStatus.Success
                        return Ok(new ApiResult
                        {
                            ResultStatus = deleteResult.ResultStatus,
                            Data = deleteResult.Data,
                            Message = deleteResult.Message,
                            Detail = deleteResult.Message,
                            Href = Url.Link("", new { Controller = "Customers", Action = "Delete" }),
                            ValidationErrors = deleteResult.ValidationErrors,
                            StatusCode = HttpStatusCode.OK
                        });
                }
            }
            return Ok(new ApiResult
            {
                ResultStatus = ResultStatus.Error,
                Data = null,
                Message = $"Lütfen modeli doğru formatta gönderiniz.",
                Detail = $"Lütfen modeli doğru formatta gönderiniz.",
                Href = Url.Link("", new { Controller = "Customers", Action = "Delete" }),
                ValidationErrors = null,
                StatusCode = HttpStatusCode.BadRequest
            });
        }

    }
}
