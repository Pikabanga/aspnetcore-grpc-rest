using System.Threading.Tasks;
using Greet;

namespace aspnetapp.Services
{
    public class GreeterService : IGreeterService
    {
        public Task<HelloReply> SayHello(HelloRequest request)
            => Task.FromResult(new HelloReply
            {
                Message = $"Hello {request.Name}!"
            });
    }
}