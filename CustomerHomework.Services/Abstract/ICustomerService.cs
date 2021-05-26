using AutoMapper;
using CustomerHomework.Entities.Concrete;
using CustomerHomework.Entities.Dtos;
using CustomerHomework.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHomework.Services.Abstract
{
    public interface ICustomerService
    {
        Customer AddCustomer(CustomerAddDto customerAddDto);
        Customer GetCustomer(int customerId);
        Task<IDataResult<CustomerDto>> UpdateCustomer(CustomerUpdateDto customerUpdateDto);
        Task<IDataResult<CustomerDto>> DeleteCustomer(int customerId);
        Task<IDataResult<CustomerListDto>> GetAll(CustomerListDto customerListDto);
    }
}
