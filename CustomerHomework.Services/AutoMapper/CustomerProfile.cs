using AutoMapper;
using CustomerHomework.Entities.Concrete;
using CustomerHomework.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHomework.Services.AutoMapper
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerUpdateDto, Customer>().ForMember(destinationMember=>destinationMember.ModifiedDate,opt=>opt.MapFrom(x=>DateTime.Now));
            CreateMap<CustomerAddDto, Customer>();
            CreateMap<CustomerDeleteDto, Customer>();
        }
    }
}
