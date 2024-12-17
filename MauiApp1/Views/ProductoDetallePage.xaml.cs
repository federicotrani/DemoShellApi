using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ProductoDetallePage : ContentPage
{
	public ProductoDetallePage(ProductoDetalleViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}