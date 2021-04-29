using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryCo
{
    // Class for the final receipt
    public class Receipt
    {
        // A list of groceries
         public List<Grocery> receiptList { set; get; }

        // A final total price
         public decimal? totalPrice { set; get; }
    }
}
