using MauiApp1.Views;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute(nameof(ProductoListaPage), typeof(ProductoListaPage));
            Routing.RegisterRoute(nameof(ProductoDetallePage), typeof(ProductoDetallePage));
        }
    }
}
