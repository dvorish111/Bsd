using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;
using DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.IRepositorys
{
    public static class IServiceCollectionExstensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICampaignRepository, CampaignRepository>();
            serviceCollection.AddScoped<IDonorRepository, DonorRepository>();
            serviceCollection.AddScoped<IPermissionRepository, PermissionRepository>();
            serviceCollection.AddScoped<INeighborhoodRepository, NeighborhoodRepository>();
            serviceCollection.AddScoped<IDonationRepository, DonationRepository>();
            serviceCollection.AddScoped<IDonateRepository, DonateRepository>();
            serviceCollection.AddScoped<IPermissionRepository, PermissionRepository>();
            serviceCollection.AddDbContext<CampainContext>();


        }
    }
}
