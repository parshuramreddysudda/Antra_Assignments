namespace ApplicationCore.RepositoryContracts;

public interface IRepositoryAsync<T> where T:class
{
    Task<T> GetByIdAsync(int id);
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
   // IEnumerable<T> Filter(Func<T,bool>)
}