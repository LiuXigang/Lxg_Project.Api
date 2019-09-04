using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project.API.Application.Commands;
using Project.API.Application.Queries;
using Project.API.Application.Service;
using Project.Infrastructure;

namespace Project.API
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
            var migrationsAssembly = typeof(Startup).Assembly.GetName().Name;
            var conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProjectContext>(options =>
                {
                    options.UseMySQL(conn, sql => sql.MigrationsAssembly(migrationsAssembly));
                }
            );
            services.AddMediatR(MyConfigure.HandlerAssemblyMarkerTypes());

            services.AddScoped<IRecommendService, RecommendService>();
            services.AddScoped<IProjectQueries, ProjectQueries>(sp => { return new ProjectQueries(conn); });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
