using KursachTolkachev.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursachTolkachev.Data
{


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<AccessRight> AccessRights { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassType> ClassTypes { get; set; }
        public DbSet<ClassChar> ClassChars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //   .Entity<Provider>()
            //   .HasMany(c => c.GoodsForSale)
            //   .WithMany(s => s.Providers)
            //   .UsingEntity<GoodForSale_Provider>(
            //      j => j
            //       .HasOne(pt => pt.GoodForSale)
            //       .WithMany(t => t.GoodsForSale_Providers)
            //       .HasForeignKey(pt => pt.GoodForSaleId),
            //   j => j
            //       .HasOne(pt => pt.Provider)
            //       .WithMany(p => p.GoodsForSale_Providers)
            //       .HasForeignKey(pt => pt.ProviderId),
            //   j =>
            //   {   
            //       j.HasKey(t => new { t.ProviderId, t.GoodForSaleId, t.Id });
            //       j.ToTable("goodsforsale_providers");
            //   });
        }
    }
}
