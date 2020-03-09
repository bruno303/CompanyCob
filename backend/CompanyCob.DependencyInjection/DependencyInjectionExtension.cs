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
            // O DBContext está transient para que seja possível que seja injetado em Startup.Configure,
            // onde é feita a atualização do banco de dados automaticamente.
            // Em uma aplicação que irá para produção, as migrations devem ser aplicadas manualmente e o
            // Lifetime default (Scoped) do DBContext pode ser usado.
            serviceCollection.AddDbContext<CobDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("CompanyCob"));
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