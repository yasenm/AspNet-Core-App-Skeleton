using Microsoft.Extensions.Configuration;
using System.IO;

namespace CoreAppSkeleton.DataConsole
{
    public class Program
    {
        private static IConfigurationRoot _config;

        public static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            _config = builder.Build();

            System.Console.WriteLine(_config["ConnectionStrings:DefaultConnection"]);
        }
    }
}
