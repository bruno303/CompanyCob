using CompanyCob.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyCob.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static void AddRepositories(this ServiceCollection serviceCollection) {
            serviceCollection.AddSingleton<ContratoRepository>();
            serviceCollection.AddSingleton<ParcelaRepository>();
            serviceCollection.AddSingleton<DevedorRepository>();
            serviceCollection.AddSingleton<CarteiraRepository>();
        }
    }
}