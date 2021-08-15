using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clavax.DAL
{
    public partial class DrNaazdbContext : DbContext
    {
        public DrNaazdbContext()
        {
        }
        public DrNaazdbContext(DbContextOptions<DrNaazdbContext> options)
            : base(options)
        {
        }
        //public virtual DbSet<Appointments> Appointments { get; set; }
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        //public virtual DbSet<Attendances> Attendances { get; set; }
        //public virtual DbSet<Cities> Cities { get; set; }
        //public virtual DbSet<Doctors> Doctors { get; set; }
        //public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        //public virtual DbSet<Patients> Patients { get; set; }
        //public virtual DbSet<Specializations> Specializations { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"workstation id=DrNaazdb.mssql.somee.com;packet size=4096;user id=drnaaz_SQLLogin_1;pwd=5hr4to2kem;data source=DrNaazdb.mssql.somee.com;persist security info=False;initial catalog=DrNaazdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    modelBuilder.Entity<Appointments>(entity =>
        //    {
        //        entity.HasIndex(e => e.DoctorId)
        //            .HasName("IX_DoctorId");

        //        entity.HasIndex(e => e.PatientId)
        //            .HasName("IX_PatientId");

        //        entity.Property(e => e.Detail).IsRequired();

        //        entity.Property(e => e.StartDateTime).HasColumnType("datetime");

        //        entity.HasOne(d => d.Doctor)
        //            .WithMany(p => p.Appointments)
        //            .HasForeignKey(d => d.DoctorId)
        //            .HasConstraintName("FK_dbo.Appointments_dbo.Doctors_DoctorId");

        //        entity.HasOne(d => d.Patient)
        //            .WithMany(p => p.Appointments)
        //            .HasForeignKey(d => d.PatientId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_dbo.Appointments_dbo.Patients_PatientId");
        //    });

        //    modelBuilder.Entity<AspNetRoles>(entity =>
        //    {
        //        entity.HasIndex(e => e.Name)
        //            .HasName("RoleNameIndex")
        //            .IsUnique();

        //        entity.Property(e => e.Id)
        //            .HasMaxLength(128)
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(256);
        //    });

        //    modelBuilder.Entity<AspNetUserClaims>(entity =>
        //    {
        //        entity.HasIndex(e => e.UserId)
        //            .HasName("IX_UserId");

        //        entity.Property(e => e.UserId)
        //            .IsRequired()
        //            .HasMaxLength(128);

        //        entity.HasOne(d => d.User)
        //            .WithMany(p => p.AspNetUserClaims)
        //            .HasForeignKey(d => d.UserId)
        //            .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        //    });

        //    modelBuilder.Entity<AspNetUserLogins>(entity =>
        //    {
        //        entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId });

        //        entity.HasIndex(e => e.UserId)
        //            .HasName("IX_UserId");

        //        entity.Property(e => e.LoginProvider).HasMaxLength(128);

        //        entity.Property(e => e.ProviderKey).HasMaxLength(128);

        //        entity.Property(e => e.UserId).HasMaxLength(128);

        //        entity.HasOne(d => d.User)
        //            .WithMany(p => p.AspNetUserLogins)
        //            .HasForeignKey(d => d.UserId)
        //            .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        //    });

        //    modelBuilder.Entity<AspNetUserRoles>(entity =>
        //    {
        //        entity.HasKey(e => new { e.UserId, e.RoleId });

        //        entity.HasIndex(e => e.RoleId)
        //            .HasName("IX_RoleId");

        //        entity.HasIndex(e => e.UserId)
        //            .HasName("IX_UserId");

        //        entity.Property(e => e.UserId).HasMaxLength(128);

        //        entity.Property(e => e.RoleId).HasMaxLength(128);

        //        entity.HasOne(d => d.Role)
        //            .WithMany(p => p.AspNetUserRoles)
        //            .HasForeignKey(d => d.RoleId)
        //            .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

        //        entity.HasOne(d => d.User)
        //            .WithMany(p => p.AspNetUserRoles)
        //            .HasForeignKey(d => d.UserId)
        //            .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
        //    });

        //    modelBuilder.Entity<AspNetUsers>(entity =>
        //    {
        //        entity.HasIndex(e => e.UserName)
        //            .HasName("UserNameIndex")
        //            .IsUnique();

        //        entity.Property(e => e.Id)
        //            .HasMaxLength(128)
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.Email).HasMaxLength(256);

        //        entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

        //        entity.Property(e => e.UserName)
        //            .IsRequired()
        //            .HasMaxLength(256);
        //    });

        //    modelBuilder.Entity<Attendances>(entity =>
        //    {
        //        entity.HasIndex(e => e.PatientId)
        //            .HasName("IX_PatientId");

        //        entity.Property(e => e.ClinicRemarks).IsRequired();

        //        entity.Property(e => e.Date).HasColumnType("datetime");

        //        entity.Property(e => e.Diagnosis)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.Therapy).IsRequired();

        //        entity.HasOne(d => d.Patient)
        //            .WithMany(p => p.Attendances)
        //            .HasForeignKey(d => d.PatientId)
        //            .HasConstraintName("FK_dbo.Attendances_dbo.Patients_PatientId");
        //    });

        //    modelBuilder.Entity<Cities>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255);
        //    });

        //    modelBuilder.Entity<Doctors>(entity =>
        //    {
        //        entity.HasIndex(e => e.PhysicianId)
        //            .HasName("IX_PhysicianId");

        //        entity.HasIndex(e => e.SpecializationId)
        //            .HasName("IX_SpecializationId");

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.Phone).IsRequired();

        //        entity.Property(e => e.PhysicianId)
        //            .IsRequired()
        //            .HasMaxLength(128);

        //        entity.HasOne(d => d.Physician)
        //            .WithMany(p => p.Doctors)
        //            .HasForeignKey(d => d.PhysicianId)
        //            .HasConstraintName("FK_dbo.Doctors_dbo.AspNetUsers_PhysicianId");

        //        entity.HasOne(d => d.Specialization)
        //            .WithMany(p => p.Doctors)
        //            .HasForeignKey(d => d.SpecializationId)
        //            .HasConstraintName("FK_dbo.Doctors_dbo.Specializations_SpecializationId");
        //    });

        //    modelBuilder.Entity<MigrationHistory>(entity =>
        //    {
        //        entity.HasKey(e => new { e.MigrationId, e.ContextKey });

        //        entity.ToTable("__MigrationHistory");

        //        entity.Property(e => e.MigrationId).HasMaxLength(150);

        //        entity.Property(e => e.ContextKey).HasMaxLength(300);

        //        entity.Property(e => e.Model).IsRequired();

        //        entity.Property(e => e.ProductVersion)
        //            .IsRequired()
        //            .HasMaxLength(32);
        //    });

        //    modelBuilder.Entity<Patients>(entity =>
        //    {
        //        entity.HasIndex(e => e.CityId)
        //            .HasName("IX_CityId");

        //        entity.Property(e => e.Address)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.BirthDate).HasColumnType("datetime");

        //        entity.Property(e => e.DateTime).HasColumnType("datetime");

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.Phone)
        //            .IsRequired()
        //            .HasMaxLength(255);

        //        entity.Property(e => e.Token).IsRequired();

        //        entity.HasOne(d => d.City)
        //            .WithMany(p => p.Patients)
        //            .HasForeignKey(d => d.CityId)
        //            .HasConstraintName("FK_dbo.Patients_dbo.Cities_CityId");
        //    });

        //    modelBuilder.Entity<Specializations>(entity =>
        //    {
        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255);
        //    });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.ToTable("tblEmployee");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeDob)
                    .HasColumnName("Employee DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(20);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
