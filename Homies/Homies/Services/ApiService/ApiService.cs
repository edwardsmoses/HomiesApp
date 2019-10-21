using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Homies.Services.ApiService
{
    public class ApiService
    {
        public async Task<bool> RegisterUserAsync(string email, string password, string confirmPassword)
        {
            var registerModel = new Common.Models.RegisterModel()
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(registerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var registerUrl = $"{Common.ApiConstants.OnlineHomiesUrl}{Common.ApiConstants.HomiesApi}/Account/Register";

            var response = await httpClient.PostAsync(new Uri(registerUrl), content);
            return response.IsSuccessStatusCode;
        }

        public async Task<Common.Models.TokenResponse> GetTokenAsync(string email, string password)
        {
            var httpClient = new HttpClient();
            var content = new StringContent($"grant_type=password&username={email}&password={password}",
                Encoding.UTF8, "application/x-www-form-urlencoded");

            var repsonse = await httpClient.PostAsync($"{ApiConstants.OnlineHomiesUrl}/Token", content);

            var jsonResult = await repsonse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Common.Models.TokenResponse>(jsonResult);

            return result;
        }

        public async Task<List<Common.ApiModels.FoodModels.FoodApiModel>> GetAllFoodsAsync()
        {
            var httpClient = new HttpClient();

            //the Foods Repsonse from the Server
            var foodsResponse = await httpClient.GetStringAsync($"{ApiConstants.OnlineHomiesUrl}{ApiConstants.HomiesApi}/Foods");
            return JsonConvert.DeserializeObject<List<Common.ApiModels.FoodModels.FoodApiModel>>(foodsResponse);
        }

        public async Task<Common.ApiModels.FoodModels.FoodApiModel> GetFoodAsync(string id)
        {
            var httpClient = new HttpClient();

            var foodResponse = await httpClient.GetStringAsync($"{ApiConstants.OnlineHomiesUrl}{ApiConstants.HomiesApi}/Foods/{id}");
            return JsonConvert.DeserializeObject<Common.ApiModels.FoodModels.FoodApiModel>(foodResponse);
        }



    }
}
