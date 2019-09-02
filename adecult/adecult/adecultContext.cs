using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace adecult.adecult
{
    public partial class adecultContext : DbContext
    {
        public adecultContext()
        {
        }

        public adecultContext(DbContextOptions<adecultContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=password;database=adecult");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.ToTable("categorias", "adecult");

                entity.HasIndex(e => e.CatPadre)
                    .HasName("cat_padre");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CatPadre)
                    .HasColumnName("cat_padre")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.CatPadreNavigation)
                    .WithMany(p => p.InverseCatPadreNavigation)
                    .HasForeignKey(d => d.CatPadre)
                    .HasConstraintName("categorias_ibfk_1");
            });
        }
    }
}
