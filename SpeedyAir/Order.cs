using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir
{
    public class Order
    {
        public string OrderNo { get; set; }
        public string Destination { get; set; }
        public string FlightAssigned { get; set; } = "not scheduled";

        public Order(string _orderNo, string _destination)
        {
            OrderNo = _orderNo;
            Destination = _destination;
        }
    }
}
