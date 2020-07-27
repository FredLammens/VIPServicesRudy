using DomainLibrary.Domain.Clients;
using DomainLibrary.Domain.Limousines;
using DomainLibrary.Domain.Limousines.FixedArrangements;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Domain
{
    public class Parser
    {
        private static List<string[]> FileReader(string path, char delimeter = ',')
        {
            List<string[]> lines = new List<string[]>();
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                Console.WriteLine("Loading Files: ");
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] splitted = s.Split(delimeter);
                    lines.Add(splitted);
                    Console.Write('*');
                }
            }
            return lines;
        }
        public static void InsertIntoDatabase()
        {
            Console.WriteLine("Please enter path of folder with database files (clients,discounts,limousines): ");
            string[] files = Directory.GetFiles(Console.ReadLine());
            Parallel.ForEach(files, (currentFile) =>
            {
                //kan niet eerst categories voor client 
                List<string[]> lines = FileReader(currentFile);
            });
        }
        private static List<Limousine> ReadLimousines(List<string[]> file)
        {
            List<Limousine> limos = new List<Limousine>();
            foreach (string[] line in file.Skip(1))
            {
                string name = line[0]; //try catch ??
                int firstHourPrice = int.Parse(line[1]);
                NightLife nightLife = new NightLife(int.Parse(line[2]));
                Wedding wedding = new Wedding(int.Parse(line[3]));
                Wellness wellness = new Wellness(int.Parse(line[4]));
                List<Arrangement> arrangements = new List<Arrangement>() {nightLife,wedding,wellness};
                limos.Add(new Limousine(name,firstHourPrice,arrangements));
            }
            return limos;
        }
        private static List<Category> ReadCategories(List<string[]> file) 
        {
            List<Category> categories = new List<Category>();
            foreach (string[] line in file.Skip(1))
            {
                CategorieType type = (CategorieType)Enum.Parse(typeof(CategorieType),line[0]);
                int amount = int.Parse(line[1]);
                List<Discount> discounts = new List<Discount>();
                for (int i = 2; i < amount+i; i++)
                {
                    Discount d = new Discount(int.Parse(line[i]), float.Parse(line[i] + amount));
                    discounts.Add(d);
                }
                categories.Add(new Category(discounts, type));
            }
            return categories;
        }

        private static List<Client> ReadClients(List<string[]> file) 
        {
            List<Client> clients = new List<Client>();
            foreach (string[] line in file.Skip(1))
            {
                int klantnummer = int.Parse(line[0]);
                string naam = line[1];
                //Categorie
            }
            return clients;
        }
    }
}
