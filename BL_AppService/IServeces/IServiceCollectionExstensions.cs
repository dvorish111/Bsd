using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL_AppService.Services;
using DAL;
using Microsoft.Extensions.DependencyInjection;


using Microsoft.Extensions.DependencyInjection;

namespace BL_AppService.IServeces
{
    public static class IServiceCollectionExstensions
    {
        public static void AddAppServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICampaignService, CampaignService>();
            serviceCollection.AddScoped<IDonorService, DonorService>();
            serviceCollection.AddScoped<IPermissionService, PermissionService>();
             serviceCollection.AddScoped<INeighborhoodService, NeighborhoodService>();
             serviceCollection.AddScoped<IDonationService, DonationService>();
             serviceCollection.AddScoped<IDonateService, DonateService>();
            serviceCollection.AddScoped<IPermissionService, PermissionService>();
        
            serviceCollection.AddRepositories();

        }
    }
}
