using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace GroceryCo
{
    // Class for reading different json files
    class JsonReader
    {
        public List<Grocery> groceryList { set; get; }
        public List<Price> prices { set; get; }
        public List<Sale> sales { set; get; }


        public JsonReader(string pricesFile, string salesFile)
        {

            setPrices(pricesFile);
            setSales(salesFile);
            
        }

        // Read normal prices from the prices.json file, and return a list of Price objects
        public void setPrices(string pricesFile)
        {
            
            this.prices = JsonConvert.DeserializeObject<List<Price>>(File.ReadAllText("../../../Files/" + pricesFile));
           
        }

        // Read on sale prices from the sales.json file, and return a list of Sale objects
        public void setSales(string salesFile)
        {
            
            this.sales = JsonConvert.DeserializeObject<List<Sale>>(File.ReadAllText("../../../Files/" + salesFile));
            
        }
        
        // Read the checkout list from the input json file, and return a list of Grocery objects
        public void readBasket(string basketFile)
        {

            this.groceryList = JsonConvert.DeserializeObject<List<Grocery>>(File.ReadAllText("../../../Files/" + basketFile));
           
        }
       
    }
}
