using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DataAccess.Service
{
    public class EmployeService
    {
        /// <summary>
        /// This is the URL of our web services
        /// </summary>
        private const string WebServiceUrl = "http://192.168.1.146/EnsiWS/api/Employes/";

        /// <summary>
        /// This method return the list of all employes
        /// </summary>
        /// <returns></returns>
        public async Task<List<Employe>> GetEmployeAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<Employe>>(json);

            return taskModels;
        }
        /// <summary>
        /// This method add an employe
        /// </summary>
        /// <param name="t">Employe</param>
        /// <returns></returns>
        public async Task<bool> PostEmployeAsync(Employe t)
        {
            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(t);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PostAsync(WebServiceUrl, httpContent);

            return result.IsSuccessStatusCode;
        }
        /// <summary>
        /// This method delete an emplye
        /// </summary>
        /// <param name="id">EmployeId</param>
        /// <param name="t">Employe</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id,Employe t)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(WebServiceUrl + id);

            return response.IsSuccessStatusCode;
        }
    }
}
