using MauiApp1.Services;
using MauiApp1.ViewModels;
using MauiApp1.Views;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IProductoService, ProductoService>();
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<ProductoListaViewModel>();
            builder.Services.AddSingleton<ProductoDetalleViewModel>();


            builder.Services.AddTransient<ProductoListaPage>();
            builder.Services.AddTransient<ProductoDetallePage>();
            builder.Services.AddTransient<MainPage>();

            return builder.Build();
        }
    }
}
