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
    public class Brand
    {
        /// <summary>
        /// int <c>ID</c> refers to Brand ID in mysql db which is also a Primary Key for table Brands and reference of foreign key Brand ID from table Products
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// nullable string <c>Name</c> refers to Brand Name in mysql db
        /// </summary>
        public string? Name { get; set; }
    }
}