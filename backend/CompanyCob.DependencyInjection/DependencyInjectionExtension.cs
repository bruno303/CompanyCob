using CompanyCob.Repository;
using CompanyCob.Domain.Model.Interface;
using Microsoft.Extensions.DependencyInjection;
using CompanyCob.Repository.Data;

namespace CompanyCob.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static void AddRepositories(this IServiceCollection serviceCollection) {
            serviceCollection.AddTransient<CobDbContext>();
            serviceCollection.AddTransient<ICarteiraRepository, CarteiraRepository>();
            serviceCollection.AddTransient<IDevedorRepository, DevedorRepository>();
            serviceCollection.AddTransient<IDividaRepository, DividaRepository>();
        }
    }
}