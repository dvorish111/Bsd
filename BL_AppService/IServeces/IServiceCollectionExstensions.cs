using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL_AppService.Profiles;
using BL_AppService.Services;
using DAL;
using DAL.IRepositorys;
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
            serviceCollection.AddScoped<ImageService, ImageService>();
/*           serviceCollection.AddScoped<IPermissionService, PermissionService>();
*/            serviceCollection.AddAutoMapper(config => config.AddProfile<CampaignProfile>());
            serviceCollection.AddAutoMapper(config => config.AddProfile<DonorProfile>());
            serviceCollection.AddAutoMapper(config => config.AddProfile<DonateProfile>());
            serviceCollection.AddAutoMapper(config => config.AddProfile<PermissionProfile>());
            serviceCollection.AddAutoMapper(config => config.AddProfile<NeighborhoodProfile>());
            serviceCollection.AddAutoMapper(config => config.AddProfile<DonationProfile>());
            serviceCollection.AddAutoMapper(config => config.AddProfile<PermissionProfile>());
            serviceCollection.AddAutoMapper(config => config.AddProfile<ImageProfile>());

            serviceCollection.AddRepositories();

        }
    }
}
