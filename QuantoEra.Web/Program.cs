using QuantoEra.Web.Components;
using QuantoEra.IPCA;
using QuantoEra.Web.Services;

namespace QuantoEra.Web;

public class Program 
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddRazorComponents()
            .AddInteractiveServerComponents();

        builder.Services.AddScoped<IPCAMonthlyPercentageProvider>();
        builder.Services.AddScoped<IPCANumericIndexProvider>();
        builder.Services.AddScoped<IPCACalculator>();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            app.UseHsts();
        }

        app.UseAntiforgery();

        app.MapStaticAssets();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();       
    }
}