using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(service =>
    {
        service.AddSingleton<MyService>();
    })
    .ConfigureAppConfiguration((config) =>
    {
        config.AddJsonFile("appsettings.json", optional: true);
    })
    .Build();

host.Run();

public class MyService
{
    public string GetValue() => $"Hello {DateTime.UtcNow}";
}