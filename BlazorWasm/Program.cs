using BlazorWasm;
using ClientLibrary.Helper;
using ClientLibrary.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NetcodeHub.Packages.WebAssembly.Storage.Cookie;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddNetcodeHubCookieStorageService();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHttpClientHelper, HttpClientHelper>();
builder.Services.AddScoped<IApiCallHelper, ApiCallHelper>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();


await builder.Build().RunAsync();
