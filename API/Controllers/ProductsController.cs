using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductRepository repo) : ControllerBase
{
    private readonly IProductRepository _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
    {
        return Ok(await _repo.GetProductsAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _repo.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        _repo.AddProduct(product);

        if(await _repo.SaveChangesAsync())
         CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);

        return BadRequest("can not create the product");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id || !ProductExists(id))
            return BadRequest("can not update the product");

       _repo.UpdateProduct(product);

        if(await _repo.SaveChangesAsync())
        return NoContent();

        return BadRequest("can not update the product");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _repo.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _repo.DeleteProduct(product);
        
        if(await _repo.SaveChangesAsync())
        return NoContent();

        return BadRequest("can not delete the product");
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductBrands()
    {
        return Ok(await _repo.GetBrandsAsync());
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductTypes()
    {
        return Ok(await _repo.GetTypesAsync());
    }

    private bool ProductExists(int id)
    {
        return _repo.ProductExists(id);
    }
}
