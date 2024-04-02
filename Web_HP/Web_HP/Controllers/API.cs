using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using APIWeb_ISN.Models;
using Newtonsoft.Json;

namespace Web_HP.Controllers
{
    public sealed class API
    {
        private static readonly HttpClient client = new HttpClient();

        private API()
        {
            client.BaseAddress = new Uri("http://localhost:19199");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private static readonly object padlock = new object();
        private static API instance = null;

        public static API Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new API();
                    }
                    return instance;
                }
            }
        }

        public async Task<Utilisateur> GetUser(int id)
        {
            Utilisateur utilisateur = null;
            HttpResponseMessage response = client.GetAsync("api/utilisateurs/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                utilisateur = JsonConvert.DeserializeObject<Utilisateur>(resp);
            }
            return utilisateur;
        }

        public async Task<Utilisateur> GetUser(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return await GetUser(id);
            return null;
        }

        public async Task<Utilisateur> GetUser(string email, string pwd)
        {
            Utilisateur utilisateur = null;
            HttpResponseMessage response = client.GetAsync("api/utilisateurs/" + email + "/" + pwd).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                utilisateur = JsonConvert.DeserializeObject<Utilisateur>(resp);
            }
            return utilisateur;
        }
    }
}
