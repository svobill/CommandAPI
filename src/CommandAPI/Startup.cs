using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CommandAPI.Data;
using CommandAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace CommandAPI
{
    public class Startup
    {
		public IConfiguration Configuration { get; }
		
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		
        // This method gets called by the runtime.  Use this method to add (register) services to the container.
        // For more information about how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			// Adding DbContext to connect to SQL Server Database
			services.AddDbContext<CommandContext>(options => options.UseSqlServer
				(Configuration.GetConnectionString("SqlServerConnection")));
			
			services.AddControllers().AddNewtonSoftJson(s => 
			{
				s.SerializerSettings.ContractResolver = 
					new CamelCasePropertyNamesContractResolver();
			};
			
			// Adding AutoMapper for DTOs
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
				
			// Associate a class with an interface
			services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();
        }

        // This method gets called by the runtime.  Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
				endpoints.MapControllers();
				
/*                 endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                }); */
            });
        }
    }
}
