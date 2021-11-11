using Greet;
using Grpc.Net.Client;
using System.Net.Http.Json;

namespace Client;

public class Worker
{
    public static async Task Start(CancellationToken ct = default)
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5000");
        var client = new Greeter.GreeterClient(channel);
        var httpClient = new HttpClient { BaseAddress = new("http://localhost:4999/v1/") };

        do
        {
            try
            {
                var grpcReply = await client.SayHelloAsync(new HelloRequest { Name = "GRPC" }, cancellationToken: ct);
                Console.WriteLine(grpcReply);

                var httpReply = await httpClient.GetFromJsonAsync<HelloReply>("hello?name=HTTP", ct);
                Console.WriteLine(httpReply);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                await Task.Delay(2000, ct);
                Console.WriteLine();
            }
        } while (ct.IsCancellationRequested == false);
    }
}
