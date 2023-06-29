using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Models;
using Reservation.Infrastructure.Abstracts;

namespace Reservation.Infrastructure.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Asset> Assets { get; set; }
        public DbSet<ReservationItem> ReservationItems { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(DataContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
