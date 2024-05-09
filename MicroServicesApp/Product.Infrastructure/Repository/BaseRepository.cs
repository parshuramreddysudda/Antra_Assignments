using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repository;

public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T: class
{

    private readonly ECommerenceDbContext _context; 
    public BaseRepositoryAsync(ECommerenceDbContext _context)
    {
        this._context = _context;
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<int> InsertAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _context.Set<T>().Entry(entity).State = EntityState.Modified;
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var i = await GetByIdAsync(id);
        _context.Set<T>().Remove(i);
        return await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }
}