using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ThePlug.Models;
using Xamarin.Essentials;

namespace ThePlug.Services
{
    public class ApiAdminService
    {
        public static async Task<List<Order>> GetPendingOrders()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/orders/PendingOrders");
            return JsonConvert.DeserializeObject<List<Order>>(response);
        }
        public static async Task<List<Order>> GetCompletedOrders()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/orders/CompletedOrders/");
            return JsonConvert.DeserializeObject<List<Order>>(response);
        }
        public static async Task<List<Complaint>> GetComplaints()
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Complaints/");
            return JsonConvert.DeserializeObject<List<Complaint>>(response);
        }
        public static async Task<bool> MarkOrderComplete(int orderId, Order order)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var json = JsonConvert.SerializeObject(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(AppSettings.ApiUrl + "api/orders/MarkOrderComplete/"+ orderId, content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }
        public static async Task<bool> AddProduct(Product product)
        {
            await TokenValidator.CheckTokenValidity();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/Products/Post", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }
    }
}
