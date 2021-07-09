using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System.Globalization;
using Microsoft.JSInterop;
using Client.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shipping.Shared;
using Shipping.Client;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDU1NTc4QDMxMzkyZTMxMmUzMGp6Uzc0bnVGcUdObDNIOVFBRlpXa3hWY0xlb0QwWVJGb3NGZ3dRN3IzUzg9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddSyncfusionBlazor();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddSingleton<IShippingOperations, ShippingOperations>();

            builder.Services.AddValidatorsFromAssemblyContaining<PlaceHolderClass>();
            await builder.Build().RunAsync();
        }
    }
}
