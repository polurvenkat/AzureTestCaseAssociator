using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using AzureTestCaseAssociator.Core.Gateway;
using AzureTestCaseAssociator.Core.Contract;

namespace AzureTestCaseAssociator
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
           services.AddHttpClient<IAzureServiceGateway, AzureServiceGateway>();
            
            return services;
        }
    }
}