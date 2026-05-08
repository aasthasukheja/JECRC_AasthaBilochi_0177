using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerPreferenceAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            string electronicsInput = Console.ReadLine()!;
            string clothingInput = Console.ReadLine()!;
            string booksInput = Console.ReadLine()!;

            // Extract customers from input
            HashSet<string> electronics = new HashSet<string>(
                electronicsInput.Split(':')[1].Split(',')
            );

            HashSet<string> clothing = new HashSet<string>(
                clothingInput.Split(':')[1].Split(',')
            );

            HashSet<string> books = new HashSet<string>(
                booksInput.Split(':')[1].Split(',')
            );

            // 1. UNION (ANY category)
            HashSet<string> anyCategory = new HashSet<string>(electronics);
            anyCategory.UnionWith(clothing);
            anyCategory.UnionWith(books);

            // 2. INTERSECTION (ALL categories)
            HashSet<string> allCategory = new HashSet<string>(electronics);
            allCategory.IntersectWith(clothing);
            allCategory.IntersectWith(books);

            // 3. ONLY Electronics (Difference)
            HashSet<string> onlyElectronics = new HashSet<string>(electronics);
            onlyElectronics.ExceptWith(clothing);
            onlyElectronics.ExceptWith(books);

            // 4. Electronics AND Books but NOT Clothing
            HashSet<string> elecAndBooks = new HashSet<string>(electronics);
            elecAndBooks.IntersectWith(books);
            elecAndBooks.ExceptWith(clothing);

            // OUTPUT
            Console.WriteLine("\n--- Customer Preference Analysis ---\n");

            // 1. ANY category
            Console.WriteLine("1. Customers in ANY category (Union):");
            Console.WriteLine(string.Join(", ", anyCategory));
            Console.WriteLine($"Total: {anyCategory.Count} customers\n");

            // 2. ALL categories
            Console.WriteLine("2. Customers in ALL categories (Intersection):");
            Console.WriteLine(string.Join(", ", allCategory));
            Console.WriteLine($"Total: {allCategory.Count} customer\n");

            // 3. ONLY Electronics
            Console.WriteLine("3. Customers ONLY in Electronics (Difference):");
            Console.WriteLine(string.Join(", ", onlyElectronics));
            Console.WriteLine($"Total: {onlyElectronics.Count} customers\n");

            // 4. Electronics AND Books but NOT Clothing
            Console.WriteLine("4. Customers in Electronics AND Books but NOT Clothing:");
            Console.WriteLine(string.Join(", ", elecAndBooks));
            Console.WriteLine($"Total: {elecAndBooks.Count} customers");
        }
    }
}