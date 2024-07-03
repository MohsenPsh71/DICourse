using DICourse.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            //services.AddTransient<ISMSService, ParsGreenService>();
            //services.AddTransient(typeof(ISMSService), typeof(ParsGreenService));

            // Just For Singleton
            //services.AddSingleton<ISMSService>(new ParsGreenService());

            //services.AddTransient<TransientService>();
            services.AddTransient(typeof(TransientService));
            services.AddScoped<ScopedService>();
            //services.AddSingleton<SingletonService>();
            services.AddSingleton(new SingletonService());

            //services.TryAddTransient<ISMSService, KavenegarService>();

            services.AddScoped<ParsGreenService>();
            services.AddScoped<KavenegarService>();

            services.AddScoped<Func<SelectSMSPanel, ISMSService>>(ServiceProvider => result => {
                switch (result) {
                    case SelectSMSPanel.Kavenegar:
                        return ServiceProvider.GetService<KavenegarService>();
                    case SelectSMSPanel.ParsGreen:
                        return ServiceProvider.GetService<ParsGreenService>();
                    default:
                        return ServiceProvider.GetService<KavenegarService>();
                }
            });

            services.Configure<KavrnegarViewModel>(configuration.GetSection("KavenegarAPI"));
            services.Configure<PasargadBankViewModel>(configuration.GetSection("PasargadBank"));
        }
    }
}
