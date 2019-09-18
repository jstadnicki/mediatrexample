using System.Reflection;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Tangled.Database.Database;
using Tangled.Logic.Validators;

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

            services.AddDbContext<EFContext>(
                o =>
                {
                    o.UseInMemoryDatabase("tangled");
                });
            this.mapperConfiguration = new MapperConfiguration(o => o.AddProfile<AutomapperProfile>());
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                   .AsImplementedInterfaces();
            builder.RegisterType<CreateUserDtoValidator>();
            builder.RegisterType<UpdateUserDtoValidator>();
            builder.RegisterType<AutomapperProfile>();
            builder
                .Register(ctx => this.mapperConfiguration.CreateMapper())
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
