using System;
using System.IO;

namespace GroceryCo
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    // Ask user to input the file to checkout
                    Console.WriteLine("Please input the file to checkout...");
                    string checkoutFileName = Console.ReadLine();

                    // Check out the file
                    Program program = new Program();
                    program.checkOut(checkoutFileName);

                    // Ask if the user wants to check out another file
                    Console.WriteLine("Do you want to checkout another file? [Y/N]");
                    string answer = Console.ReadLine().ToUpper();
                    if (answer == "Y")
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.ToString());

                }
            }
            
        }

        // Checkout function: takes an filename as input and present checkout info
        public void checkOut(string filename)
        {
            try
            {
                // Read the prices and sales information
                JsonReader reader;
                try
                {
                    reader = new JsonReader("prices.json", "sales.json");
                }
                catch (FileNotFoundException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No sales and prices file are found, please put them in the right folder and try again.");
                    return;
                }
                reader.readBasket(filename);

                // Create a processor that takes as input: the prices and sales information and grocerylist 
                // Generates a final receipt
                Processor processor = new Processor(reader.groceryList, reader.sales, reader.prices);
                Receipt Receipt = processor.getReceipt();

                // ReceiptPrinter prints out the checkout info
                ReceiptPrinter receiptPrinter = new ReceiptPrinter(Receipt);
                receiptPrinter.print();
            }
            catch(FileNotFoundException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found! please try again");
                Console.ResetColor();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.ToString());
                return;
            }
        }
    }
}
