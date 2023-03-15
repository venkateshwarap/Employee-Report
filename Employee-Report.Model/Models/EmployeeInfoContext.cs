using System;
using System.Collections.Generic;
using Employee_Report.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.DataModel.Models
{

    public partial class EmployeeInfoContext : DbContext
    {
        public EmployeeInfoContext()
        {
        }

        public EmployeeInfoContext(DbContextOptions<EmployeeInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Certification> Certifications { get; set; }

        public virtual DbSet<PowerHouse> PowerHouse { get; set; }

        public virtual DbSet<Employees> Employees { get; set; }

        public virtual DbSet<EmployeeLearning> EmployeeLearnings { get; set; }

        public virtual DbSet<EmployeePoc> EmployeePocs { get; set; }

        public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }

        public virtual DbSet<EmployeeSkills> EmployeeSkills { get; set; }

        public virtual DbSet<EmployeeTraining> EmployeeTrainings { get; set; }

        public virtual DbSet<Interview> Interviews { get; set; }

        public virtual DbSet<Learning> Learnings { get; set; }

        public virtual DbSet<Poc> Pocs { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<Training> Training { get; set; }
        public DbSet<IntellectualProperty> IntellectualProperty { get; set; }

     //   public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=MLI00748;Database=EmployeeInfo;Integrated Security=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certification>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Eacid).HasColumnName("EACId");
                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
                entity.Property(e => e.ValidFrom).HasColumnType("date");
                entity.Property(e => e.ValidTill).HasColumnType("date");
            });

            modelBuilder.Entity<PowerHouse>(entity =>
            {

                entity.HasKey(e => e.Id).HasName("PK__PowerHouse__3214EC2703360EFB");

                entity.ToTable("PowerHouse");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.EndDate).HasColumnType("date");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ReportingTo)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                //entity.Property(e => e.RoleId).HasMaxLength(50);
                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasMaxLength(10);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.JoiningDate).HasColumnType("date");
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastWorkingDate).HasColumnType("date");
            });

            modelBuilder.Entity<EmployeeLearning>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC2703360EFB");

                entity.ToTable("EmployeeLearning");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.BenchId).HasColumnName("BenchID");
                entity.Property(e => e.EmpId).HasMaxLength(10);
                entity.Property(e => e.EndDate).HasColumnType("date");
                entity.Property(e => e.LearningId).HasColumnName("LearningID");
                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<EmployeePoc>(entity =>
            {
                entity.ToTable("EmployeePOC");

                entity.Property(e => e.EmpId).HasMaxLength(10);
                entity.Property(e => e.EndDate).HasColumnType("date");
                entity.Property(e => e.Pocid).HasColumnName("POCId");
                entity.Property(e => e.ReportingTo).HasMaxLength(25);
                entity.Property(e => e.StartDate).HasColumnType("date");

                //entity.HasOne(d => d.Emp).WithMany(p => p.EmployeePocs)
                //    .HasForeignKey(d => d.EmpId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_EmployeePOC_Employee");

                //entity.HasOne(d => d.Poc).WithMany(p => p.EmployeePocs)
                //    .HasForeignKey(d => d.Pocid)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_EmployeePOC_POC");

                //entity.HasOne(d => d.Role).WithMany(p => p.EmployeePocs)
                //    .HasForeignKey(d => d.RoleId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_EmployeePOC_Role");
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.ToTable("EmployeeProject");

                entity.Property(e => e.Achivements)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.EmpId).HasMaxLength(10);
                entity.Property(e => e.EndDate).HasColumnType("date");
                entity.Property(e => e.ReportingTo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.StartDate).HasColumnType("date");

                //entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeProjects)
                //    .HasForeignKey(d => d.EmpId)
                //    .HasConstraintName("FK_EmployeeProject_Employee");

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
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.CreatedOn).HasColumnType("date");
                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .HasColumnName("EmpID");
                entity.Property(e => e.EndDate).HasMaxLength(50);
                entity.Property(e => e.ModifiedBy).HasMaxLength(50);
                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("date")
                    .HasColumnName("modifiedOn");
                entity.Property(e => e.SkillId).HasColumnName("SkillID");
                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Skill).WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeSkills_Skills");
            });

            modelBuilder.Entity<EmployeeTraining>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC27B6EE227F");

                entity.ToTable("EmployeeTraining");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.BenchId).HasColumnName("BenchID");
                entity.Property(e => e.EmpId)
                    .HasMaxLength(10)
                    .HasColumnName("EmpID");
                entity.Property(e => e.EndDate).HasColumnType("date");
                entity.Property(e => e.StartDate).HasColumnType("date");
                entity.Property(e => e.TraningId).HasColumnName("TraningID");
            });

            modelBuilder.Entity<Interview>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.ReportingTo).HasMaxLength(100);
                entity.Property(e => e.Role).HasMaxLength(50);
                entity.Property(e => e.Skill).HasMaxLength(100);
                entity.Property(e => e.Status).HasMaxLength(10);
            });

            modelBuilder.Entity<Learning>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Learning__3214EC27262E3C76");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.EndDate).HasColumnType("date");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Path)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.SkillId).HasColumnName("SkillID");
                entity.Property(e => e.StartDate).HasColumnType("date");
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

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_EmpSkills");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Training__3214EC279848A453");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.EndDate).HasColumnType("date");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.StartDate).HasColumnType("date");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
