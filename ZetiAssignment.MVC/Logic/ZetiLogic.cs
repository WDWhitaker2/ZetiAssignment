using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZetiAssignment.MVC.Models;

namespace ZetiAssignment.MVC.Logic
{
    public class ZetiLogic
    {

        private Logic.DBContext dbcontext;
        private Logic.ZetiApiService zetiApiService;
        public ZetiLogic()
        {
            dbcontext = new Logic.DBContext();
            zetiApiService = new Logic.ZetiApiService();
        }

        public async Task<BillViewModel> GetBillForPeriod(DateTime fromDate, DateTime toDate)
        {
            var model = new BillViewModel();

            var customer = dbcontext.Customers.FirstOrDefault();
            model.Customer = customer.Name;
            model.FromDate = fromDate;
            model.ToDate = fromDate;
            model.Items = new List<BillPerVehicle>();

            var fromResponse = zetiApiService.GetVehiclesHistory(fromDate);
            var toResponse = zetiApiService.GetVehiclesHistory(toDate);

            await Task.WhenAll(fromResponse, toResponse);

            foreach (var vehicle in customer.Fleet)
            {
                var item = new BillPerVehicle();
                item.NumberPlate = vehicle.NumberPlate;

                var fromState = fromResponse.Result.FirstOrDefault(a => a.licensePlate == item.NumberPlate).state;
                var toState = toResponse.Result.FirstOrDefault(a => a.licensePlate == item.NumberPlate).state;

                var totalDistanceInMeters = toState.odometerInMeters - fromState.odometerInMeters;

                item.Mileage = (double)totalDistanceInMeters / 1609;
                item.Cost =  Convert.ToDecimal(item.Mileage * customer.Rate);

                model.Items.Add(item);
            }

            model.TotalMileage = model.Items.Sum(a => a.Mileage);
            model.TotalCost = model.Items.Sum(a => a.Cost);

            return model;

        }
    }
}
