using BookRecommender.DBObjects;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecommender.Repositories
{
    public class BookRepository : IBookRepository
    { 
        private readonly string ConnectionString = "Data Source=C:\\tesi\\bookRecommender.db;Version=3";
        private static List<Book> books = new List<Book>();

        public BookRepository()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Books", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            AuthorId = reader.GetInt32(2),
                            Description = reader.GetString(3),
                            ImgUrl = reader.GetString(4),
                        });
                    }
                }
            }

        }
    
        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
