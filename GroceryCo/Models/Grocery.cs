using System;
using System.Collections.Generic;
using System.Text;


namespace GroceryCo
{
    // Class for each grocery item
    public class Grocery
    {
        // item name
        public string id { get; set; }

        // item regular price
        public decimal? price { get; set; }

        // item onSale price
        public decimal? onSalePrice { get; set; }

        // onSale flag
        public bool onSale { get; set; }

        // number of purchase
        public int num { get; set; }
    }
}
