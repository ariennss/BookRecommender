using BookRecommender.DBObjects;
using System.Text;
using System.Data.SQLite;

namespace BookRecommender.Repositories
{
    public class UserRepository
    {
        private readonly string ConnectionString = "Data Source=C:\\tesi\\DBCreator\\ConsoleAppSQLite\\bin\\Debug\\net8.0\\bookRecommender.db;Version=3";
        private List<User> Users = new List<User>();

        // all'inizializzazione del repository fillo la lista così da fare le query poi in locale
        public UserRepository()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Users", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            Email = reader.GetString(3),
                            Username = reader.GetString(4),
                            Password = reader.GetString(5),
                        });
                    }
                }
            }

        }


    }
}
