using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryCo
{
    // Class for sales info
    public class Sale
    {
        // item name 
        public string id { get; set; }

        // onSalePrice
        public decimal? onSalePrice { get; set; }

        // Sale start date
        public DateTime startDate { get; set; }

        // Sale end date
        public DateTime endDate { get; set; }
    }
}
