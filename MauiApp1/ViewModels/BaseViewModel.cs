using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = string.Empty;

    [ObservableProperty]
    private bool _isBusy;

}
