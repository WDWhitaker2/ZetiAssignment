using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZetiAssignment.MVC.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public List<Vehicle> Fleet { get; set; }
        public double Rate { get; set; }
    }
}
