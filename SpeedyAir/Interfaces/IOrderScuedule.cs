using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Interfaces
{
    public interface IOrderScuedule
    {
        void ScheduleOrders(); // schedule the orders to flights
        void GetOrderSchedule(List<Order> orders); // print order's schedule
        void GenerateExcelReport(ExcelPackage excelPackage, Order order, Flights flight); // generate Excel report 
    }
}
