using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryCo
{
    class ReceiptPrinter
    {
        public Receipt receipt;

        public ReceiptPrinter(Receipt receipt)
        {
            this.receipt = receipt;
        }

        // Print the header
        public void displayHeader()
        {
            Console.WriteLine();
            Console.WriteLine("================   GroceryCo    ==================" + "\n");
            Console.WriteLine("**************************************************");
            Console.WriteLine(" Item                                       Price ");
            Console.WriteLine("##################################################");
        }

        // Print the total price
        public void displayTotal()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("                         Total:             {0, 1}\n\n\n", receipt.totalPrice );
        }
        
        // Print the main receipt body, check if each item is on sale or not
        public void displayBody()
        {

            foreach(Grocery item in receipt.receiptList)
            {
                if (!item.onSale)
                {
                    Console.WriteLine(String.Format(" {0, -10} x{1, -10} {2, 24}\n", item.id, item.num, item.price));
                }
                else
                {
                    Console.WriteLine(String.Format(" {0, -10} x{1, -10} {2, 24}", item.id, item.num, item.price));
                    Console.WriteLine(String.Format("(Sale: {0})".PadLeft(49)+"\n",item.onSalePrice));
                }
            }
        }

        // Print all components
        public void print()
        {
            displayHeader();
            displayBody();
            displayTotal();
        }
    }
}
