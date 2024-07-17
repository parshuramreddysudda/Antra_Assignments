using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Repository;

public class BaseRepositoryAsync<T>(ECommerenceDbContext _context) : IRepositoryAsync<T>
    where T : class
{
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