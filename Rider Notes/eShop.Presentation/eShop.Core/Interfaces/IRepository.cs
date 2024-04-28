namespace eShop.Core.Interfaces;

public interface IRepository <T> where T: class
{
    int Insert(T obj);
    int DeleteById(int id);
    int Update(int obj);
    IEnumerable<T> GetAll();
    T GetById(int id);
}