using CargoRequestUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CargoRequestUI
{
    class DataService
    {
        HttpClient client = new HttpClient();
        public DataService() {
            client.BaseAddress = new Uri("https://localhost:7036/api/Main/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<CargoRequestDto>?> getCargoRequests()
        {
            var cargoRequests = new List<CargoRequestDto>();
            try
            {
                var response = await client.GetStringAsync("GetAllCargoRequests");
                cargoRequests = JsonConvert.DeserializeObject<List<CargoRequestDto>>(response);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return cargoRequests;
        }

        public async void saveCargoRequests(CargoRequestDto requestDto)
        {
            try
            {
                await client.PostAsJsonAsync("AddCargoRequest", requestDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void updateCargoRequests(int idReq, CargoRequestDto requestDto)
        {
            using StringContent jsonContent = new(
                JsonConvert.SerializeObject(requestDto),
                    Encoding.UTF8,
                    "application/json");

            try
            {

                await client.PatchAsync("UpdateCargoRequest/" + idReq, jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void deleteCargoRequests(int reqId)
        {
            try
            {
                await client.DeleteAsync("DeleteCargoRequest/" + reqId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<CargoRequestDto>?> searchCargoRequests(string searchString)
        {
            var cargoRequests = new List<CargoRequestDto>();
            try
            {
                var response = await client.GetStringAsync("Search/" + searchString);
                cargoRequests = JsonConvert.DeserializeObject<List<CargoRequestDto>>(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return cargoRequests;
        }
    }
}
