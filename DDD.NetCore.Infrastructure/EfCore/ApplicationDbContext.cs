using DDD.NetCore.Domain.Authorization;
using DDD.NetCore.Domain.Customers;
using DDD.NetCore.Domain.Goods;
using DDD.NetCore.Domain.Orders;
using DDD.NetCore.Domain.ShoppingCarts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DDD.NetCore.Infrastructure.EfCore
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //private readonly DbConnection _dbConnection;
        //public ApplicationDbContext(DbConnection dbConnection)
        //{
        //    _dbConnection = dbConnection;
        //}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<GoodsCategory> GoodsCategories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartLine> ShoppingCartLines { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<SaleOrder> SaleOrders { get; set; }

        public DbSet<SaleOrderLine> SaleOrderLines { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_dbConnection);            
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Customer>().HasOne(c => c.ApplicationUser);
            builder.Entity<Customer>()
                .HasOne(c => c.ShoppingCart)
                .WithOne(sc => sc.Customer)
                .HasForeignKey<ShoppingCart>(c => c.CustomerId);

            builder.Entity<Customer>().HasMany(c => c.ShippingAddresses);
            builder.Entity<ShoppingCart>().HasMany(sc => sc.ShoppingCartLines).WithOne(cl => cl.ShoppingCart);
            builder.Entity<ShoppingCartLine>().HasOne(scl => scl.Goods);

            builder.Entity<Goods>().HasOne(g => g.GoodsCategory).WithMany(gc => gc.GoodsList);

            builder.Entity<SaleOrder>().HasMany(so => so.SaleOrderLines).WithOne(sol => sol.SaleOrder);
            builder.Entity<SaleOrder>().HasOne(so => so.Customer);
            builder.Entity<SaleOrder>().HasOne(so => so.DeliveryAddress);

            builder.Entity<SaleOrderLine>().HasOne(sol => sol.Goods);
        }
    }
}