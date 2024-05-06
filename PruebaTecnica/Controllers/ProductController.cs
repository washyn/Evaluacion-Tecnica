using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Repositories;

namespace PruebaTecnica.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet]
    public async Task<List<string>> GetAllProducts()
    {
        return await _productRepository.GetAllProducts();
    }

    [HttpPost]
    public async Task AddProduct(CreateProduct product)
    {
        await _productRepository.CreateProduct(product.Name);
    }
}
