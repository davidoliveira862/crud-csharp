using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public double price { get; set; }
    }
}