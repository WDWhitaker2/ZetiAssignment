using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZetiAssignment.MVC.Logic
{
    public class DBContext
    {

        public ICollection<Models.Customer> Customers = new List<Models.Customer>
        {
            new Models.Customer
            {
                Name = "Bob's Taxis",
                Rate = 0.207,
                Fleet = new List<Models.Vehicle>
                {
                    new Models.Vehicle{ NumberPlate = "CBDH 789"},
                    new Models.Vehicle{ NumberPlate = "86532 AZE"},
                }
            }
        };

    }
}
