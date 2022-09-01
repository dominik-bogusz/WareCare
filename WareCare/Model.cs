using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareCare
{
    public class WareCareContext : DbContext
    {
        /// <summary>
        /// Class <c>Products</c> maps Products table to class <c>Product</c> fields
        /// </summary>

        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Class <c>Brand</c> maps Brands table to class <c>Brand</c> fields
        /// </summary>

        public DbSet<Brand> Brands { get; set; }


        /// <summary>
        /// Class <c>AvailableProducts</c> maps AvailableProducts table to class <c>AvailableProduct</c> fields
        /// </summary>
        public DbSet<AvailableProduct> AvailableProducts { get; set; }

        /// <summary>
        /// Get mysql db connection string
        /// </summary>
        public string ConnectionString { get; }


        /// <summary>
        /// Configure <c>WareCareContext</c> connection string
        /// </summary>
        public WareCareContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }
    }
}
