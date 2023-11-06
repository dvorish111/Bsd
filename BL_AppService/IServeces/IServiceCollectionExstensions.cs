using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

using Microsoft.Extensions.DependencyInjection;

namespace BL_AppService.IServeces
{
    public static class IServiceCollectionExstensions
    {
        public static void AddAppServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddRepositories();

        }
    }
}
