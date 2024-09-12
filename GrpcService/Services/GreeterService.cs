using Grpc.Core;

namespace GrpcService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message1 = $"Hello1 {request.Name}!",
                Message2 = $"Hello2 {request.Name}!",
                Message3 = $"Hello3 {request.Name}!",
                Message4 = $"Hello4 {request.Name}!",
                Message5 = $"Hello5 {request.Name}!",
                Message6 = $"Hello6 {request.Name}!",
                Message7 = $"Hello7 {request.Name}!",
                Message8 = $"Hello8 {request.Name}!",
                Message9 = $"Hello9 {request.Name}!",
                Message10 = $"Hello10 {request.Name}!"
            });
        }
    }
}