using Core.Entites;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IGenericRepository<Product> repo) : ControllerBase
{
    private readonly IGenericRepository<Product> _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort)
    {
        var spec = new ProductSpecification(brand, type, sort);
        var products = await _repo.ListAsync(spec);

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _repo.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        _repo.Add(product);

        if(await _repo.SaveAllAsync())
         CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);

        return BadRequest("can not create the product");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id || !ProductExists(id))
            return BadRequest("can not update the product");

       _repo.Update(product);

        if(await _repo.SaveAllAsync())
        return NoContent();

        return BadRequest("can not update the product");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _repo.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _repo.Remove(product);
        
        if(await _repo.SaveAllAsync())
        return NoContent();

        return BadRequest("can not delete the product");
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductBrands()
    {
       var spec = new BrandListSpeification();
       return Ok(await _repo.ListAsync(spec));
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductTypes()
    {
         var spec = new TypeListSpeification();
       return Ok(await _repo.ListAsync(spec));
    }

    private bool ProductExists(int id)
    {
        return _repo.Exicts(id);
    }
}
