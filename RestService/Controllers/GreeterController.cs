using Microsoft.AspNetCore.Mvc;
using RestService.Models;

namespace RestService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreeterController : ControllerBase
    {
        private readonly ILogger<GreeterController> logger;

        public GreeterController(ILogger<GreeterController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = "SayHello")]
        public Task<HelloResponse> SayHello(string name)
        {
            return Task.FromResult(new HelloResponse
            {
                Message1 = $"Hello1 {name}!",
                Message2 = $"Hello2 {name}!",
                Message3 = $"Hello3 {name}!",
                Message4 = $"Hello4 {name}!",
                Message5 = $"Hello5 {name}!",
                Message6 = $"Hello6 {name}!",
                Message7 = $"Hello7 {name}!",
                Message8 = $"Hello8 {name}!",
                Message9 = $"Hello9 {name}!",
                Message10 = $"Hello10 {name}!"
            });
        }
    }
}