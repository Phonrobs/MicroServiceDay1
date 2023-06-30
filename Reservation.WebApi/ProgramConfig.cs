using Reservation.Infrastructure.Abstracts;
using Reservation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MediatR;
using ShareLib.Behaviors;
using FluentValidation;
using Serilog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

namespace Reservation.WebApi
{
    public static class ProgramConfig
    {
        public static void AddWebApi(this WebApplicationBuilder builder)
        {
            // Add EntityFramework core database
            builder.Services.AddDbContext<IDataContext, DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

                if (builder.Environment.IsDevelopment())
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                    options.ConfigureWarnings(warningOptions =>
                    {
                        warningOptions.Log(new EventId[] {
                        CoreEventId.FirstWithoutOrderByAndFilterWarning,
                        CoreEventId.RowLimitingOperationWithoutOrderByWarning
                    });
                    });
                }
            });

            // add Mediatr classes
            var assembly = typeof(Reservation.Application.Features.Assets.CreateAssetCommand).Assembly;

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assembly);
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
            });

            // add FluentValidation classes
            builder.Services.AddValidatorsFromAssembly(assembly);

            // Add Serilog
            var logConf = new LoggerConfiguration();

            logConf.WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Verbose);

            if (!builder.Environment.IsDevelopment())
            {
                logConf.WriteTo.EventLog("Application", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error);
            }

            Log.Logger = logConf.CreateLogger();

            builder.Host.UseSerilog();

            // Add Web API authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration, "AzureAd");
        }
    }
}
