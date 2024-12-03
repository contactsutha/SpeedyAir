using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeedyAir;
using SpeedyAir.Interfaces;


public class FlightSchedule : IFlightSchedule
{
    // Getting the flight schedule
    //Flights schedule are kept in the json file - Incase if we need it from database or API's we can reuse the same instead of hardcoding it.
    public List<Flights> GetFlightSchedule(string jsonFilePath)
    {
        try
        {
            // Created the flight list in JSON instead of hardcoding 
            string json = File.ReadAllText(jsonFilePath);
            List<Flights>? flights = JsonConvert.DeserializeObject<List<Flights>>(json);
            return flights ?? new List<Flights>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading flight schedule from the JSON load: {ex.Message}");
            return new List<Flights>();
        }
    }
    
    public void GetFlightSchedule(List<Flights> flights) // Method overloaded and check the availablity
    {
        if (flights.Count == 0)
        {
            Console.WriteLine("No flights are available.");
            return;
        }

        foreach (var flight in flights)
        {
            Console.WriteLine(flight.ToString());
        }
    }
}

