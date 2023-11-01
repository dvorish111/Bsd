using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static  class IServiceCollectionExstensions
    {
        public static void AddRepositories( this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddDbContext<UserssContext>();
        }
    }
}
