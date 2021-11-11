using System.Threading.Tasks;
using Greet;

namespace aspnetapp.Services
{
    public interface IGreeterService
    {
        Task<HelloReply> SayHello(HelloRequest request);
    }
}