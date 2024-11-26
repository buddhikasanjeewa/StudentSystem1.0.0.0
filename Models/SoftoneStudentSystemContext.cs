using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SoftOneStudentSystemWebApi.Models;

public partial class SoftoneStudentSystemContext : DbContext
{
    public SoftoneStudentSystemContext()
    {
    }



    public SoftoneStudentSystemContext(DbContextOptions<SoftoneStudentSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentPersonal> StudentPersonals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:StuConstr");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentPersonal>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.StudentCode });

            entity.ToTable("Student_Personal");

            entity.Property(e => e.StudentCode)
                .HasMaxLength(10)
                .IsUnicode(false);
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
