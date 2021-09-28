using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace BasicCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
            string myValue = configuration["Test:Value"];
            string myValue2 = configuration.GetSection("Test")["Value"];
            Console.WriteLine($"myValue is {myValue}");
        }
    }

    public static class MyExtensions
    {
        public static IConfigurationBuilder AddMyConfigProvider(this IConfigurationBuilder builder)
        {
            return builder;
        }
    }
}