using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ZetiAssignment.MVC.Models;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace ZetiAssignment.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Logic.ZetiLogic ZetiLogic;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ZetiLogic = new Logic.ZetiLogic();

        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new Models.Home.IndexViewModel();
            
            model.FromDate = new DateTime(2021, 02, 01, 00, 00, 00);
            model.ToDate = new DateTime(2021, 02, 28, 23, 59, 00);


            return View(model);


        }

        [HttpPost]
        public async Task<IActionResult> GetBillFile(Models.Home.IndexViewModel model)
        {
            var ZetiBill = await ZetiLogic.GetBillForPeriod(model.FromDate, model.ToDate);

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(ZetiBill, options);
            return ConvertStringToFile(json, $"Bill - {ZetiBill.Customer}.json");
        }

        private FileContentResult ConvertStringToFile(string data, string fileName)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
            var output = new FileContentResult(bytes, "application/octet-stream");
            output.FileDownloadName = fileName;
            return output;

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
