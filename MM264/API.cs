using Microsoft.Identity.Client;
using MM264.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MM264
{
    internal class API
    {
        //синглтон нужен для создания единственного экземпляра класса во всем проекте
        private static API _instance = new API();
        public static API Instance => _instance;

        public User AuthUser;

        private API()
        {
            Client = new HttpClient();
        }


        public readonly HttpClient Client;

        // Опции обработки json чтобы был нечувствителен к регистру
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public void SetupJWToken(string token)
        {
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        }

        public async Task<bool> Auth(string login,  string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.0.15:5000/auth/login");
            var json = JsonSerializer.Serialize(new { Login = login, Password = password });
            var content = new StringContent(json, null, "application/json");
            request.Content = content;
            var response = await Client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = JsonSerializer.Deserialize<AuthData>(await response.Content.ReadAsStringAsync(), options);
                SetupJWToken(result.token);
                AuthUser = result.user;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<VendingMachine>> GetVendingMachines()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://192.168.0.15:5000/api/vendingmachines");
            var response = await Client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<VendingMachine>? vendingMachines = JsonSerializer.Deserialize<List<VendingMachine>>(
                    await response.Content.ReadAsStringAsync(), options);
                return vendingMachines;
            }
            else
            {
                return null;
            }
        }
    }

    // Важный класс для приёма данных пользователя после авторизации
    public record AuthData(User user, string token);
}
