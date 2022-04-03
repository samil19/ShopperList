using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace shopperlist_backend.Models
{
    public partial class shopperlistContext : DbContext
    {
        public shopperlistContext()
        {
        }

        public shopperlistContext(DbContextOptions<shopperlistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<BrandCategory> BrandCategories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<RawProduct> RawProducts { get; set; }
        public virtual DbSet<RawProductBrand> RawProductBrands { get; set; }
        public virtual DbSet<RawProductCategory> RawProductCategories { get; set; }
        public virtual DbSet<Scale> Scales { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShopList> ShopLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=shopperlist;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateInsert).HasColumnType("datetime");

                entity.Property(e => e.Details).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BrandCategory>(entity =>
            {
                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.BrandCategories)
                    .HasForeignKey(d => d.IdBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrandCategories_Brands");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.BrandCategories)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrandCategories_Categories");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdScaleNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.IdScale)
                    .HasConstraintName("FK_Categories_Scale");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Entity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NewValue).IsUnicode(false);

                entity.Property(e => e.OldValue).IsUnicode(false);

                entity.Property(e => e.Reason).IsUnicode(false);
            });

            modelBuilder.Entity<RawProduct>(entity =>
            {
                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.DateInsert).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RawProductBrand>(entity =>
            {
                entity.ToTable("RawProductBrand");

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.RawProductBrands)
                    .HasForeignKey(d => d.IdBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RawProductBrand_Brands");

                entity.HasOne(d => d.IdRawProductNavigation)
                    .WithMany(p => p.RawProductBrands)
                    .HasForeignKey(d => d.IdRawProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RawProductBrand_RawProducts");
            });

            modelBuilder.Entity<RawProductCategory>(entity =>
            {
                entity.ToTable("RawProductCategory");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.RawProductCategories)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryProduct_Categories");

                entity.HasOne(d => d.IdRawProductNavigation)
                    .WithMany(p => p.RawProductCategories)
                    .HasForeignKey(d => d.IdRawProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryProduct_Products");
            });

            modelBuilder.Entity<Scale>(entity =>
            {
                entity.ToTable("Scale");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("Shop");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Supermarket)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShopList>(entity =>
            {
                entity.ToTable("ShopList");

                entity.HasOne(d => d.IdRawProductBrandNavigation)
                    .WithMany(p => p.ShopLists)
                    .HasForeignKey(d => d.IdRawProductBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopList_RawProductBrand");

                entity.HasOne(d => d.IdShopNavigation)
                    .WithMany(p => p.ShopLists)
                    .HasForeignKey(d => d.IdShop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShopList_Shop");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
