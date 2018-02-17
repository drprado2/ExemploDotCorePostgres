using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestePostgres.Data;

namespace TestePostgres
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Aqui você adiciona o uso do postgres
            services.AddEntityFrameworkNpgsql()
                // Esse MyDbContext é a classe de contexto que criamos
                .AddDbContext<MyDbContext>(
                    options => options.UseNpgsql(
                        // A connection string vai no appsettings.json
                        Configuration.GetConnectionString("MinhaBase")));

            // Fique atento com as depêndencias
            // Microsoft.EntityFrameworkCore.Tools.DotNet => Necessária para o migrations
            // Npgsql.EntityFrameworkCore.PostgreSQL => EF Core para o postgres
            // para usar o migrations pelo CLI que seria o caso de um software de pipeline
            // eu consegui fazer seguindo os passos desse link: 
            //  https://docs.microsoft.com/pt-br/ef/core/miscellaneous/cli/dotnet
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMvc();
        }
    }
}
