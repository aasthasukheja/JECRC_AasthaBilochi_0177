using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesDataAggregator
{
    class Sale
    {
        public string ProductId { get; set; } = "";
        public string Region { get; set; } = "";
        public int Amount { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Number of records
            int n = int.Parse(Console.ReadLine()!);

            List<Sale> sales = new List<Sale>();

            // Input
            for (int i = 0; i < n; i++)
            {
                // Example: P001 North 1500
                string[] input = Console.ReadLine()!.Split(' ');

                sales.Add(new Sale
                {
                    ProductId = input[0],
                    Region = input[1],
                    Amount = int.Parse(input[2])
                });
            }

            // Threshold input
            string thresholdLine = Console.ReadLine()!;
            int threshold = int.Parse(thresholdLine.Split(':')[1].Trim());

            Console.WriteLine("\n--- Sales Report by Product and Region ---\n");

            // Group by Product
            var productGroups = sales.GroupBy(s => s.ProductId);

            foreach (var product in productGroups)
            {
                Console.WriteLine($"Product {product.Key}:");

                // Region-wise grouping
                var regionGroups = product.GroupBy(p => p.Region);

                foreach (var region in regionGroups)
                {
                    int totalRegionSales = region.Sum(r => r.Amount);
                    Console.WriteLine($"  {region.Key}: ${totalRegionSales}");
                }

                int total = product.Sum(p => p.Amount);
                double avg = product.Average(p => p.Amount);

                Console.WriteLine($"  Total: ${total}, Average: ${avg:F2}\n");
            }

            // Best Selling Product by Region
            Console.WriteLine("Best Selling Product by Region:");

            var regionWise = sales.GroupBy(s => s.Region);

            foreach (var region in regionWise)
            {
                var best = region.OrderByDescending(r => r.Amount).First();
                Console.WriteLine($"{region.Key}: {best.ProductId} (${best.Amount})");
            }

            // Underperforming Products
            Console.WriteLine($"\nUnderperforming Products (< ${threshold} average):");

            foreach (var product in productGroups)
            {
                double avg = product.Average(p => p.Amount);

                if (avg < threshold)
                {
                    Console.WriteLine($"{product.Key} (${avg:F2})");
                }
            }
        }
    }
}