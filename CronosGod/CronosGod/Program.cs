using CronosGod;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<Function>();
    })
    .Build();

await host.RunAsync();
