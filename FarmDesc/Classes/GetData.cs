using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FarmDesc.Models;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using static FarmDesc.Classes.Helper;

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

            try
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
            catch (Exception ex)
            {
                Error(ex.Message);
                return new List<LandSensorLogs>();
            }
            
        }
        public static bool WindowState(int state)
        {

            try
            {
                string updateurl = $"https://dt.miet.ru/ppo_it/api/fork_drive?state={state}";
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), updateurl);
                var response = HttpClient.SendAsync(request);
                return response.Result.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return false;
            }
            
        }
        public static bool HumState(int state)
        {

            try
            {
                string updateurl = $"https://dt.miet.ru/ppo_it/api/total_hum?state={state}";
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), updateurl);
                var response = HttpClient.SendAsync(request);
                return response.Result.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return false;
            }

        }


        public static bool WateringState(int state, int id)
        {

            try
            {
                string updateurl = $"https://dt.miet.ru/ppo_it/api/total_hum?state={state},?id={id}";
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), updateurl);
                var response = HttpClient.SendAsync(request);
                return response.Result.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return false;
            }

        }

    }
}
