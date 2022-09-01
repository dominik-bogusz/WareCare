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
    public class AvailableProduct
    {
        /// <summary>
        /// int <c>ID</c> refers to AvailableProduct ID in mysql db which is also a primary key
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// int <c>Product</c> refers to AvailableProduct ProductID which is also a foreign key references column ID from table Products
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// int <c>Quantity</c> refers to AvailableProduct Quantity in mysql db
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// nullable decimal <c>Price</c> refers to AvailableProduct Price in mysql db
        /// </summary>
        public decimal? Price { get; set; }
    }
}