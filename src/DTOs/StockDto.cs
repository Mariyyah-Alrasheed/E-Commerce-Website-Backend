using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sda_onsite_2_csharp_backend_teamwork.src.DTOs
{
    public class StockCreatDto
    {
        public Guid ProductId { get; set; }
        public int StockQuantity { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public char Size { get; set; }


    }
    public class StockReadDto
    {

    }
}