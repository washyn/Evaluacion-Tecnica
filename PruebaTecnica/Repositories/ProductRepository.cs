using System.Data.SqlClient;
using Dapper;
using PruebaTecnica.Others;

namespace PruebaTecnica.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IConfiguration _configuration;

    public ProductRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<string>> GetAllProducts()
    {
        using (SqlConnection connection = new SqlConnection(_configuration.GetDefaultConexion()))
        {
            var result = await connection.QueryAsync<string>("SELECT Name FROM Products");
            return result.ToList();
        }
    }

    public async Task CreateProduct(string name)
    {
        using (SqlConnection connection = new SqlConnection(_configuration.GetDefaultConexion()))
        {
            await connection.ExecuteAsync("INSERT INTO Products (Name) VALUES (@Name)", new { Name = name });
        }
    }
}
