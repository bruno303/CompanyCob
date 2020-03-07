using AutoMapper;
using CompanyCob.Api.ViewModel;
using CompanyCob.Domain.Model;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyCob.Api.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMapper>(serviceProvider => {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Carteira, CarteiraEditViewModel>();
                    cfg.CreateMap<CarteiraEditViewModel, Carteira>();
                    cfg.CreateMap<Devedor, DevedorEditViewModel>();
                    cfg.CreateMap<DevedorEditViewModel, Devedor>();
                });
                return config.CreateMapper();
            });
        }
    }
}