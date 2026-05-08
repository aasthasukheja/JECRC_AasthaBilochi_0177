using System;
using System.Collections.Generic;
using System.Linq;

namespace DataQueryPipeline
{
    // Base Query Class
    class Query
    {
        // Original Data
        protected List<int> dataSource;

        // Execution Status
        protected bool isExecuted;

        // Constructor
        public Query(List<int> data)
        {
            dataSource = data;
            isExecuted = false;
        }

        // Deferred Execution
        public virtual IEnumerable<int> Apply()
        {
            return dataSource;
        }

        // Force Execution
        public virtual List<int> Execute()
        {
            isExecuted = true;
            return Apply().ToList();
        }

        // Query Type
        public virtual string GetQueryType()
        {
            return "Base Query";
        }
    }

    // FilterQuery Class
    class FilterQuery : Query
    {
        public string predicate;
        public int filteredCount;

        public FilterQuery(List<int> data, string predicate)
            : base(data)
        {
            this.predicate = predicate;
        }

        // Deferred filtering
        public override IEnumerable<int> Apply()
        {
            IEnumerable<int> result = dataSource;

            if (predicate.StartsWith(">"))
            {
                int value = int.Parse(predicate.Substring(1));
                result = dataSource.Where(x => x > value);
            }
            else if (predicate.StartsWith("<"))
            {
                int value = int.Parse(predicate.Substring(1));
                result = dataSource.Where(x => x < value);
            }
            else if (predicate.ToLower() == "even")
            {
                result = dataSource.Where(x => x % 2 == 0);
            }
            else if (predicate.ToLower() == "odd")
            {
                result = dataSource.Where(x => x % 2 != 0);
            }

            return result;
        }

        // Force Execution
        public override List<int> Execute()
        {
            List<int> result = Apply().ToList();

            filteredCount = result.Count;
            isExecuted = true;

            Console.WriteLine($"Filter Executed,Predicate:{predicate},Result Count:{filteredCount}");

            return result;
        }

        public override string GetQueryType()
        {
            return "Filter Query";
        }
    }

    // AggregateQuery Class
    class AggregateQuery : Query
    {
        public string operation;
        public double result;

        public AggregateQuery(List<int> data, string operation)
            : base(data)
        {
            this.operation = operation;
        }

        // Deferred execution
        public override IEnumerable<int> Apply()
        {
            return dataSource;
        }

        // Force execution
        public override List<int> Execute()
        {
            switch (operation.ToLower())
            {
                case "sum":
                    result = dataSource.Sum();
                    break;

                case "average":
                    result = dataSource.Average();
                    break;

                case "max":
                    result = dataSource.Max();
                    break;

                case "min":
                    result = dataSource.Min();
                    break;
            }

            isExecuted = true;

            Console.WriteLine($"Aggregation Executed,Operation:{operation},Result:{result}");

            return dataSource;
        }

        public override string GetQueryType()
        {
            return "Aggregate Query";
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Input Query Type
            string queryType = Console.ReadLine();

            // Input Data
            List<int> data = Console.ReadLine()
                                    .Split(' ')
                                    .Select(int.Parse)
                                    .ToList();

            // Input Predicate / Operation
            string input = Console.ReadLine();

            Query query;

            // Create Object based on query type
            if (queryType.ToLower() == "filter")
            {
                query = new FilterQuery(data, input);
            }
            else
            {
                query = new AggregateQuery(data, input);
            }

            // Execute Query
            query.Execute();
        }
    }
}