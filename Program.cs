using BookRecommender.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Book Recommender - entry point");
        var x = new UserRepository();
    }
}