using CustomerHomework.Data.Concrete.EntityFramework;
using CustomerHomework.Entities.Concrete;
using CustomerHomework.Entities.Dtos;
using CustomerHomework.Services.Abstract;
using CustomerHomework.Services.FluentValidation;
using CustomerHomework.Shared;
using CustomerHomework.Shared.Entities.Concrete;
using CustomerHomework.Shared.Utilities.Results.Abstract;
using CustomerHomework.Shared.Utilities.Results.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHomework.Services.Concrete
{
    public class CustomerManager : ManagerBase,ICustomerService
    {
        // private readonly CustomerHomeworkDbContext _contextCustomer;
        public CustomerManager(CustomerHomeworkDbContext contextCustomer, IMapper mapper) : base(contextCustomer, mapper)
        {

        }

        public Customer AddCustomer(CustomerAddDto customerAddDto)
        {
            var result = ValidationTool.Validate(new CustomerAddDtoValidator(), customerAddDto);
            if (result!=null)
            {

                var customer = new Customer
                {
                    Firstname = customerAddDto.FirstName,
                    Lastname = customerAddDto.LastName,
                    EmailAddress = customerAddDto.EmailAddress,
                    Age = customerAddDto.Age,
                    Gender = customerAddDto.Gender,
                };
                DbContext.Customers.Add(customer);
                DbContext.SaveChanges();
                return customer;


            }
            else
            {
                return new Customer { Firstname = "Hata var" };
            }
        }

        public Customer GetCustomer(int customerId)
        {
            return DbContext.Customers.SingleOrDefault(c => c.Id == customerId);
        }


        public async Task<IDataResult<CustomerDto>> DeleteCustomer(int customerId)
        {
            try
            {
                var customer = await DbContext.Customers.SingleOrDefaultAsync(u => u.Id == customerId);
                if (customer != null)
                {
                    customer.ModifiedDate = DateTime.Now;
                    DbContext.Customers.Remove(customer);
                    await DbContext.SaveChangesAsync();
                    return new DataResult<CustomerDto>(ResultStatus.Success,
                        $"{customer.Firstname} adlı müşteri başarıyla silinmiştir.", new CustomerDto
                        {
                            Customer = customer
                        });
                }
                else
                {
                    return new DataResult<CustomerDto>(ResultStatus.Warning, $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.", null, new List<ValidationError>(){new ValidationError
                    {
                        PropertyName = "customerId",
                        Message = $"{customerId} müşteri koduna ait bir müşteri bulunamadı."
                    }});
                }
            }
            catch (Exception exception)
            {
                return new DataResult<CustomerDto>(ResultStatus.Error, exception.Message, null, exception);
            }

        }


        public async Task<IDataResult<CustomerDto>> UpdateCustomer(CustomerUpdateDto customerUpdateDto)
        {
            try
            {
                var result = ValidationTool.Validate(new CustomerUpdateDtoValidator(), customerUpdateDto);
                if (result.ResultStatus == ResultStatus.Error)
                {
                    return new DataResult<CustomerDto>(ResultStatus.Warning, $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.", null, result.ValidationErrors);
                }
                var oldCustomer = await DbContext.Customers.SingleOrDefaultAsync(u => u.Id == customerUpdateDto.Id);
                if (oldCustomer != null)
                {

                    var newCustomer = Mapper.Map<CustomerUpdateDto, Customer>(customerUpdateDto, oldCustomer);
                    newCustomer.ModifiedDate = DateTime.Now;
                    DbContext.Customers.Update(newCustomer);
                    await DbContext.SaveChangesAsync();
                    return new DataResult<CustomerDto>(ResultStatus.Success,
                        $"{newCustomer.EmailAddress} e-posta adresine ait kullanıcı başarıyla güncellenmiştir.", new CustomerDto
                        {
                            Customer = newCustomer
                        });
                }
                else
                {
                    return new DataResult<CustomerDto>(ResultStatus.Warning,
                        $"Bir veya daha fazla validasyon hatası ile karşılaşıldı.", null, new List<ValidationError> { new ValidationError { PropertyName = "Id", Message = $"{customerUpdateDto.Id} Id'li kullanıcı bulunamadı." } });
                }
            }
            catch (Exception exception)
            {
                return new DataResult<CustomerDto>(ResultStatus.Error, exception.Message, null, exception);
            }
        }

        //public Customer UpdateCustomer(CustomerUpdateDto customerUpdateDto)
        //{
        //    var oldUser = _contextCustomer.Customers.SingleOrDefaultAsync(u => u.Id == customerUpdateDto.Id);

        //    var customer = _mapper.Map<Customer>(customerUpdateDto,oldUser);
        //    customer.ModifiedDate = customerUpdateDto.ModifiedDate;
        //    customer.Firstname = customerUpdateDto.FirstName;
        //    customer.Lastname = customerUpdateDto.LastName;
        //    customer.Age = customerUpdateDto.Age;
        //    customer.EmailAddress = customerUpdateDto.EmailAddress;
        //    customer.Gender = customerUpdateDto.Gender;
        //    _contextCustomer.Customers.Update(customer);
        //     _contextCustomer.SaveChangesAsync();

        //    return new Customer { Firstname = "Kullanıcı güncellenmiştir", Lastname = "Hem de Başarıyla ;)" };
        //}

        //public async Task DeleteCustomer(int customerId)
        //{
        //    var customer = await _contextCustomer.Customers.SingleOrDefaultAsync(c => c.Id == customerId);
        //    if (customer != null)
        //    {
        //         _contextCustomer.Customers.Remove(customer);
        //        await _contextCustomer.SaveChangesAsync();
        //       // return customer.Firstname = "Kullanıcı başari ile silinmiştir";
        //    }
        //    else
        //    {
        //       // return customer.Firstname = "Silinemedi çünkü böyle bir kullanıcı yok";
        //    }
        //}

    }
}
