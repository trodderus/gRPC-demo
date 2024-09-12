using Grpc.Net.Client;
using GrpcService;
using System.Net.Http.Headers;
using System.Net;
using static GrpcService.Greeter;
using System.Net.Http;
using Microsoft.AspNetCore.WebUtilities;
using ConsumerApp.Models;
using System.Text.Json;
using System.Net.Http.Json;
using System.Diagnostics;

namespace ConsumerApp
{
    internal static class Services
    {
        public static async Task<string> ConnectToGRPCService(string host, int port, string request, List<TimeSpan> times)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Create a client for the service.
            var client = new GreeterClient(GrpcChannel.ForAddress($"{host}:{port}"));

            // Call the service method.
            var responseMessage = await client.SayHelloAsync(new HelloRequest
            {
                Name = request
            });
            stopwatch.Stop();

            times.Add(stopwatch.Elapsed);
            //Console.WriteLine($"GRPC - Response: {responseMessage}");
            //Console.WriteLine($"GRPC - Elapsed: {stopwatch.Elapsed}");
            //Console.WriteLine("GRPC - Service Test - Finish");

            // Return the response message.
            return responseMessage.Message1;
        }

        public static async Task<string> ConnectToRESTService(string host, int port, string request, List<TimeSpan> times)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Create a new HttpClient object.
            using var client = new HttpClient();

            // Create a query parameters message.
            var query = new Dictionary<string, string>()
            {
                ["name"] = request
            };

            var uri = QueryHelpers.AddQueryString($"{host}:{port}/Greeter", query);

            var response = await client.GetAsync(uri);

            var hello = await response.Content.ReadFromJsonAsync<HelloResponse>();

            stopwatch.Stop();

            times.Add(stopwatch.Elapsed);
            //Console.WriteLine($"REST - Response: {hello}");
            //Console.WriteLine($"REST - Elapsed: {stopwatch.Elapsed}");
            //Console.WriteLine("REST - Service Test - Finish");

            return hello.Message1;
        }

    }

}
