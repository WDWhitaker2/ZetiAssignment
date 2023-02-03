using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZetiAssignment.MVC.Models
{
    public class BillViewModel
    {
        public string Customer { get; set; }
        public double TotalMileage { get; set; }
        public decimal TotalCost { get; set; }

        public List<BillPerVehicle> Items { get; set; }
        public DateTime ToDate { get; internal set; }
        public DateTime FromDate { get; internal set; }
    }

    public class BillPerVehicle
    {
        public string NumberPlate { get; set; }
        public double Mileage { get; set; }
        public decimal Cost { get; set; }
    }
}
