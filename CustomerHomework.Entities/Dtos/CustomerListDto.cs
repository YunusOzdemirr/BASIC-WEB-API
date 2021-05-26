using CustomerHomework.Entities.ComplexTypes;
using CustomerHomework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHomework.Entities.Dtos
{
    public class CustomerListDto
    {
        public List<Customer> Customers { get; set; }
    }
}
