using Bogus;
using Microsoft.EntityFrameworkCore;
using Spg.Domain.Model;
using Spg.Domain.Model.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Infrastructure
{
    public class WebDbContext : DbContext
    {
        public WebDbContext() { }
        public WebDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Shipment> Shipments => Set<Shipment>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source=WebProject.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentConfiguration());  
        }

        public void Seed()
        {
            Randomizer.Seed = new Random(123423);

            List<Customer> customers = new Faker<Customer>().CustomInstantiator(s =>
            new Customer(s.Name.FirstName(), s.Name.LastName(), s.Internet.Email(), s.Internet.Password(), new Address(s.Address.StreetName(), s.Address.ZipCode(), s.Address.City(), s.Address.Country())))
            .Rules((s, f) =>
            {
                List<Shipment> shipments = new Faker<Shipment>().CustomInstantiator(s =>
                new Shipment(f, s.PickRandom<States>()))
                .Rules((s, c) =>
                {
                    List<Category> categories = new Faker<Category>().CustomInstantiator(s =>
                    new Category(s.Commerce.Categories(1).First()))
                    .Rules((s, d) =>
                    {
                        List<Product> products = new Faker<Product>().CustomInstantiator(s =>
                            new Product(s.Commerce.ProductName(), s.Commerce.ProductDescription(), s.Commerce.Price(), 25, 100, d))
                        .Generate(5);
                        d.AddProducts(products);
                        SaveChanges();
                    })
                    .Generate(5);
                    Categories.AddRange(categories);
                    SaveChanges();
                })
                .Generate(3);
                f.AddShipments(shipments);
                SaveChanges();
            })
            .Generate(5);
            Customers.AddRange(customers);
            SaveChanges();

        }
    }
}
