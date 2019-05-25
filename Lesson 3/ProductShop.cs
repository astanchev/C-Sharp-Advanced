namespace _03._Product_Shop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class ProductShop
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string,double>> shopProductPrice = 
                new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "Revision")
                {
                    break;
                }

                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!shopProductPrice.ContainsKey(shop))
                {
                    shopProductPrice[shop] = new Dictionary<string, double>();
                }

                if (!shopProductPrice[shop].ContainsKey(product))
                {
                    shopProductPrice[shop][product] = price;
                }
            }

            foreach (var shop in shopProductPrice.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
