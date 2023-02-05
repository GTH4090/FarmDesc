using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FarmDesc.Models;
using Newtonsoft.Json;

namespace FarmDesc.Classes
{
    public static class GetData
    {
        private static HttpClient HttpClient = new HttpClient();
        public static List<AirSensorsLogs> GetAirSensorsData()
        {
            List<AirSensorsLogs> strings= new List<AirSensorsLogs>();
            for(int i = 1; i <= 4; i++)
            {
                var res = HttpClient.GetAsync($"https://dt.miet.ru/ppo_it/api/temp_hum/{i}").Result;
                var item = JsonConvert.DeserializeObject<AirSensorsLogs>(res.Content.ReadAsStringAsync().Result);
                item.date= DateTime.Now;
                strings.Add(item);
                
            }
            return strings;
        }
        public static List<LandSensorLogs> GetLandSensorsData()
        {
            List<LandSensorLogs> strings = new List<LandSensorLogs>();
            for (int i = 1; i <= 6; i++)
            {
                var res = HttpClient.GetAsync($"https://dt.miet.ru/ppo_it/api/hum/{i}").Result;
                var item = JsonConvert.DeserializeObject<LandSensorLogs>(res.Content.ReadAsStringAsync().Result);
                item.date = DateTime.Now;
                strings.Add(item);

            }
            return strings;
        }

    }
}
