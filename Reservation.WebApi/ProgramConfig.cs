using Reservation.Infrastructure.Abstracts;
using Reservation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
        }
    }
}
