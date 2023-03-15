using Logic.Implementation;
using Logic.Interface;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;

namespace API.ServiceExtensions
{
    public static class ServiceColectionsExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IDominoService, DominoService>();

            return services;
        }
    }
}
