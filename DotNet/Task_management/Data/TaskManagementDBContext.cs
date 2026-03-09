using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Task_management.Models;

namespace Task_management.Data;

public partial class TaskManagementDBContext : DbContext
{
    public TaskManagementDBContext()
    {
    }

    public TaskManagementDBContext(DbContextOptions<TaskManagementDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<TaskList> TaskLists { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=task_management;user=root;password=MaddyR", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.43-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("progress");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.TaskStatus).HasColumnName("task_status");
        });

        modelBuilder.Entity<TaskList>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PRIMARY");

            entity.ToTable("task_list");

            entity.Property(e => e.TaskId).HasColumnName("task_id");
            entity.Property(e => e.AssignTo).HasColumnName("assign_to");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Descrip).HasMaxLength(60);
            entity.Property(e => e.DueDate).HasColumnName("Due_date");
            entity.Property(e => e.TaskName)
                .HasMaxLength(30)
                .HasColumnName("task_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("last_login");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
