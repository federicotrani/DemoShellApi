    using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using MauiApp1.Services;
using MauiApp1.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels;

public partial class ProductoListaViewModel : BaseViewModel
{
    public ObservableCollection<Producto> Productos { get; } = new();

    [ObservableProperty]
    private Producto? productoSeleccionado;

    [ObservableProperty]
    private bool isRefreshing;

    [ObservableProperty]
    private string saludo = "Hola Mundo";    

    IProductoService _productoService;
    IConnectivity _connectivity;

    public ProductoListaViewModel(IProductoService productoService, IConnectivity connectivity)
    {
        _productoService = productoService;
        _connectivity = connectivity;
        Title = "Lista de Productos";
        
    }

    [RelayCommand]
    async Task NavigateToDetailAsync()
    {
        if (ProductoSeleccionado == null)
            return;

        // var route = $"{nameof(ProductoDetalle)}?{nameof(ProductoDetalleViewModel.ProductoId)}={ProductoSeleccionado.Id}";
        var data = new Dictionary<string, object>()
        {
            { "Producto", ProductoSeleccionado }
        };

        await Shell.Current.GoToAsync(
            $"{ nameof(ProductoDetallePage)}",new Dictionary<string, object>{["Producto"] = ProductoSeleccionado});

        // await Shell.Current.GoToAsync("ProductoDetalle", true);

    }

    [RelayCommand]
    async Task GetProductosAsync()
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Error", "No hay conexión a internet", "Ok");
            return;
        }

        if (IsBusy)        
            return;

        try
        {
            IsBusy = true;            

            var productos = await _productoService.GetProductosAsync();

            if(productos.Count != 0)
            {
                if(Productos.Count > 0)
                    Productos.Clear();                
            
                foreach (var producto in productos)
                {
                    Productos.Add(producto);
                }

            }
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Error", "No se pudo obtener los productos", "Ok");
            
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }        
        
    }
}
