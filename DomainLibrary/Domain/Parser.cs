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
                Console.WriteLine($"Loading File: {Path.GetFileNameWithoutExtension(path)} ");
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] splitted = s.Split(delimeter);
                    lines.Add(splitted);
                    Console.Write('*');
                }
            }
            Console.WriteLine();
            return lines;
        }
        public static void InsertIntoDatabase(IUnitOfWork uow)
        {
            Console.WriteLine("Please enter path of folder with database files (clients,discounts,limousines): ");
            string[] filespath = Directory.GetFiles(Console.ReadLine());
            foreach (string file in filespath)
            {
                int i = 0;
                List<Category> categories = new List<Category>();
                switch (Path.GetFileNameWithoutExtension(file))
                {
                    case "categories":
                        categories = ReadCategories(FileReader(file));
                        uow.Categories.AddCategories(categories);
                        i++;
                        break;
                    case "clients":
                        if (categories.Count == 0)
                        {
                            Console.WriteLine("Zorg ervoor dat categorien voor clients komt");
                        }
                        else
                        {
                            uow.Clients.AddClients(ReadClients(FileReader(file), categories));
                            i++;
                        }
                        break;
                    case "limousines":
                        uow.Limousines.AddLimousines(ReadLimousines(FileReader(file)));
                        i++;
                        break;
                }
                if (i == 3)
                {
                    uow.Complete();
                    Console.WriteLine("saved all objects");
                }
            }
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
                List<Arrangement> arrangements = new List<Arrangement>() { nightLife, wedding, wellness };
                Limousine limo = new Limousine(name, firstHourPrice, arrangements);
                limos.Add(limo);
                Console.WriteLine($"added limo: {limo.Name}");
            }
            return limos;
        }
        private static List<Category> ReadCategories(List<string[]> file)
        {
            List<Category> categories = new List<Category>();
            foreach (string[] line in file.Skip(1))
            {
                CategorieType type = (CategorieType)Enum.Parse(typeof(CategorieType), line[0]);
                int amount = int.Parse(line[1]);
                List<Discount> discounts = new List<Discount>();
                for (int i = 2; i < amount; i++)
                {
                    Discount d = new Discount(int.Parse(line[i]), float.Parse(line[i + amount]));
                    discounts.Add(d);
                }
                Category cat = new Category(discounts, type);
                categories.Add(cat);
                Console.WriteLine($"added category: {cat.Name}");
            }
            return categories;
        }

        private static List<Client> ReadClients(List<string[]> file, List<Category> categories)
        {
            List<Client> clients = new List<Client>();
            foreach (string[] line in file.Skip(1))
            {
                int clientnumber = int.Parse(line[0]);
                string name = line[1];
                //Categorie
                Category category = categories.Where(c => c.Name == (CategorieType)Enum.Parse(typeof(CategorieType), line[2])).Single(); //kunnen geen meerdere zijn . particulier nog niet in lijst
                string VATnumber = line[3];
                string adres = line[4];
                Client client = new Client(name, VATnumber, adres, category);
                client.ClientNumber = clientnumber;
                clients.Add(client);
                Console.WriteLine($"added client: {client.Name}");
            }
            return clients;
        }
    }
}
