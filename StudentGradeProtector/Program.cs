using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradeProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Number of students
            int n = int.Parse(Console.ReadLine()!);

            // Store student data: Name -> List of grades
            Dictionary<string, List<int>> students = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                // Example: John 85 90 78 92
                string[] input = Console.ReadLine()!.Split(' ');

                string name = input[0];

                List<int> grades = input.Skip(1)
                                        .Select(x => int.Parse(x))
                                        .ToList();

                students[name] = grades;
            }

            Console.WriteLine("\n--- Student Grade Report ---\n");

            // Store averages for finding top performer
            Dictionary<string, double> averages = new Dictionary<string, double>();

            // For unique grades across all students
            HashSet<int> uniqueGrades = new HashSet<int>();

            // Process each student
            foreach (var student in students)
            {
                string name = student.Key;
                List<int> grades = student.Value;

                double avg = grades.Average();
                int max = grades.Max();
                int min = grades.Min();

                averages[name] = avg;

                // Add to global unique set
                foreach (int g in grades)
                {
                    uniqueGrades.Add(g);
                }

                Console.WriteLine($"{name}: Average = {avg:F2}, Highest = {max}, Lowest = {min}");
            }

            // Top Performer
            var top = averages.OrderByDescending(x => x.Value).First();

            Console.WriteLine($"\nTop Performer: {top.Key} (Average: {top.Value:F2})\n");

            // Students with all grades >= 80
            Console.WriteLine("Students with all grades >= 80:");

            foreach (var student in students)
            {
                if (student.Value.All(g => g >= 80))
                {
                    Console.WriteLine($"{student.Key} ({string.Join(",", student.Value)})");
                }
            }

            // Unique grades across all students
            Console.WriteLine("\nUnique Grade Values Across All Students:");

            var sortedGrades = uniqueGrades.OrderBy(x => x);

            Console.WriteLine(string.Join(",", sortedGrades));
            Console.WriteLine($"\nTotal unique grades: {uniqueGrades.Count}");
        }
    }
}