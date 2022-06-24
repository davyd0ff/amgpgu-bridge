using AmgpguBridge.SuperService.Encoding;
using AmgpguBridge.SuperService.HttpClient;
using AmgpguBridge.SuperService.Loading;
using AmgpguBridge.SuperService.Packing;
using AmgpguBridge.SuperService.Serializing;
using AmgpguBridge.SuperService.Signing;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// todo develop: make web-service AmgpguBridge.Loader as Asp.Net Core
// todo develop: pass from Configuration["SuperService:Ogrn"] to PackerFactory
// todo develop: pass from Configuration["SuperService:Kpp"] to PackerFactory

builder.Services
  .AddSingleton<IHttpPostClient, HttpPostClient>()

  .AddSingleton<IEncoder, Base64Encoder>()

  .AddSingleton<ISigner>(services => new SignerService(
    new Uri(config["SuperService:Signer:Address"]),
    services.GetRequiredService<IHttpPostClient>()
   ))

  .AddSingleton<JwtMessageBuilder>()
  .AddSingleton<JsonSerializer>()
  .AddSingleton<ResponseFactory>()


  .AddSingleton<ILoader>(services => new HttpLoaderService(
    new Uri(config["SuperService:Address"]),
    new HttpProxyClient(
      new Uri(config["SuperService:Proxy:Address"]),
      services.GetRequiredService<IHttpPostClient>()
    ),
    services.GetRequiredService<JsonSerializer>(),
    services.GetRequiredService<ResponseFactory>()
   ));

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run();
