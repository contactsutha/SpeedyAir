using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Interfaces
{
    public interface IFlightSchedule
    {
        List<Flights> GetFlightSchedule(string jsonFilePath); // Get flight Schedule
        void GetFlightSchedule(List<Flights> flights); //check the availablity; implementing with method overload

    }
}
