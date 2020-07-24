using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDBestPracticeConsoleAPP
{
    public class Product
    {
        public int productId { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int categoryId { get; set; }
        public int onSale { get; set; }
        public string stockLevel { get; set; }

    }
}
