using LojaInformatica.API.Dados;
using Microsoft.Extensions.DependencyInjection;

namespace LojaInformatica.API.IoC
{
    public static class DependencyInjection
    {
        public static void UseLojaInformaticaDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRepositorio, RepositorioPostgresql>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}