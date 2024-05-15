
namespace LearnAngularNetCore.Data
{
    class BookService : IBookService
    {
        public void AddBook(Book book)
        {
            Data.Books.Add(book);
            throw new NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            // Data.Books[id].;
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            return Data.Books.ToList();
        }

        public Book getBookByID(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }

}