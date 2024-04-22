using My_Books.Models;
using My_Books.Models.DTOs;

namespace My_Books.Repository.Interface
{
    public interface IBooksRepository 
    {
        void AddBook(BookDto book);

        List<Book> GetAllBooks();
        Book GetBookById(int bookId);
        void UpdateBook(int bookId, BookDto book);
        void DeleteBook(int bookId);

    }
}
