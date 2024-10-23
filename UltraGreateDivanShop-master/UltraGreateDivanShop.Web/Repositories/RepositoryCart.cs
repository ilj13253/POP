using UltraGreateDivanShop.Domain;
using UltraGreateDivanShop.Web.Repositories.Interfaces;

namespace UltraGreateDivanShop.Web.Repositories;

public class RepositoryCart : IRepositoryCart
{
    private readonly Dictionary<int, Product> products = [];

    public decimal Price => products.Sum(product => product.Value.Price) ?? 0;

    public void Add(int id, Product product)
    {
        products.Add(id, product);
    }

    public void Remove(int id)
    {
        products.Remove(id);
    }

    public void Clear()
    {
        products.Clear();
    }

    public IEnumerable<Product> Get() =>
        products.Values;

    public IEnumerable<int> Ids()
    {
        return products.Keys;
    }
}