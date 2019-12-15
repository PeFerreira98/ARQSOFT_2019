using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GorgeousFood.Gateway.API.DTOs;
using GorgeousFood.Gateway.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GorgeousFood.Gateway.API.Controllers
{
    [Route("redirect")]
    [ApiController]
    public class StuffController : ControllerBase
    {
        private string mealItemAPI = "https://gorgeousfoodmealitemapi.azurewebsites.net/mealitem";
        private string mealAPI = "https://gorgeousfoodmealapi.azurewebsites.net/meal";
        private string pointofsaleAPI = "https://gorgeousfoodpointofsaleapi.azurewebsites.net/pointofsale";

        // GET: Stuff
        public async Task<IActionResult> GetGroupedMealItems()
        {
            string fullUrl1 = mealItemAPI + "/grouped";

            var groupedMealList = new List<GroupedMealItemOutputDTO>();

            HttpClientHandler httpClientHandler = new HttpClientHandler();

            using (HttpClient httpClient = new HttpClient(httpClientHandler))
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.GetAsync(fullUrl1);
                string content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                    throw new Exception("Response contained empty body...");
                
                var s1 = JsonConvert.DeserializeObject<IEnumerable<GroupedMealItem>>(content);

                foreach (var item in s1)
                {
                    HttpResponseMessage response2 = await httpClient.GetAsync(mealAPI + "/" + item.MealID + "/description");
                    string content2 = await response2.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(content2))
                        throw new Exception("Response contained empty body...");

                    var s2 = JsonConvert.DeserializeObject<string>(content2);



                    HttpResponseMessage response3 = await httpClient.GetAsync(pointofsaleAPI + "/" + item.PointOfSaleID + "/description");
                    string content3 = await response3.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(content3))
                        throw new Exception("Response contained empty body...");

                    var s3 = JsonConvert.DeserializeObject<string>(content3);

                    groupedMealList.Add(new GroupedMealItemOutputDTO(item.PointOfSaleID, s3, item.MealID, s2, item.ProductionDate, item.ExpirationDate, item.Quantity));
                }

                return (IActionResult)Ok(groupedMealList);
            }
        }

    }
}