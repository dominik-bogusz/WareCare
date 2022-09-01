using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareCare
{
    public class Product
    {
        /// <summary>
        /// int <c>ID</c> refers to Product ID in mysql db which is also a primary key
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// nullable string <c>Name</c> refers to Product Name in mysql db
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// nullable string <c>Description</c> refers to Product Description in mysql db
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// int <c>BrandID</c> refers to Product BrandID in mysql db which also is a reference from foreign key from table Brands (ID)
        /// </summary>
        public int BrandID { get; set; }

        /// <summary>
        /// int <c>Quantity</c> refers to AvailableProduct Quantity in mysql db in order to bind it in a datagrid
        /// </summary>
        public int Quantity { get => GetQuantity(); }

        /// <summary>
        /// nullable string <c>Brand</c> refers to Brands Name in mysql db in order to bind it in a datagrid
        /// </summary>
        public string? Brand { get => GetBrand(); }

        /// <summary>
        /// nullable decimal <c>Price</c> refers to AvailableProduct Price in mysql db in order to bind it in a datagrid
        /// </summary>
        public decimal? Price { get => GetPrice(); }

        private string? GetBrand()
        {
            using (WareCareContext db = new WareCareContext(@"Data Source=DESKTOP-VC01PS3\SQLEXPRESS;Initial Catalog=WareCare;Integrated Security=True"))
            {
                string brand = (from a in db.Brands where a.ID == this.BrandID select a.Name).FirstOrDefault();
                return brand;
            }
        }

        private int GetQuantity()
        {
            using (WareCareContext db = new WareCareContext(@"Data Source=DESKTOP-VC01PS3\SQLEXPRESS;Initial Catalog=WareCare;Integrated Security=True"))
            {
                int quantity = (from a in db.AvailableProducts where a.ProductID == this.ID select a.Quantity).FirstOrDefault();
                return quantity;
            }
        }

        private decimal? GetPrice()
        {
            using (WareCareContext db = new WareCareContext(@"Data Source=DESKTOP-VC01PS3\SQLEXPRESS;Initial Catalog=WareCare;Integrated Security=True"))
            {
                decimal? price = (from a in db.AvailableProducts where a.ProductID == this.ID select a.Price).FirstOrDefault();
                return price;
            }
        }
    }
}
