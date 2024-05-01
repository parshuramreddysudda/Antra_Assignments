using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repository;

public class BaseRepository<T> : IRepository<T> where T: class
{

    private readonly ECommerenceDbContext _context; 
    public BaseRepository(ECommerenceDbContext _context)
    {
        this._context = _context;
    }
    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public int Insert(T entity)
    {
        _context.Set<T>().Add(entity);
        return _context.SaveChanges();
    }

    public int Update(T entity)
    {
        _context.Set<T>().Entry(entity).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public int Delete(int id)
    {
        var i = GetById(id);
        _context.Set<T>().Remove(i);
        return _context.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
      return _context.Set<T>().ToList();
    }
}