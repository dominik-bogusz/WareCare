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
    }
}
