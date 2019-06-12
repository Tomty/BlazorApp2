using BlazorApp2.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp2.Server.DataAccess
{
    public partial class BlazorCardContext : DbContext
    {
        public BlazorCardContext()
        {
        }

        public BlazorCardContext(DbContextOptions<BlazorCardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Flashcard> Flashcard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {   
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BlazorCard;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Difficulty)
                    .IsRequired()
                    .HasColumnName("difficulty")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Flashcard>(entity =>
            {
                entity.ToTable("flashcard");

                entity.Property(e => e.FlashcardId).HasColumnName("flashcard_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Content1)
                    .IsRequired()
                    .HasColumnName("content1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Content2)
                    .IsRequired()
                    .HasColumnName("content2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Flashcard)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__flashcard__categ__38996AB5");
            });
        }
        
    }
    
}
