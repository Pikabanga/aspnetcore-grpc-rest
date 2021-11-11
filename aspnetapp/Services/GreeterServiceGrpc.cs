using System.Threading.Tasks;
using Greet;
using Grpc.Core;

namespace aspnetapp.Services
{
    /// <summary>
    /// Greeting Service
    /// </summary>
    public class GreeterServiceGrpc : Greeter.GreeterBase
    {
        private readonly IGreeterService _greeterService;

        public GreeterServiceGrpc(IGreeterService greeterService)
        {
            _greeterService = greeterService;
        }

        /// <summary>
        /// A method that takes in a request name and responds with a hello message
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
            => _greeterService.SayHello(request);
    }
}