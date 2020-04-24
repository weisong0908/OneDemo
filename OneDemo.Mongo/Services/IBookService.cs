using System.Collections.Generic;
using OneDemo.Mongo.Models;

namespace OneDemo.Mongo.Services
{
    public interface IBookService
    {
        Book CreateBook(Book book);
        Book GetBook(string id);
        IEnumerable<Book> GetBooks();
        void RemoveBook(Book book);
        void UpdateBook(Book book);
    }
}