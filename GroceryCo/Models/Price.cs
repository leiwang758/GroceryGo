using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryCo
{
    // Class for a item price
    public class Price
    {
        // Item name
        public string id { get; set; }

        // List of prices at different days
        public List<PriceByTime> prices { get; set; }
    }

    // Class that represent the price at certain time
    public class PriceByTime
    {
        public DateTime date { get; set; }
        public decimal? price { get; set;}
    }
}
