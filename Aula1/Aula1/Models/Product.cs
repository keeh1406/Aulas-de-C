using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula1.Models
{
    public class Product
    {
        public long? ProductId { get; set; }
        public string Name { get; set; }
        public long? CategoriaId { get; set; }
        public long? FabricanteId { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}