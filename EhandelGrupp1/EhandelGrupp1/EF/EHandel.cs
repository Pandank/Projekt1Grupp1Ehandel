namespace EhandelGrupp1.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EHandel : DbContext
    {
        public EHandel()
            : base(GetConString.GetCString())
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryToProduct> CategoryToProduct { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersByProduct> OrdersByProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.street)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.zip)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.CategoryToProduct)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.isAdmin)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Address)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Image>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrdersByProduct)
                .WithRequired(e => e.Orders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrdersByProduct>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CategoryToProduct)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Image)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrdersByProduct)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
