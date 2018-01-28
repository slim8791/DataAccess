using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using Newtonsoft.Json;

namespace DataAccess.Service
{
    public class EmployeService
    {
        private const string WebServiceUrl = "http://192.168.1.146/EnsiWS/api/Employes/";
        public async Task<List<Employe>> GetEmployeAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(WebServiceUrl);

            var taskModels = JsonConvert.DeserializeObject<List<Employe>>(json);

            return taskModels;
        }
    }
}
