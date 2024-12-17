using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        Title = "Main Page";
    }

    [RelayCommand]
    async Task GoToProductoListaAsync()
    {
        
        await Shell.Current.GoToAsync("ProductoListaPage");
        // await Shell.Current.DisplayAlert("Aviso", "Vamos a Lista de Productos!", "Ok");
    }

    [RelayCommand]
    async Task GoToSaludoAsync()
    {
        // await Shell.Current.GoToAsync("ProductoDetallePage");
        await Shell.Current.DisplayAlert("Aviso", "Hola Mundo!", "Ok");
    }

    [RelayCommand]  
    async Task CheckInternetAsync()
    {
        var msgInternet = Connectivity.NetworkAccess == NetworkAccess.Internet ? "Hay Acceso a Internet" : "NO tiene acceso a Internet"; ;
        await Shell.Current.DisplayAlert("Internet", msgInternet, "Ok");
    }
}
