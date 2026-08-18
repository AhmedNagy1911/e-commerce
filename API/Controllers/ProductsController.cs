using Core.Entites;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductsController(IUnitOfWork unit) : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery] ProductSpecParams productParams)
    {
        var spec = new ProductSpecification(productParams);
       
        return await CreatePageResult(unit.Repository<Product>(), spec, productParams.PageIndex, productParams.PageSize);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await unit.Repository<Product>().GetByIdAsync(id);
        if (product == null)
            return NotFound();

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        unit.Repository<Product>().Add(product);

        if(await unit.Complete())
         CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);

        return BadRequest("can not create the product");
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        if (id != product.Id || !ProductExists(id))
            return BadRequest("can not update the product");

       unit.Repository<Product>().Update(product);

        if(await unit.Complete())
        return NoContent();

        return BadRequest("can not update the product");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await unit.Repository<Product>().GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        unit.Repository<Product>().Remove(product);

        if(await unit.Complete())
        return NoContent();

        return BadRequest("can not delete the product");
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductBrands()
    {
       var spec = new BrandListSpeification();
       return Ok(await unit.Repository<Product>().ListAsync(spec));
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetProductTypes()
    {
         var spec = new TypeListSpeification();
       return Ok(await unit.Repository<Product>().ListAsync(spec));
    }

    private bool ProductExists(int id)
    {
        return unit.Repository<Product>().Exicts(id);
    }
}
