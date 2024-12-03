using OfficeOpenXml;
using SpeedyAir.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir
{
    public class OrderSchedule : IOrderScuedule
    {
        private readonly List<Flights> _flights;
        private readonly List<Order> _orders;
        int row = 2;

        public OrderSchedule(List<Flights> flights, List<Order> orders) // Parameterized Contructor to initialize the objects
        {
            _flights = flights;
            _orders = orders;
        }

        public void ScheduleOrders() // Order Scheduling method
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("Flight and Orders");

            // Write the headers for flights and orders
            worksheet.Cells[1, 1].Value = "Order No";
            worksheet.Cells[1, 2].Value = "Flight No";
            worksheet.Cells[1, 3].Value = "Flight Origin";
            worksheet.Cells[1, 4].Value = "Flight Destination";
            worksheet.Cells[1, 5].Value = "Flight Day";

            _orders.ForEach(order =>
            {
                var flight = _flights
                    .FirstOrDefault(f => f.MatchesDestination(order.Destination) && f.HasCapacity());

                if (flight != null)
                {
                    flight.AssignOrder(order);
                    order.FlightAssigned = $"{flight.FlightNo}, Day {flight.Day}";
                }
                else
                {
                    order.FlightAssigned = "Not scheduled";

                }
                GenerateExcelReport(package, order, flight);

            });

            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            string filePath = Path.Combine(downloadsFolder, "OrderReport" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".xlsx");

            // Save the Excel file in download folder in logged in user
            FileInfo fileInfo = new FileInfo(filePath);
            package.SaveAs(fileInfo);

        }

        public void GetOrderSchedule(List<Order> orders) // Printing the order output
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"Order No: {order.OrderNo},FlightNumber: {order.FlightAssigned.Split(",")[0]}, Departure: YUL, Arrival : {order.Destination}, Day: {order.FlightAssigned.Substring(order.FlightAssigned.LastIndexOf(',') + 1)}");

            }
        }

        public void GenerateExcelReport(ExcelPackage excelPackage, Order order,Flights flight)
        {
            var worksheet = excelPackage.Workbook.Worksheets[0];

            var assignedFlight = _flights.Find(flight => flight.FlightDestination == order.Destination);

            if (assignedFlight != null)
            {
                worksheet.Cells[row, 1].Value = order.OrderNo;
                worksheet.Cells[row, 2].Value = "FlightNumber: " + flight.FlightNo;
                worksheet.Cells[row, 3].Value = flight.FlightOrigin;
                worksheet.Cells[row, 4].Value = flight.FlightDestination;
                worksheet.Cells[row, 5].Value = flight.Day;
            }
            else
            {
                worksheet.Cells[row, 1].Value = order.OrderNo;
                worksheet.Cells[row, 2].Value = "Not Scheduled";
                worksheet.Cells[row, 3].Value = "YUL";
                worksheet.Cells[row, 4].Value = order.Destination;
                worksheet.Cells[row, 5].Value = "Not Scheduled";
                worksheet.Cells[row, 1, row, 5].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[row, 1, row, 5].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);


            }
            row++;
        }

    }
}
