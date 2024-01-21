using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using AzureTestCaseAssociator.Core.Gateway;
using AzureTestCaseAssociator.Core.Contract;
using AzureTestCaseAssociator.Core.Manager;
using AzureTestCaseAssociator.Core.Facade;

namespace AzureTestCaseAssociator.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
           services.AddHttpClient<IAzureServiceGateway, AzureServiceGateway>(a => a.BaseAddress = new System.Uri("https://dev.azure.com/"));
           services.AddTransient<IAzureServiceManager, AzureServiceManager>();
           services.AddTransient<IAzureServiceFacade, AzureServiceFacade>();
           return services;
        }
    }
}