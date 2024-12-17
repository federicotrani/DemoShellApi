using MauiApp1.Models;
using System.Text.Json;

namespace MauiApp1.Services;

public class ProductoService : IProductoService
{
    private HttpClient httpClient;
    public ProductoService()
    {
        httpClient = new HttpClient();
    }

    public async Task<List<Producto>> GetProductosAsync()
    {
        try
        {
            var response = await httpClient.GetAsync("https://fakestoreapi.com/products");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Producto>>(content);
            }

            return new List<Producto>();
        }
        catch (Exception)
        {
            throw new Exception("Error al obtener productos");
        }

        
    }
}
