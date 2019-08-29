using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Produtos
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public double Preco { get; set; }
        public int Sku { get; set; }
    }
}
