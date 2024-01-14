using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using AzureTestCaseAssociator.Core.Gateway;
using AzureTestCaseAssociator.Core.Contract;
using AzureTestCaseAssociator.Core.Manager;
using AzureTestCaseAssociator.Core.Facade;

namespace AzureTestCaseAssociator
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
           services.AddHttpClient<IAzureServiceGateway, AzureServiceGateway>();
           services.AddTransient<IAzureServiceManager, AzureServiceManager>();
           services.AddTransient<IAzureServiceFacade, AzureServiceFacade>();
           return services;
        }
    }
}