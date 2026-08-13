using Core.Entites;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepository(StoreContext context) : IProductRepository
{
    private readonly StoreContext _context = context;

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
    }

    public void DeleteProduct(Product product)
    {
       _context.Products.Remove(product);
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
       return await _context.Products.ToListAsync();
    }

    public bool ProductExists(int id)
    {
       return _context.Products.Any(p => p.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void UpdateProduct(Product product)
    {
       _context.Entry(product).State = EntityState.Modified;
    }
}
