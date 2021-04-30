using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryCo
{
    // Class for processing the prices and generating a final list
    public class Processor
    {
        List<Grocery> compactedList;
        List<Sale> sales = new List<Sale>();
        List<Price> prices = new List<Price>();

        public Processor(List<Grocery> groceryList, List<Sale> sales, List<Price> prices)
        {
            this.sales = sales;
            this.prices = prices;
            this.compactedList = getCompactedList(groceryList);

        }

        // Calculate both noraml price and sale price (if any) by item name
        // Compare the current date with the dates on prices and sales
        public (decimal?, decimal?) getPriceById(string id)
        {
            DateTime currentTime = DateTime.Now;
            decimal? normalPrice = null;
            decimal? salePrice = null;
            foreach (Price price in this.prices) { 
                if (id == price.id)
                {
                    foreach (PriceByTime p in price.prices)
                        if (DateTime.Compare(currentTime, p.date) > 0)
                        {
                            normalPrice = p.price;
                        }
                        else
                        {
                            break;
                        }
                }
            }

            foreach (Sale sale in this.sales)
            {
                if (id == sale.id)
                {
                    if (DateTime.Compare(currentTime, sale.startDate) > 0 && DateTime.Compare(currentTime, sale.endDate) < 0)
                    {
                        salePrice = sale.onSalePrice;
                        break;
                    }
                }
            }

            return (normalPrice, salePrice);
        }

        // Calculate the total price (incluing sale) from a final grocery list
        public decimal? getTotalPrice(List<Grocery> list)
        {
            decimal? totalPrice = 0;
            foreach (Grocery item in list)
            {
                if (!item.onSale)
                {
                    totalPrice += item.price * item.num;
                }
                else
                {
                    totalPrice += item.onSalePrice * item.num;
                }
            }
            return totalPrice;
        }

        // Generate a new list that groupes the same grocery item and set the num property
        public List<Grocery> getCompactedList(List<Grocery> list)
        {
            var idDict = new Dictionary<string, int>();
            List<Grocery> compactedList = new List<Grocery>();
            foreach (Grocery grocery in list)
            {
                if (!idDict.ContainsKey(grocery.id))
                {
                    idDict[grocery.id] = 1;
                }
                else
                {
                    idDict[grocery.id] += 1;
                }
        
            }

            foreach (string id in idDict.Keys)
            {
                    compactedList.Add(new Grocery(){
                    id = id,
                    num = idDict[id]
                });
            }
            return compactedList;

        }

        // Add the correct price and sale info to the compacted List
        public void setReceiptList()
        {
            decimal? normalPrice = null;
            decimal? salePrice = null;
            foreach (var item in this.compactedList) {
                (normalPrice, salePrice) = getPriceById(item.id);
                item.price = normalPrice;
                if(salePrice != null)
                {
                    item.onSalePrice = salePrice;
                    item.onSale = true;
                }
                else
                {
                    item.onSalePrice = null;
                    item.onSale = false;
                }
            }
        }

        // Generate a receipt info, including a compacted list and a total price 
        public Receipt getReceipt()
        {
            this.setReceiptList();
            decimal? totalPrice = getTotalPrice(this.compactedList);
            return new Receipt() { receiptList = this.compactedList, totalPrice = totalPrice };
        }
    }

    
}
