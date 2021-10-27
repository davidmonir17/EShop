using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Category { get; set; }
        public string  Summury { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }

    }
}
