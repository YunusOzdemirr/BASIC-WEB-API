using CustomerHomework.Data.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHomework.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<CustomerHomeworkDbContext>();
            return serviceCollection;
        }
    }
}
