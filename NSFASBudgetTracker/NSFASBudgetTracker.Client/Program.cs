using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NSFASBudgetTracker.Client;
using Blazored.LocalStorage;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped(sp => new HttpClient 
{
    BaseAddress = new Uri("https://localhost:5171/") // <-- Match your API URL
});
await builder.Build().RunAsync();
