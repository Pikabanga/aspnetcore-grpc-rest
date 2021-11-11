namespace Client;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var cts = new CancellationTokenSource();

        Console.CancelKeyPress += (s, e) =>
        {
            e.Cancel = true;
            cts.Cancel();
        };

        var ct = cts.Token;

        try
        {
            await Worker.Start(ct);
        }
        catch (OperationCanceledException ex) when (ex.CancellationToken == ct)
        {
            Console.WriteLine("Bye :)");
            await Task.Delay(300);
        }
    }
}