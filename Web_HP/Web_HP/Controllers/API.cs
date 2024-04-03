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
            client.BaseAddress = new Uri("http://localhost:5084");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private static readonly object padlock = new object();
        private static API? instance = null;

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

        public async Task<Utilisateur> GetUtilisateur(int id)
        {
            Utilisateur? utilisateur = null;
            HttpResponseMessage response = client.GetAsync("api/utilisateurs/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                utilisateur = JsonConvert.DeserializeObject<Utilisateur>(resp);
            }
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return utilisateur;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }

        public async Task<Utilisateur?> GetUtilisateur(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return await GetUtilisateur(id);
            return null;
        }

        public async Task<Utilisateur> VerifyLogin(string email, string pwd)
        {
            Utilisateur? utilisateur = null;
            HttpResponseMessage response = client.GetAsync($"api/utilisateurs/{email}/{pwd}").Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                utilisateur = JsonConvert.DeserializeObject<Utilisateur>(resp);
            }
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
            return utilisateur;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
        }

    }
}
