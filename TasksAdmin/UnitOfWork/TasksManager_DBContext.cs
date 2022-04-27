using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TasksAdmin.Models;
using TasksAdmin.UnitOfWork;

#nullable disable

namespace TasksAdmin
{
    public partial class TasksManager_DBContext : DbContext , ITasksManager_DBContext
    {
        public TasksManager_DBContext()
        {
        }

        public TasksManager_DBContext(DbContextOptions<TasksManager_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TaskItem> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-P0KS4DF\\SQLEXPRESS;Initial Catalog=TasksManager_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
