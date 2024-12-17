using MauiApp1.Models;

namespace MauiApp1.Services;

public interface IProductoService
{
    Task<List<Producto>> GetProductosAsync();
}
