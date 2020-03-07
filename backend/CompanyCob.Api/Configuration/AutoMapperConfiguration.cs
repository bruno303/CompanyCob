using AutoMapper;
using CompanyCob.Api.ViewModel;
using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Interface;
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
                    cfg.CreateMap<Divida, DividaEditViewModel>();
                    cfg.CreateMap<DividaEditViewModel, Divida>();
                });
                return config.CreateMapper();
            });
        }
    }
}