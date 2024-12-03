using Microsoft.Extensions.DependencyInjection;
using SpeedyAir;
using SpeedyAir.Interfaces;

public class Program
{
    public static void Main(string[] args)
    {
        // I have passed the flight schedule as well as the given Order Json.
        string outputDirectory = AppDomain.CurrentDomain.BaseDirectory;

        string FlightSchFilePath = Path.Combine(outputDirectory, "FlightSch.json");
        string FlightOrderFilePath = Path.Combine(outputDirectory, "Orders.json");

        // creating Instance
        IFlightSchedule flightSchedule = new FlightSchedule();
        IloadOrders loadOrders = new LoadOrders();

        var flights = flightSchedule.GetFlightSchedule(FlightSchFilePath);
        var orders = loadOrders.LoadOrdersFromJson(FlightOrderFilePath);

        IOrderScuedule orderScheduler = new OrderSchedule(flights, orders);

        // Printing the flight schedules.
        Console.WriteLine("Flight output:");
        flightSchedule.GetFlightSchedule(flights);


        //Printing the order schedules
        Console.WriteLine("Order placed output:");
        orderScheduler.ScheduleOrders();
        orderScheduler.GetOrderSchedule(orders);

        Console.WriteLine("Order Printed and Excel reporting is getting generated");

        Console.WriteLine("Excel report generated successfully!");
        Console.ReadLine();




    }
}