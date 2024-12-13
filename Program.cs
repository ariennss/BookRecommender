using BookRecommender.Authentication;
using BookRecommender.Repositories;
using CsvHelper;
using System.Data.SQLite;
using System.Formats.Asn1;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Book Recommender - entry point");
        var x = new UserRepository();
        var authentication = new Authenticator(x);
        //authentication.AuthenticationMenu();
        Console.WriteLine("start reviews adding at" + DateTime.Now);
        var y = new ReviewRepository();
        Console.WriteLine("end at" + DateTime.Now);

    }
}