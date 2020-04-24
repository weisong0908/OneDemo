using System.Collections.Generic;
using MongoDB.Driver;
using OneDemo.Mongo.Models;
using OneDemo.Mongo.Persistence;

namespace OneDemo.Mongo.Services
{
    public class BookService : IBookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books.Find(b => true).ToList();
        }

        public Book GetBook(string id)
        {
            return _books.Find<Book>(b => b.Id == id).FirstOrDefault();
        }

        public Book CreateBook(Book book)
        {
            _books.InsertOne(book);

            return book;
        }

        public void UpdateBook(Book book)
        {
            _books.ReplaceOne(b => b.Id == book.Id, book);
        }

        public void RemoveBook(Book book)
        {
            _books.DeleteOne(b => b.Id == book.Id);
        }
    }
}