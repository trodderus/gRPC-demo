using ConsumerApp;
using System.Diagnostics;

var tasks = new List<Task>();
var grpcTimes = new List<TimeSpan>();
var restTimes = new List<TimeSpan>();
for (int i = 0; i < 10000; i++)
{
    tasks.Add(Services.ConnectToGRPCService("http://localhost", 5227, "TestRequest", grpcTimes));

    tasks.Add(Services.ConnectToRESTService("http://localhost", 5252, "TestRequest", restTimes));
}
Task.WaitAll(tasks.ToArray());

Console.WriteLine($"GRPC - Average time - {grpcTimes.Sum(r => r.Ticks)/100000000000.0}s");
Console.WriteLine($"REST - Average time - {restTimes.Sum(r => r.Ticks)/100000000000.0}s");