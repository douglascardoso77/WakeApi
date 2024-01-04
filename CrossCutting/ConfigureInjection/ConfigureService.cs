using Domain.Interfaces.Services.Product;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace CrossCutting.ConfigureInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenceInjection(IServiceCollection serviceCollection){
            serviceCollection.AddTransient<IProductService, ProductService>();
        }
    }
}