using DomainLibrary.Domain;
using System;

namespace VIPServicesRudy
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Do you want to insert from custom file? (y/n)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y" || answer.ToLower() == "yes")
            {
                Parser.InitDatabase(true);
            }
            else if (answer.ToLower() == "n" || answer.ToLower() == "no")
            {
                Parser.InitDatabase();
            }
            else
                Console.WriteLine("please enter a valid answer.");
        }
    }
}
