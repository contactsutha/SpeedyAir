using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir
{
    public class Flights
    {
        // Declared all the properties related to Flights, Orders towards the flight
        public int FlightNo { get; set; }
        public string FlightOrigin { get; set; }
        public string FlightDestination { get; set; }
        public int Day { get; set; }
        public List<Order> OrderAssigned { get; set; } = new List<Order>();
        public int Capacity { get; set; } = 20; // Capacity value passing based on the requirement !


        public Flights(int _flightNo, string _flightOrigin, string _flightDestination, int _day)
        {
            FlightNo = _flightNo; FlightOrigin = _flightOrigin; FlightDestination = _flightDestination; Day = _day;

        }
        public override string ToString()
        {
            return $"Flight: {FlightNo},departure: {FlightOrigin}, arrival: {FlightDestination}, Day: {Day}";
        }

        public void AssignOrder(Order order)
        {
            OrderAssigned.Add(order);
        }

        public bool HasCapacity() => OrderAssigned.Count < Capacity; // Checking the capacity while assinging the order

        public bool MatchesDestination(string destination) => FlightDestination == destination; // Validating the flight with the order destination 

    }
}
