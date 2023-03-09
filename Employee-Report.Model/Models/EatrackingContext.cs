﻿using System;
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
    public virtual DbSet<Skills> Skills { get; set; }
    public virtual DbSet<Interview> Interviews { get; set; }
    public virtual DbSet<EmployeeLearning> EmployeeLearnings { get; set; }
    public virtual DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
    public virtual DbSet<EmployeeSkills> EmployeeSkills { get; set; }
    public virtual DbSet<EACouncilEntryExit> EACouncilEntryExit { get; set; }
    public virtual DbSet<Certifications> Certifications { get; set; }
    public virtual DbSet<Learning> Learnings { get; set; }
    public virtual DbSet<Training> Trainings { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=MLI00741\\RAJEEV_SQLDEV;Database=EATracking;Integrated Security=True;TrustServerCertificate=True;User Id=sa;Password=Raj@727_eev.MLI;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeePoc>(entity =>
        {
            entity.ToTable("EmployeePOC");

           // entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EmpId).HasMaxLength(10);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Pocid).HasColumnName("POCId");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            //entity.HasOne(d => d.Poc).WithMany(p => p.EmployeePocs)
            //    .HasForeignKey(d => d.Pocid)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_EmployeePOC_POC");
        });

        modelBuilder.Entity<EmployeeProject>(entity =>
        {
            entity.ToTable("EmployeeProject");

          //  entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Achivements)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmpId).HasMaxLength(10);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ReportingTo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            //entity.HasOne(d => d.Project).WithMany(p => p.EmployeeProjects)
            //    .HasForeignKey(d => d.ProjectId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_EmployeeProject_Project");

            //entity.HasOne(d => d.Role).WithMany(p => p.EmployeeProjects)
            //    .HasForeignKey(d => d.RoleId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_EmployeeProject_Role");
        });

        modelBuilder.Entity<EmployeeSkills>(entity =>
        {
            entity.ToTable("EmployeeSkills");
            entity.Property(e => e.ID);
            entity.Property(e => e.EmpID).HasMaxLength(10);
            entity.Property(e => e.SkillID);
            entity.Property(e => e.StartDate);
            entity.Property(e => e.EndDate);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedOn);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.ModifiedOn);
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

           // entity.Property(e => e.Id).ValueGeneratedNever();
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

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.ReportingTo).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(10);
        });

        modelBuilder.Entity<Skills>(entity =>
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.SkillName).HasColumnName("SkillName");
        });
        modelBuilder.Entity<EACouncilEntryExit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EACouncilEntryExit__3214EC27CD2108DA");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.EmpId).HasColumnName("EmpId");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Role).HasColumnName("Role");
            entity.Property(e => e.ReportingTo).HasColumnName("ReportingTo");
        });

        modelBuilder.Entity<Certifications>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Certifications__3214EC27CD2108DA");
            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.EmpId).HasColumnName("EmpId");
            entity.Property(e => e.ValidFrom).HasColumnType("datetime");
            entity.Property(e => e.ValidTill).HasColumnType("datetime");
            entity.Property(e => e.EACId).HasColumnName("EACId");
            entity.Property(e => e.Name).HasColumnName("Name");
        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
