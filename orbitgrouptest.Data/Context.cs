using Microsoft.EntityFrameworkCore;
using orbitgrouptest.Transversal.Entities;

namespace orbitgrouptest.Data
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // Directiva #warning
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=.\\App_Data\\sample.db;");
#pragma warning restore CS1030 // Directiva #warning
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("Username")
                    .HasMaxLength(20);
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FirstName")
                    .HasMaxLength(20);
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LastName")
                    .HasMaxLength(20);
                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasColumnName("Age");
                entity.Property(e => e.Career)
                    .IsRequired()
                    .HasColumnName("Career")
                    .HasMaxLength(20);
            });
        }
    }
}
