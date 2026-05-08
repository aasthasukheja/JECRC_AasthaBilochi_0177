using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequencyAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read paragraph
            string text = Console.ReadLine()!;

            // Read N (top frequent words)
            int N = int.Parse(Console.ReadLine()!);

            // Convert to lowercase
            text = text.ToLower();

            // Remove punctuation
            text = Regex.Replace(text, @"[^\w\s]", "");

            // Split into words
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Count frequency using Dictionary
            Dictionary<string, int> frequency = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (frequency.ContainsKey(word))
                {
                    frequency[word]++;
                }
                else
                {
                    frequency[word] = 1;
                }
            }

            // Total words
            int totalWords = words.Length;

            // Unique words
            int uniqueWords = frequency.Count;

            // Top N frequent words
            var topWords = frequency
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Take(N);

            // Words appearing exactly once
            var singleWords = frequency
                .Where(x => x.Value == 1)
                .Select(x => x.Key)
                .OrderBy(x => x);

            // Average frequency
            double avgFrequency = frequency.Values.Average();

            // OUTPUT
            Console.WriteLine("\n--- Word Frequency Analysis ---\n");

            Console.WriteLine($"Total words: {totalWords}");
            Console.WriteLine($"Unique words: {uniqueWords}\n");

            Console.WriteLine($"Top {N} Frequent Words:");
            foreach (var item in topWords)
            {
                Console.WriteLine($"{item.Key}: {item.Value} times");
            }

            Console.WriteLine("\nWords appearing exactly once:");
            Console.WriteLine(string.Join(", ", singleWords));

            Console.WriteLine($"\nAverage frequency: {avgFrequency:F2} times per unique word");
        }
    }
}