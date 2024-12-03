using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Interfaces
{
    public interface IloadOrders
    {
        List<Order> LoadOrdersFromJson(string jsonFilePath);

    }
}
