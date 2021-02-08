using AutoMapper;
using CustomerHomework.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHomework.Services.Concrete
{
    public class ManagerBase
    {
        public ManagerBase(CustomerHomeworkDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        protected CustomerHomeworkDbContext DbContext { get; }
        protected IMapper Mapper { get; }
    }
}
