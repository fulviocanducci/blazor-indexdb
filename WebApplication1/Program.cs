﻿using Microsoft.AspNetCore.Blazor.Hosting;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args)
        {
            return BlazorWebAssemblyHost
                .CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
        }
    }
}
