using Ignitor;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DemoClient
{
    class Program
    {
        // dotnet run -p DemoClient - http://localhost:5000 500
        // dotnet run -p DemoClient - https://courseassistant.azurewebsites.net/ 500
        async static Task<int> Main(string[] args)
        {
            //var uri = new Uri("http://localhost:5000");
            //var uri = new Uri("https://courseassistant.azurewebsites.net/");
            //var count = 500;

            if (args.Length == 0)
            {
                Console.WriteLine("usage: DemoClient <url> <count>");
                return 1;
            }

            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.Write("Cancelling...");
                cts.Cancel();
            };

            var uri = new Uri(args[0]);
            var count = int.Parse(args[1]);

            var tasks = new List<Task>();
            for (var i = 0; i < count; i++)
            {
                int idx = i;
                Console.WriteLine($"Creating client {i}...");
                var client = new BlazorClient()
                {
                    DefaultOperationTimeout = TimeSpan.FromSeconds(50), 
                };

                while (true)
                {
                    try
                    {
                        var connected = await client.ConnectAsync(uri, connectAutomatically: true);
                        if (!connected)
                        {
                            throw new InvalidOperationException("Failed to connect.");
                        }

                        break;
                    }
                    catch (HttpRequestException ex) when (ex.Message.Contains("429"))
                    {
                        Console.WriteLine("Getting rate limited. Waiting...");
                    }

                    await Task.Delay(TimeSpan.FromSeconds(5));
                }

                tasks.Add(Task.Run(() => RunAsync(idx,uri, client, cts.Token)));
                await Task.Delay(200);
            }

            Console.WriteLine($"Started {count} clients.");

            await Task.WhenAll(tasks);
            return 0;
        }

        async static Task RunAsync(int idx, Uri uri, BlazorClient client, CancellationToken cancellationToken)
        {
            var counterUri = uri.AbsoluteUri + "/counter";

            await using (client)
            {
                try
                {
                    await client.ExpectRenderBatch(async () =>
                    {
                        await client.HubConnection.InvokeAsync("OnLocationChanged", $"{counterUri.ToString()}", false, cancellationToken);
                    });

                    while (!cancellationToken.IsCancellationRequested)
                    {
                        await client.ClickAsync("clicker");
                        await Task.Delay(TimeSpan.FromSeconds(0.5));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Client failed [[[{idx}]]]: " + ex);
                }
            }
        }
    }
}
