using System;
using System.Collections.Generic;
using Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace StudentSystemWebApi.DataAccessLayer.Models;

public partial class GitstudentContext : DbContext
{
    public GitstudentContext()
    {
    }

    public GitstudentContext(DbContextOptions<GitstudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseType> CourseTypes { get; set; }

    public virtual DbSet<StudentCourse> StudentCourses { get; set; }

    public virtual DbSet<StudentPersonal> StudentPersonals { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

        var conStr = EncryptionHelper.Decrypt(configuration.GetConnectionString("StuConStr"));
        optionsBuilder.UseSqlServer(conStr);
        //byte[] encrytedString = Encoding.ASCII.GetBytes(conntring);


        //optionsBuilder.UseSqlServer(configuration.GetConnectionString("StuConStr"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK_Log");

            entity.ToTable("ActivityLog");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Created_Date");
            entity.Property(e => e.CreatedUid).HasColumnName("CreatedUID");
            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("Modified_Date");
            entity.Property(e => e.ModifiedUid).HasColumnName("ModifiedUID");
            entity.Property(e => e.TableUid).HasColumnName("TableUID");

            entity.HasOne(d => d.CreatedU).WithMany(p => p.ActivityLogCreatedUs)
                .HasForeignKey(d => d.CreatedUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_Users");

            entity.HasOne(d => d.ModifiedU).WithMany(p => p.ActivityLogModifiedUs)
                .HasForeignKey(d => d.ModifiedUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Log_Users1");

            entity.HasOne(d => d.TableU).WithMany(p => p.ActivityLogs)
                .HasForeignKey(d => d.TableUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivityLog_ActivityLog");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.CourseCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Course_Code");
            entity.Property(e => e.CourseDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Course_Description");
            entity.Property(e => e.CourseTypeUid).HasColumnName("Course_Type_UID");

            entity.HasOne(d => d.CourseTypeU).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CourseTypeUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Course_Type");
        });

        modelBuilder.Entity<CourseType>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("Course_Type");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UId");
            entity.Property(e => e.CourseTypeDescription)
                .IsUnicode(false)
                .HasColumnName("Course_Type_Description");
            entity.Property(e => e.CourseTypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Course_Type_Id");
            entity.Property(e => e.CourseTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Course_Type_Name");
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("Student_Course");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.CourseUid).HasColumnName("Course_UID");
            entity.Property(e => e.StudentUid).HasColumnName("Student_UID");

            entity.HasOne(d => d.CourseU).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.CourseUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Course_Courses1");

            entity.HasOne(d => d.StudentU).WithMany(p => p.StudentCourses)
                .HasForeignKey(d => d.StudentUid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Course_Courses");
        });

        modelBuilder.Entity<StudentPersonal>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.ToTable("Student_Personal");

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nic)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NIC");
            entity.Property(e => e.StudentCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.TableDescription)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Table_Description");
            entity.Property(e => e.TableName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Table_Name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Uid);

            entity.Property(e => e.Uid)
                .ValueGeneratedNever()
                .HasColumnName("UID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
