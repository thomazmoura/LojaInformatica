using System;
using LojaInformatica.API.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace LojaInformatica.API.IoC
{
    public static class DependencyInjection
    {
        public static void UseLojaInformaticaDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LojaInformaticaContext");

            services.AddDbContextPool<ContextoLojaInformatica>(
                options => options.UseMySql(connectionString,
                    mysqlOptions =>
                    {
                        mysqlOptions.ServerVersion(new Version(5, 6), ServerType.MySql);
                    }
            ));

            services.AddScoped<IRepositorio, RepositorioMySql>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}