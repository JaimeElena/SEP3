using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Uber.Models;

namespace Uber.Data
{
    public class CostumerService : ICostumerService
    {
        public IList<Costumer> costumers { get; set; }
        public string costumersFile = @"C:\Users\jaime\source\repos\";

        public CostumerService()
        {
            if (!File.Exists(costumersFile))
            {
                Console.WriteLine("File doesn't exist");
                Seed();
            }
            else
            {
                string content = File.ReadAllText(costumersFile);
                costumers = JsonSerializer.Deserialize<List<Costumer>>(content);
                Console.WriteLine("Content adquired");
            }
        }
        public async Task<Costumer> AddCostumerAsync(Costumer costumer)
        {
            costumers.Add(costumer);
            SaveChanges();
            return costumer;
        }

        public async Task<IList<Costumer>> GetCostumersAsync()
        {
            List<Costumer> tmp = new List<Costumer>(costumers);
            return tmp;
        }

        public void Seed()
        {
            Costumer[] tmpL =
            {
                new Costumer
                {
                     id = 1,
                     name = "Jaime",
                     password = "123456"
                },
                 new Costumer
                {
                     id = 2,
                     name = "Suzanne",
                     password = "123456"
                }
            };

            costumers = tmpL.ToList();
        }

        public void SaveChanges()
        {
            string jsonCostumers = JsonSerializer.Serialize(costumers, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(costumersFile, false))
            {
                outputFile.Write(jsonCostumers);
            }
        }
    }
}
