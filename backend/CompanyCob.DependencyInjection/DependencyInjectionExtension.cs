using CompanyCob.Repository;
using CompanyCob.Domain.Model.Interface;
using Microsoft.Extensions.DependencyInjection;
using CompanyCob.Repository.Data;
using CompanyCob.Service;
using CompanyCob.Service.CalculoDividaImpl;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CompanyCob.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static void AddRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<CobDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("CompanyCob"), sqlServerOpts => sqlServerOpts.MigrationsAssembly("CompanyCob.Api"));
            }, contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);

            serviceCollection.AddTransient<ICarteiraRepository, CarteiraRepository>();
            serviceCollection.AddTransient<IDevedorRepository, DevedorRepository>();
            serviceCollection.AddTransient<IDividaRepository, DividaRepository>();
        }

        public static void AddCalculoService(this IServiceCollection serviceColletion)
        {
            serviceColletion.AddSingleton<ICalculoDivida, CalculoDividaJurosSimples>();
            serviceColletion.AddSingleton<ICalculoDivida, CalculoDividaJurosCompostos>();
            serviceColletion.AddSingleton<ICalculoDividaService, CalculoDividaService>();
        }
    }
}