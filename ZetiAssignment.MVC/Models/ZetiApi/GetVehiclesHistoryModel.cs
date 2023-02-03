using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZetiAssignment.MVC.Models.ZetiApi
{
    public class GetVehiclesHistoryModel
    {
        public string vin { get;set;}
        public string licensePlate { get;set;}
        public string make { get;set;}
        public string model { get;set;}
        public VehiclesHistory state { get;set; }
    }

    public class VehiclesHistory
    {
        public double odometerInMeters { get; set; }
        public double speedInMph { get; set; }
        public DateTime asAt { get; set; }

    }
}
