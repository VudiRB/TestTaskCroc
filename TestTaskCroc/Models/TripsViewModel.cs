using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestTaskCroc.Models
{
    public class TripsViewModel: Trips
    {
        public IEnumerable<SelectListItem> Workers { get; set; }
        public IEnumerable<SelectListItem> Cars { get; set; }
        public TripsViewModel(Trips trips)
        {
            Car = trips.Car;
            Range = trips.Range;
            Worker = trips.Worker;
            ID = trips.ID;
            EndTime = trips.EndTime;
            StartTime = trips.StartTime;
            CostOfSpentFuel = trips.CostOfSpentFuel;
        }
    }
}