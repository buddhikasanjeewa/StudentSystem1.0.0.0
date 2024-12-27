using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentSystemWebApi.DataAccessLayer.Models;

namespace StudentSystemWebApi;

public partial class SoftoneStudentSystemContext : DbContext
{
    public string ConnectionString { get; set; }
    public SoftoneStudentSystemContext()
    {
    }

    public SoftoneStudentSystemContext(DbContextOptions<SoftoneStudentSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseType> CourseTypes { get; set; }

    public virtual DbSet<StudentCourse> StudentCourses { get; set; }

    public virtual DbSet<StudentPersonal> StudentPersonals { get; set; }

    public virtual DbSet<User> Users { get; set; }

   
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(this.ConnectionString);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Course_Type_Description");
            entity.Property(e => e.CourseTypeId).HasColumnName("Course_Type_Id");
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

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
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
