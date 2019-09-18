using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Tangled.Api
{
    public class Startup
    {
        private MapperConfiguration mapperConfiguration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Info());
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {

            var modules =
                Assembly.GetExecutingAssembly()
                    .GetReferencedAssemblies()
                    .Where(a => a.Name.StartsWith("Tangled"));

            var assemblies = modules.Select(m => Assembly.Load(m))
                .ToList();


            foreach (var a in assemblies)
            {
                builder.RegisterAssemblyModules(a);
            }

            this.mapperConfiguration = new MapperConfiguration(o => o.AddMaps(assemblies));

            builder.Register(ctx => this.mapperConfiguration.CreateMapper())
                   .As<IMapper>()
                   .InstancePerLifetimeScope();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 api");
            });
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
