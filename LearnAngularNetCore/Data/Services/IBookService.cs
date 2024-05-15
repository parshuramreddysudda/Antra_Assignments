namespace LearnAngularNetCore.Data;

public interface IBookService
{
    List<Book> GetAllBooks();
    Book getBookByID(int id);

    void UpdateBook(int id,Book book);
    void DeleteBook(int id);
    void AddBook(Book book);
}