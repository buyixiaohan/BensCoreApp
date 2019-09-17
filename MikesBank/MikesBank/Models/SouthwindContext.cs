using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MikesBank.Models
{
    public partial class SouthwindContext : DbContext
    {
        public SouthwindContext()
        {
        }

        public SouthwindContext(DbContextOptions<SouthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Logging> Logging { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=.;initial catalog=Southwind;user id=sa;password=sa;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PK_Departments");

                entity.Property(e => e.DepId).HasColumnName("Dep_ID");

                entity.Property(e => e.DepName)
                    .HasColumnName("Dep_Name")
                    .HasMaxLength(300);

                entity.Property(e => e.DepOffice)
                    .HasColumnName("Dep_Office")
                    .HasMaxLength(300);

                entity.Property(e => e.LocId).HasColumnName("Loc_ID");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("Update_Time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Loc)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.LocId)
                    .HasConstraintName("FK_Department_Location");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_Employees");

                entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

                entity.Property(e => e.DepId).HasColumnName("Dep_ID");

                entity.Property(e => e.EmpFirstName)
                    .HasColumnName("Emp_First_Name")
                    .HasMaxLength(300);

                entity.Property(e => e.EmpJobTitle)
                    .HasColumnName("Emp_Job_Title")
                    .HasMaxLength(300);

                entity.Property(e => e.EmpLastName)
                    .HasColumnName("Emp_Last_Name")
                    .HasMaxLength(300);

                entity.Property(e => e.EmpManagerId).HasColumnName("Emp_Manager_ID");

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("Update_Time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK_Employee_Department");

                entity.HasOne(d => d.EmpManager)
                    .WithMany(p => p.InverseEmpManager)
                    .HasForeignKey(d => d.EmpManagerId)
                    .HasConstraintName("FK_Employee_Employee");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocId)
                    .HasName("PK_Locations");

                entity.Property(e => e.LocId).HasColumnName("Loc_ID");

                entity.Property(e => e.LocAddress1)
                    .HasColumnName("Loc_Address1")
                    .HasMaxLength(300);

                entity.Property(e => e.LocAddress2)
                    .HasColumnName("Loc_Address2")
                    .HasMaxLength(300);

                entity.Property(e => e.LocCity)
                    .HasColumnName("Loc_City")
                    .HasMaxLength(300);

                entity.Property(e => e.LocCountry)
                    .HasColumnName("Loc_Country")
                    .HasMaxLength(300);

                entity.Property(e => e.LocName)
                    .HasColumnName("Loc_Name")
                    .HasMaxLength(300);

                entity.Property(e => e.LocZip)
                    .HasColumnName("Loc_Zip")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("Update_Time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Logging>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("Logging_PK");

                entity.Property(e => e.LogId).HasColumnName("Log_ID");

                entity.Property(e => e.LogMessage)
                    .HasColumnName("Log_Message")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.LogSeverity)
                    .IsRequired()
                    .HasColumnName("Log_Severity")
                    .HasMaxLength(50);

                entity.Property(e => e.LogSource)
                    .HasColumnName("Log_Source")
                    .HasMaxLength(1000);

                entity.Property(e => e.LogStackTrace)
                    .HasColumnName("Log_StackTrace")
                    .HasMaxLength(4000);

                entity.Property(e => e.UpdateBy)
                    .HasColumnName("Update_By")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("Update_Time")
                    .HasColumnType("datetime");
            });
        }
    }
}
