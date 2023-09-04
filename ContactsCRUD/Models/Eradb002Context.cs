using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ContactsCRUD.Models;

public partial class Eradb002Context : DbContext
{
    public Eradb002Context()
    {
    }

    public Eradb002Context(DbContextOptions<Eradb002Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ERADB002;Encrypt=False;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__CONTACTS__99DE4258913AE872");

            entity.ToTable("CONTACTS");

            entity.Property(e => e.ContactId).HasColumnName("CONTACT_ID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FULLNAME");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PHONE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
