using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;


namespace ZetiAssignment.MVC.Logic
{
    public class ZetiApiService
    {
        private string BaseUrl = "https://funczetiinterviewtest.azurewebsites.net";
        public ZetiApiService()
        {

        }


        public async Task<List<Models.ZetiApi.GetVehiclesModel>> GetVehicles()
        {
            var action = "/api/vehicles";
            return await CallApi <List<Models.ZetiApi.GetVehiclesModel>>(action);
        }

        public async Task<List<Models.ZetiApi.GetVehiclesHistoryModel>> GetVehiclesHistory(DateTime datetime)
        {
            var action = $"/api/vehicles/history/{datetime.ToString("yyyy-MM-ddTHH:mm:ss")}";
            return await CallApi<List<Models.ZetiApi.GetVehiclesHistoryModel>>(action);
        }


        private async Task<T> CallApi<T>(string action) where T:class
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(action);
                
                if (Res.IsSuccessStatusCode)
                {

                    var ObjResponse = Res.Content.ReadAsStringAsync().Result;
                    return JsonSerializer.Deserialize<T>(ObjResponse);

                }
                return default(T);
            }
        }


    }
}
