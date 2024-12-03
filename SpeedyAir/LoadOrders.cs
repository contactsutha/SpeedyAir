using Newtonsoft.Json;
using SpeedyAir.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir
{
    public class LoadOrders : IloadOrders
    {
        public List<Order> LoadOrdersFromJson(string jsonFilePath)
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                var ordersDict = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
                List<Order> orders = new List<Order>();

                foreach (var entry in ordersDict)
                {
                    var order = new Order(entry.Key, entry.Value.destination.ToString());
                    orders.Add(order);
                }
                return orders;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading orders: {ex.Message}");
                return new List<Order>();
            }
        }

    }
}
