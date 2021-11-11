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
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassType> ClassTypes { get; set; }
        public DbSet<ClassChar> ClassChars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Class>()
                .HasMany(c => c.Subjects)
                .WithMany(s => s.Classes)
                .UsingEntity<Schedule>(
                   j => j
                    .HasOne(pt => pt.Subject)
                    .WithMany(t => t.Schedules)
                    .HasForeignKey(pt => pt.SubjectId),
                j => j
                    .HasOne(pt => pt.Class)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(pt => pt.ClassId),
                j =>
                {
                    j.HasKey(t => new { t.ClassId, t.SubjectId, t.Id, t.Date });
                    j.ToTable("schedules");
                });
        }
    }
}
