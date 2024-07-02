using DICourse.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DICourse.ViewModels
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ISMSService, ParsGreenService>();

            services.Configure<KavrnegarViewModel>(configuration.GetSection("KavenegarAPI"));
            services.Configure<PasargadBankViewModel>(configuration.GetSection("PasargadBank"));
        }
    }
}
