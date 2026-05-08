using System;
using System.Collections.Generic;
using System.Linq;

namespace SequencePatternDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input
            string inputLine = Console.ReadLine()!;
            int K = int.Parse(Console.ReadLine()!);

            // Extract numbers from input
            string numbersPart = inputLine.Split(':')[1];
            int[] nums = numbersPart.Split(',')
                                    .Select(x => int.Parse(x.Trim()))
                                    .ToArray();

            Console.WriteLine("\n--- Access Pattern Analysis ---\n");

            // 1. Longest Consecutive Sequence
            HashSet<int> set = new HashSet<int>(nums);
            List<int> longestSeq = new List<int>();

            foreach (int num in set)
            {
                if (!set.Contains(num - 1)) // start of sequence
                {
                    List<int> currentSeq = new List<int>();
                    int current = num;

                    while (set.Contains(current))
                    {
                        currentSeq.Add(current);
                        current++;
                    }

                    if (currentSeq.Count > longestSeq.Count)
                    {
                        longestSeq = currentSeq;
                    }
                }
            }

            Console.WriteLine("Longest Consecutive Sequence: " +
                string.Join(",", longestSeq) +
                $" (Length: {longestSeq.Count})\n");


            // 2. Most Frequent Element
            Dictionary<int, int> freq = new Dictionary<int, int>();

            foreach (int num in nums)
            {
                if (freq.ContainsKey(num))
                    freq[num]++;
                else
                    freq[num] = 1;
            }

            var mostFreq = freq.OrderByDescending(x => x.Value).First();

            Console.WriteLine($"Most Frequent Element: {mostFreq.Key} (appears {mostFreq.Value} times)\n");


            // 3. First Non-Repeating Element
            int firstNonRepeating = nums.First(x => freq[x] == 1);

            Console.WriteLine($"First Non-Repeating Element: {firstNonRepeating}\n");


            // 4. Pairs with Difference K
            HashSet<int> uniqueSet = new HashSet<int>(nums);
            List<(int, int)> pairs = new List<(int, int)>();

            foreach (int num in uniqueSet)
            {
                if (uniqueSet.Contains(num + K))
                {
                    pairs.Add((num, num + K));
                }
            }

            Console.WriteLine($"Pairs with Difference {K}:");
            Console.WriteLine(string.Join(", ", pairs.Select(p => $"({p.Item1}, {p.Item2})")));
            Console.WriteLine();


            // 5. Majority Element
            int n = nums.Length;
            var majority = freq.OrderByDescending(x => x.Value).First();

            double percentage = (double)majority.Value / n * 100;

            if (majority.Value > n / 2)
            {
                Console.WriteLine($"Majority Element: {majority.Key} (appears {majority.Value} out of {n} times)");
            }
            else
            {
                Console.WriteLine($"Majority Element: {majority.Key} (appears {majority.Value} out of {n} times - {percentage:F1}% - No majority)");
            }
        }
    }
}