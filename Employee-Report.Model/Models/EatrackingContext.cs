using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Employee_Report.Model.Models;

public partial class EatrackingContext : DbContext
{
    public EatrackingContext()
    {
    }

    public EatrackingContext(DbContextOptions<EatrackingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeePoc> EmployeePocs { get; set; }

    public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }

    public virtual DbSet<Poc> Pocs { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MLI-LAP-081\\MSSQLSERVER01;Database=EATracking;Integrated Security=True;TrustServerCertificate=True    ;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeePoc>(entity =>
        {
            entity.ToTable("EmployeePOC");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EmpId).HasMaxLength(10);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Pocid).HasColumnName("POCId");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Poc).WithMany(p => p.EmployeePocs)
                .HasForeignKey(d => d.Pocid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeePOC_POC");
        });

        modelBuilder.Entity<EmployeeProject>(entity =>
        {
            entity.ToTable("EmployeeProject");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Achivements)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmpId).HasMaxLength(10);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ReportingTo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Project).WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeProject_Project");

            entity.HasOne(d => d.Role).WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeProject_Role");
        });

        modelBuilder.Entity<Poc>(entity =>
        {
            entity.ToTable("POC");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleName)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
