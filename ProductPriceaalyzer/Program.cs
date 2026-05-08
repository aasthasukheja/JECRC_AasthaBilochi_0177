using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductPriceAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            string pricesLine = Console.ReadLine()!;
            string targetLine = Console.ReadLine()!;

            // Extract prices
            int[] prices = pricesLine.Split(':')[1]
                                     .Split(',')
                                     .Select(x => int.Parse(x.Trim()))
                                     .ToArray();

            int target = int.Parse(targetLine.Split(':')[1].Trim());

            Console.WriteLine("\n--- Product Price Analysis ---\n");

            Console.WriteLine("Original Prices: " + string.Join(", ", prices));

            // 1. Bubble Sort (Ascending)
            int[] sorted = (int[])prices.Clone();

            for (int i = 0; i < sorted.Length - 1; i++)
            {
                for (int j = 0; j < sorted.Length - i - 1; j++)
                {
                    if (sorted[j] > sorted[j + 1])
                    {
                        int temp = sorted[j];
                        sorted[j] = sorted[j + 1];
                        sorted[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nSorted Prices (Ascending): " + string.Join(", ", sorted));

            // 2. Binary Search
            Console.WriteLine("\nBinary Search Results:");

            int index1 = BinarySearch(sorted, 399);
            int index2 = BinarySearch(sorted, 500);

            if (index1 != -1)
                Console.WriteLine($"Price 399 found at index {index1}");
            else
                Console.WriteLine("Price 399 not found");

            if (index2 != -1)
                Console.WriteLine($"Price 500 found at index {index2}");
            else
                Console.WriteLine("Price 500 not found");

            // 3. Pairs with target sum
            Console.WriteLine($"\nPairs that sum to {target}:");

            HashSet<int> seen = new HashSet<int>();

            foreach (int price in sorted)
            {
                int complement = target - price;

                if (seen.Contains(complement))
                {
                    Console.WriteLine($"({complement}, {price})");
                }

                seen.Add(price);
            }

            // 4. Longest Increasing Subsequence (DP)
            List<int> lis = LongestIncreasingSubsequence(sorted);

            Console.WriteLine("\nLongest Increasing Subsequence:");
            Console.WriteLine(string.Join(", ", lis) + $" (Length: {lis.Count})");

            // 5. Statistics
            int min = sorted.Min();
            int max = sorted.Max();
            double avg = sorted.Average();

            double median;
            int n = sorted.Length;

            if (n % 2 == 0)
            {
                median = (sorted[n / 2 - 1] + sorted[n / 2]) / 2.0;
            }
            else
            {
                median = sorted[n / 2];
            }

            Console.WriteLine("\nStatistics:");
            Console.WriteLine($"Lowest Price: {min}");
            Console.WriteLine($"Highest Price: {max}");
            Console.WriteLine($"Average Price: {avg:F2}");
            Console.WriteLine($"Median Price: {median:F2}");
        }

        // Binary Search
        static int BinarySearch(int[] arr, int target)
        {
            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        // Longest Increasing Subsequence (simple DP)
        static List<int> LongestIncreasingSubsequence(int[] arr)
        {
            int n = arr.Length;
            int[] dp = new int[n];
            int[] parent = new int[n];

            Array.Fill(dp, 1);
            Array.Fill(parent, -1);

            int maxLen = 1, lastIndex = 0;

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] > arr[j] && dp[i] < dp[j] + 1)
                    {
                        dp[i] = dp[j] + 1;
                        parent[i] = j;
                    }
                }

                if (dp[i] > maxLen)
                {
                    maxLen = dp[i];
                    lastIndex = i;
                }
            }

            List<int> lis = new List<int>();

            while (lastIndex != -1)
            {
                lis.Add(arr[lastIndex]);
                lastIndex = parent[lastIndex];
            }

            lis.Reverse();
            return lis;
        }
    }
}