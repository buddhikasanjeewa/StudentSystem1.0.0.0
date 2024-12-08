using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Models;

public partial class SoftoneStudentSystemContext : DbContext
{
    public string  ConnectionString { get; set; }
    public SoftoneStudentSystemContext()
    {
    }

	

	public SoftoneStudentSystemContext(DbContextOptions<SoftoneStudentSystemContext> options)
        : base(options)
    {
    }



	public virtual DbSet<StudentPersonal> StudentPersonals { get; set; }


	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//       => optionsBuilder.UseSqlServer("Name=ConnectionStrings:StuConstr");
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(this.ConnectionString);
	}

	//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
	//   => optionsBuilder.UseSqlServer("Server=LAPTOP-2OTFH16P\\SQLEXPRESS;Database=SoftoneStudentSystem;User Id=sa;password=123;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

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
