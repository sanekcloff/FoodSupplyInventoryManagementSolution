using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhoneControllerLib.Controllers.Abstraction
{
    public abstract class PhoneControllerBase
    {
        //Ff9-6qW-4mM-Cf2
        private const string ApiKey = "6g45wm5j3yjjcb5d835xqcu54o55fmu4ect13m8e"; // Замените на ваш API-ключ
        private const string ApiUrl = "https://api.unisender.com/ru/api/sendSms?format=json";
        public async static void Send()
        {
            string phoneNumber = "79281199576"; // Номер получателя в формате 7XXXXXXXXXX
            string message = "Привет! Это тестовое сообщение.";

            var response = await SendSms(phoneNumber, message);
            Debug.WriteLine(response);
        }
        private static async Task<string> SendSms(string phoneNumber, string message)
        {
            using (var httpClient = new HttpClient())
            {
                var json = $"{{\"api_key\":\"{ApiKey}\", \"phone\":\"{phoneNumber}\", \"message\":\"{message}\"}}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(ApiUrl, content);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
