namespace PruebaTecnica.Repositories;

public interface IProductRepository
{
    Task<List<string>> GetAllProducts();
    Task CreateProduct(string name);
}