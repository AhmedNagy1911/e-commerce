using Core.Entites;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GenericRepository<T>(StoreContext context) : IGenericRepository<T> where T : BaseEntity
{
    private readonly StoreContext _context = context;

    public void Add(T entity)
    {
       _context.Set<T>().Add(entity);
    }

    public bool Exicts(int id)
    {
     return _context.Set<T>().Any(e => e.Id == id);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);   
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
       return await _context.Set<T>().ToListAsync();
    }

    public void Remove(T entity)
    {
       _context.Set<T>().Remove(entity);
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
  
    public void Update(T entity)
    {
       _context.Set<T>().Attach(entity);
       _context.Entry(entity).State = EntityState.Modified;
    }
}
