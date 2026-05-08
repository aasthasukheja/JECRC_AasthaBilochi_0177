using System;
using System.Collections.Generic;

namespace WarehouseStockTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dictionary to store ProductId and Quantity
            Dictionary<int, int> inventory = new Dictionary<int, int>();

            // Number of operations
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                // Read operation input
                string input = Console.ReadLine();

                // Split command
                string[] parts = input.Split(' ');

                string operation = parts[0];

                // ADD Operation
                if (operation == "ADD")
                {
                    int productId = int.Parse(parts[1]);
                    int quantity = int.Parse(parts[2]);

                    if (inventory.ContainsKey(productId))
                    {
                        inventory[productId] += quantity;
                    }
                    else
                    {
                        inventory[productId] = quantity;
                    }
                }

                // REMOVE Operation
                else if (operation == "REMOVE")
                {
                    int productId = int.Parse(parts[1]);
                    int quantity = int.Parse(parts[2]);

                    if (inventory.ContainsKey(productId))
                    {
                        // Validate stock availability
                        if (inventory[productId] >= quantity)
                        {
                            inventory[productId] -= quantity;
                        }
                        else
                        {
                            Console.WriteLine($"Cannot remove {quantity} units from Product {productId}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Product {productId} not found");
                    }
                }

                // CHECK Operation
                else if (operation == "CHECK")
                {
                    int productId = int.Parse(parts[1]);

                    if (inventory.ContainsKey(productId))
                    {
                        Console.WriteLine($"Product {productId}: {inventory[productId]} units");
                    }
                    else
                    {
                        Console.WriteLine($"Product {productId}: 0 units");
                    }
                }

                // BULK Operation
                else if (operation == "BULK")
                {
                    // Example:
                    // BULK 1003:75,1004:40

                    string bulkData = input.Substring(5);

                    string[] products = bulkData.Split(',');

                    foreach (string product in products)
                    {
                        string[] data = product.Split(':');

                        int productId = int.Parse(data[0]);
                        int quantity = int.Parse(data[1]);

                        if (inventory.ContainsKey(productId))
                        {
                            inventory[productId] += quantity;
                        }
                        else
                        {
                            inventory[productId] = quantity;
                        }
                    }
                }

                // DISPLAY Operation
                else if (operation == "DISPLAY")
                {
                    Console.WriteLine("\n--- Current Inventory ---");

                    foreach (var item in inventory)
                    {
                        // Display only stock > 0
                        if (item.Value > 0)
                        {
                            Console.WriteLine($"{item.Key}: {item.Value} units");
                        }
                    }
                }
            }
        }
    }
}