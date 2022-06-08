using AmgpguBridge.SuperService;
using AmgpguBridge.SuperService.Encoding;
using AmgpguBridge.SuperService.Loading;
using AmgpguBridge.SuperService.Serializing;
using AmgpguBridge.SuperService.Signing;

var builder = WebApplication.CreateBuilder(args);

// todo think: how to pass ISigner & IEncoder
// todo develop: make web-service AmgpguBridge.Loader as Asp.Net Core
// todo develop: pass from Configuration["SuperService:Ogrn"] to PackerFactory
// todo develop: pass from Configuration["SuperService:Kpp"] to PackerFactory

builder.Services
  .AddSingleton<IHttpPostClient, HttpPostClient>()
  .AddSingleton<IEncoder, Base64Encoder>()
  .AddSingleton<ISigner>(new SignerService(
    new Uri(builder.Configuration["SuperService:Signer:Address"]),
    new HttpPostClient()
   ))
  .AddSingleton<ILoader>(new HttpLoaderService(
    new Uri(builder.Configuration["SuperService:Address"]),
    new HttpProxyClient(
      new Uri(builder.Configuration["SuperService:Proxy:Address"]),
      new HttpPostClient()
    ),
    new JsonSerializer()
   ));

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Run();
