using UltraGreateDivanShop.Domain;

namespace UltraGreateDivanShop.Web.Repositories.Interfaces;

public interface IRepositoryCart
{
    decimal Price { get; }
    IEnumerable<Product> Get();
    IEnumerable<int> Ids();
    void Add(int id, Product product);
    void Remove(int id);
    void Clear();
}