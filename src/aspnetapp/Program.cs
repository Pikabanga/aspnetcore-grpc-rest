using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace aspnetapp
{
    /// <summary>
    /// Program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the application
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static async Task Main(string[] args) =>
            await CreateHostBuilder(args).Build().RunAsync();


        /// <summary>
        /// Create and configure a builder object.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.ConfigureKestrel(options =>
                    {
                        // Use HTTP/1.x
                        options.ListenAnyIP(4999, listenOptions => 
                            listenOptions.Protocols = HttpProtocols.Http1);
                        
                        // Use HTTP/2
                        options.ListenAnyIP(5000, listenOptions => 
                            listenOptions.Protocols = HttpProtocols.Http2);
                        
                        // Use HTTP/3
                        options.ListenAnyIP(5001, listenOptions =>
                        {
                            listenOptions.Protocols = HttpProtocols.Http3;
                            listenOptions.UseHttps();
                        });
                    })
                    .UseStartup<Startup>());
    }
}
