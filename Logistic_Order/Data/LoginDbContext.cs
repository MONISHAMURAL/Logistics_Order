using Logistic_Order.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Data
{
    public class LoginDbContext: DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
        {
        }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Login_Buyer> LoginBuyers { get; set; }
        public DbSet<Login_Supplier> LoginSuppliers { get; set; }
        public DbSet<Login_Role> LoginRoles { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<PermissionRole> PermissionRoles { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Supplier> Order_Suppliers { get; set; }
        public DbSet<OrderCommodities> OrderCommodities { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Commodity_Category> Commodity_Categories { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShippingType> ShippingTypes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<TotalCost> TotalCosts { get; set; }

        public DbSet<Shipping_Route> Shipping_Routes { get; set; }
        public DbSet<Delivery> Delivered { get; set; }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public object Login_Buyers { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Commodities
            modelBuilder.Entity<Supplier>().HasMany(s => s.Commodity).WithOne(c => c.Supplier).HasForeignKey(c => c.Supplier_Id);
            //loginbuyer has login

            modelBuilder.Entity<Login_Buyer>().HasKey(lb => new { lb.Login_Id, lb.Buyer_Id });
            modelBuilder.Entity<Login>().HasMany(l => l.LoginBuyers) .WithOne(lb => lb.Login) .HasForeignKey(lb => lb.Login_Id);

            //loginsupplier has login
            modelBuilder.Entity<Login_Supplier>().HasKey(lb => new { lb.Login_Id, lb.Supplier_Id });
            modelBuilder.Entity<Login>() .HasMany(l => l.LoginSuppliers) .WithOne(ls => ls.Login).HasForeignKey(ls => ls.Login_Id);

            //loginrole has login
            modelBuilder.Entity<Login_Role>().HasKey(lr => new { lr.Login_Id, lr.Role_Id });
            modelBuilder.Entity<Login>() .HasMany(l => l.LoginRoles) .WithOne(lr => lr.Login).HasForeignKey(lr => lr.Login_Id);

            // feedback
            modelBuilder.Entity<Buyer>().HasOne(f => f.Feedback).WithOne(b => b.Buyers).HasForeignKey<Feedback>(f => f.Buyer_Id);


            //Permissions
            //Permission has many persmissionrole
            modelBuilder.Entity<PermissionRole>().HasOne(p => p.Permissions).WithMany(pr => pr.PermissionRoles).HasForeignKey(pr => pr.Permission_Id);
            //PermissionRole has many role
            modelBuilder.Entity<PermissionRole>().HasOne(pr => pr.Roles).WithMany(r => r.PermissionRoles).HasForeignKey(pr => pr.Role_Id);

            //Supplier has one warehouse with many suppliers
            modelBuilder.Entity<Supplier>() .HasOne(s => s.Warehouse).WithMany(s => s.Suppliers).HasForeignKey(s => s.Supplier_Id);

            //CommodityCategory
            modelBuilder.Entity<Commodity>().HasOne(c => c.Commodity_Category).WithOne(cc => cc.Commodity).HasForeignKey<Commodity_Category>(cc => cc.CommodityId);
            //Invoices
            modelBuilder.Entity<Order>().HasMany(i=>i.Invoices).WithOne(o => o.Order).HasForeignKey(i => i.Order_No);
            modelBuilder.Entity<Payment>().HasOne(i => i.Invoice).WithOne(p => p.Payment).HasForeignKey<Payment>(p => p.Payment_Id);
            modelBuilder.Entity <Shipping>().HasMany(i => i.Invoices).WithOne(s => s.Shipping).HasForeignKey(i => i.Shipping_Id);

            //Order
            modelBuilder.Entity<Buyer>().HasMany(o => o.Orders).WithOne(b => b.Buyer).HasForeignKey(o => o.Buyer_Id);

            //Order-Supplier:Order and supplier(M:M)
            modelBuilder.Entity<Order_Supplier>().HasKey(os => new { os.Order_No, os.Supplier_Id });
            modelBuilder.Entity<Order>().HasMany(os => os.OrderSuppliers).WithOne(o => o.Order).HasForeignKey(os => os.Order_No);
            modelBuilder.Entity<Supplier>().HasMany(os => os.Order_Suppliers).WithOne(s => s.Supplier).HasForeignKey(os => os.Supplier_Id);

            //Order-Commodity:Order and commodity(M:M)
            modelBuilder.Entity<OrderCommodities>().HasKey(oc => new { oc.Order_No, oc.CommodityId });
            modelBuilder.Entity<Order>().HasMany(oc => oc.OrderCommodities).WithOne(o => o.Order).HasForeignKey(oc => oc.Order_No);
            modelBuilder.Entity<Commodity>().HasMany(oc => oc.OrderCommodities).WithOne(c => c.Commodity).HasForeignKey(oc => oc.CommodityId);

            //Payment
            modelBuilder.Entity<TotalCost>().HasMany(p => p.Payment).WithOne(t => t.TotalCosts).HasForeignKey(t => t.Cost_Id);
            modelBuilder.Entity<Buyer>().HasMany(t => t.Payments).WithOne(o => o.Buyer).HasForeignKey(t => t.Buyer_Id);

            //Shipping
            modelBuilder.Entity<Buyer>().HasMany(s => s.Shippings).WithOne(o => o.Buyer).HasForeignKey(s => s.Buyer_Id);
            modelBuilder.Entity<Warehouse>().HasMany(s => s.Shippings).WithOne(o => o.WareHouses).HasForeignKey(s => s.Warehouse_Id);
            modelBuilder.Entity<Supplier>().HasMany(s => s.Shippings).WithOne(o => o.Supplier).HasForeignKey(s => s.Supplier_Id);

            //Shipping type
            modelBuilder.Entity<Shipping>().HasOne(st => st.ShippingTypes).WithMany(st => st.Shippings).HasForeignKey(st => st.Shipping_Id);

            //Stock
            modelBuilder.Entity<Warehouse>().HasMany(s => s.Stocks).WithOne(o => o.Warehouse).HasForeignKey(s => s.Warehouse_Id);
            modelBuilder.Entity<Commodity>().HasMany(s => s.Stocks).WithOne(o => o.Commodity).HasForeignKey(s => s.Commodity_Id);

            //Store
            modelBuilder.Entity<Supplier>().HasMany(s => s.Stores).WithOne(o => o.Supplier).HasForeignKey(s => s.Supplier_Id);
            modelBuilder.Entity<Warehouse>().HasMany(s => s.Stores).WithOne(o => o.Warehouse).HasForeignKey(s => s.Warehouse_Id);

            //Supplier
            modelBuilder.Entity<Warehouse>().HasMany(s => s.Suppliers).WithOne(o => o.Warehouse).HasForeignKey(s => s.Warehouse_Id);

            //Total cost
            modelBuilder.Entity<Shipping>().HasOne(t => t.TotalCosts).WithOne(s => s.shipping).HasForeignKey<TotalCost>(t => t.Shipping_Id);
            modelBuilder.Entity<Order>().HasOne(t => t.TotalCosts).WithOne(o => o.Order).HasForeignKey<TotalCost>(t => t.Order_No);
            

            //Tracking
            modelBuilder.Entity<Shipping_Route>().HasMany(t => t.Trackings).WithOne(s => s.Shipping_Routes).HasForeignKey(t => t.Route_Id);
            modelBuilder.Entity<Shipping>().HasMany(t => t.Trackings).WithOne(s => s.Shipping).HasForeignKey(t => t.Shipping_Id);

            //Delivery
            modelBuilder.Entity<Shipping>().HasOne(d => d.Delivery).WithOne(s => s.Shipping).HasForeignKey<Delivery>(d => d.Shipping_Id);









        }
    }
    
}
