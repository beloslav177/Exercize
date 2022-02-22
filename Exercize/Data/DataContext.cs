using Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercize.Data
{
    public class DataContext : DbContext
    {
        private const string connectionString = @"Host=localhost;Username=postgres;Password=Ksodasr254125@;Database=todolist";

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ExercizeModel> Exercizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExercizeModel>().HasData(
                new ExercizeModel { Id = 1, Title = "Bitbucket pipeline", Description = "Bitbucket pipeline should automatically create the MobilePulseClientSecrets AWS secret", IsFinished = false },
                new ExercizeModel { Id = 2, Title = "PagerDuty", Description = "Dev", IsFinished = false },
                new ExercizeModel { Id = 3, Title = "PagerDuty pipeline", Description = "Test", IsFinished = false },
                new ExercizeModel { Id = 4, Title = "Configuration", Description = "Conmplete configuration for Services", IsFinished = false }
            );
        }
    }
}
