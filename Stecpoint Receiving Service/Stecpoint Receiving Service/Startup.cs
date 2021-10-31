using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Stecpoint_Receiving_Service.API.Filters;
using Stecpoint_Receiving_Service.Application.Services;
using Stecpoint_Receiving_Service.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using Stecpoint_Receiving_Service.Domain.Repositories;
using Stecpoint_Receiving_Service.Infrastructure.Repositories;
using Stecpoint_Receiving_Service.StartupExtensions;
using Stecpoint_Receiving_Service.Application.Mapping;
using System.Threading.Tasks;
using System;
using FluentValidation.AspNetCore;
using Stecpoint_Receiving_Service.Application.Validation;

namespace Stecpoint_Receiving_Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(o =>
            {
                o.Filters.Add<ExceptionHandlerFilter>();
            })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserSearchValidator>());

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .CreateLogger();

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            // services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserService, UserService>();

            // repos
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();

            services.AddAutoMapper(typeof(ApplicationMapperProfile));
            services.AddSwaggerGen();

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });

            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.AddMassTransitConsumers();
            });

            SetupDbContexts(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            Task.Run(async () => await SetupDbSchemas(app)).Wait();
        }

        protected virtual void SetupDbContexts(IServiceCollection services)
        {
            string sqlConnectionString = Configuration.GetConnectionString("default");
            services.AddDbContext<Context>(options => options.UseSqlServer(sqlConnectionString));
        }

        private async Task SetupDbSchemas(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            await SetupDbSchema(scope.ServiceProvider.GetRequiredService<Context>());
        }

        protected virtual async Task SetupDbSchema(DbContext dbContext)
        {
            dbContext.Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
            await dbContext.Database.MigrateAsync();
            await dbContext.Database.EnsureCreatedAsync();
        }
    }
}
