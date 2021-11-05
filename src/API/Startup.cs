using System.Reflection;
using Application.Behaviours;
using Application.Contracts.Domain.Config;
using Application.Features.Accounts;
using Application.Features.Booking;
using Application.Features.Reports;
using FluentValidation;
using Infrastructure;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace API
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
            services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("WWW-Authenticate").WithOrigins("http://localhost:8080").AllowCredentials()));

            // var configs = Configuration.GetSection("ConnectionStrings");
            // services.Configure<ConnectionStrings>(configs);
            // services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetSection("ConnectionStrings:DefaultConnectionString").Value));

            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(Configuration.GetSection("EntityFramework:databaseName").Value));

            services.AddScoped<DbContext, DataContext>();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddInfrastructureServices();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Covid Test API", Version = "v1" }));

            services.AddMediatR(typeof(RegisterUserCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateBookingCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateSpacesCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CancelBookingCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateSpacesCommandHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetReportQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetUsersQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetLocationQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetLocationsQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetBookingQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetBookingsQueryHandler).GetTypeInfo().Assembly);


            services.AddValidatorsFromAssemblyContaining(typeof(RegisterUserCommandHandler));
            services.AddValidatorsFromAssemblyContaining(typeof(CreateBookingCommandHandler));
            services.AddValidatorsFromAssemblyContaining(typeof(CancelBookingCommandHandler));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));

            //app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
