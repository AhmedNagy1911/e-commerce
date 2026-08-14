using Core.Entites;
using Core.Interfaces;

namespace Infrastructure.Data;

public class GenericRepository<T>(StoreContext context) : IGenericRepository<T> where T : BaseEntity
{
    private readonly StoreContext _context = context;

    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public bool Exicts(int id)
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public void Remove(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAllAsync()
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
