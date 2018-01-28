using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaInformatica.API.Dados;
using LojaInformatica.API.Filters;
using LojaInformatica.API.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LojaInformatica.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("LojaInformaticaContext");

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<LojaInformaticaContexto>(options =>
                {
                    options.UseNpgsql(connectionString);
                });
                
            services.UseLojaInformaticaDependencies();

            services.AddMvc(options => options.Filters.Add<UnitOfWorkFilter>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            loggerFactory.AddDebug(LogLevel.Information);
        }
    }
}
