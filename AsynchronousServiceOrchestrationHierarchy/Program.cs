using System;
using System.Threading.Tasks;

namespace AsyncServiceOrchestration
{
    // Base Class
    class AsyncService
    {
        // Properties
        protected int requestCount;
        protected long lastResponseTime;

        // Constructor
        public AsyncService()
        {
            requestCount = 0;
            lastResponseTime = 0;
        }

        // Virtual Async Method
        public virtual async Task<string> FetchDataAsync(string endpoint)
        {
            await Task.Delay(2000);
            return "Base Fetch";
        }

        // Virtual Async Status Method
        public virtual async Task<string> GetStatusAsync()
        {
            await Task.Delay(100);
            return "Base Service Status";
        }
    }

    // WeatherService Class
    class WeatherService : AsyncService
    {
        public string city;
        public int temperature;

        public WeatherService(string city)
        {
            this.city = city;

            // Example temperature
            temperature = 22;
        }

        // Override FetchDataAsync
        public override async Task<string> FetchDataAsync(string endpoint)
        {
            requestCount++;

            Console.WriteLine($"Weather Fetch Started,{city}");

            // Simulate 2 second delay
            await Task.Delay(2000);

            Console.WriteLine($"Weather Data Received,{city},{temperature}°C");

            return "Weather Data";
        }

        // Override GetStatusAsync
        public override async Task<string> GetStatusAsync()
        {
            await Task.Delay(100);

            string status =
                $"Weather Service Status,Requests:{requestCount}";

            Console.WriteLine(status);

            return status;
        }
    }

    // StockService Class
    class StockService : AsyncService
    {
        public string symbol;
        public double currentPrice;

        public StockService(string symbol)
        {
            this.symbol = symbol;

            // Example stock price
            currentPrice = 245.75;
        }

        // Override FetchDataAsync
        public override async Task<string> FetchDataAsync(string endpoint)
        {
            requestCount++;

            Console.WriteLine($"Stock Fetch Started,{symbol}");

            // Simulate 2 second delay
            await Task.Delay(2000);

            Console.WriteLine($"Stock Price Update,{symbol},${currentPrice}");

            return "Stock Data";
        }

        // Override GetStatusAsync
        public override async Task<string> GetStatusAsync()
        {
            await Task.Delay(100);

            string status =
                $"Stock Service Status,Requests:{requestCount}";

            Console.WriteLine(status);

            return status;
        }
    }

    // Main Program
    class Program
    {
        static async Task Main(string[] args)
        {
            // Input Service Type
            string serviceType = Console.ReadLine();

            // Input Identifier
            string identifier = Console.ReadLine();

            // Input Command
            string command = Console.ReadLine();

            AsyncService service;

            // Create Object
            if (serviceType.ToLower() == "weather")
            {
                service = new WeatherService(identifier);
            }
            else
            {
                service = new StockService(identifier);
            }

            // Execute Command
            if (command == "FetchDataAsync")
            {
                await service.FetchDataAsync(identifier);
            }
            else if (command == "GetStatusAsync")
            {
                await service.GetStatusAsync();
            }
        }
    }
}