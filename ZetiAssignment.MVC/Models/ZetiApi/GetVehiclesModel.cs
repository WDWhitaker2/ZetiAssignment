using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZetiAssignment.MVC.Models.ZetiApi
{
    public class GetVehiclesModel
    {
        public string vin { get; set; }
        public string licensePlate { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string state { get; set; }
    }
}
