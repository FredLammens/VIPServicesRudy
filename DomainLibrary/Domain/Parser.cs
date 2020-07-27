using DomainLibrary.Domain.Clients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DomainLibrary.Domain
{
    public class Parser
    {
        private static List<string[]> FileReader(string unziptPath, string fileName, char delimeter = ';')
        {
            string path = unziptPath + @"\" + fileName;
            List<string[]> lines = new List<string[]>();
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                Console.WriteLine("Loading : ");
                int teller = 0;
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] splitted = s.Split(delimeter);
                    lines.Add(splitted);
                    teller++;
                    if (teller == 10000)
                    {
                        Console.Write("*");
                        teller = 0;
                    }
                }
            }
            Console.WriteLine("\nFile : {0} read", fileName);
            return lines;
        }
        public static void InsertIntoDatabase() 
        {

        }
    }
}
