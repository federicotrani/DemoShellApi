using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ProductoListaPage : ContentPage
{
	public ProductoListaPage(ProductoListaViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }
}	