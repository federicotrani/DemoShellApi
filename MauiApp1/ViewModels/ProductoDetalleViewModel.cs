using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;

namespace MauiApp1.ViewModels;


[QueryProperty(nameof(Producto), nameof(Producto))]
public partial class ProductoDetalleViewModel : BaseViewModel
{
    [ObservableProperty]
    private string saludo;

    [ObservableProperty]
    private Producto producto;

    public ProductoDetalleViewModel()
    {
        Title = "Detalle de Producto";
    }

    [RelayCommand]
    async Task GoBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }
}
