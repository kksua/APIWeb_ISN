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
        // HttpClient pour effectuer les requêtes HTTP
        private static readonly HttpClient client = new HttpClient();

        private API()
        {
            // Configuration de l'adresse de base de l'API
            client.BaseAddress = new Uri("http://localhost:5084");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private static readonly object padlock = new object();
        // Instance unique de la classe API
        private static API? instance = null;

        // Propriété publique statique pour accéder à l'instance unique de la classe
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

        // Méthode pour récupérer un utilisateur par son ID
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

        // Méthode pour récupérer un utilisateur par son ID en tant que chaîne de caractères
        public async Task<Utilisateur?> GetUtilisateur(string idString)
        {
            int id;
            if (int.TryParse(idString, out id))
                return await GetUtilisateur(id);
            return null;
        }
        // Méthode pour vérifier la connexion d'un utilisateur
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

        // Méthode pour récupérer la liste des albums
        public async Task<List<Album>> GetAlbums()
        {
            List<Album> albums = null;
            HttpResponseMessage response = await client.GetAsync("api/albums");
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                albums = JsonConvert.DeserializeObject<List<Album>>(resp);
            }
            return albums;
        }

        // Méthode pour récupérer un album par son ID
        public async Task<Album> GetAlbum(int id)
        {
            Album album = null;
            HttpResponseMessage response = await client.GetAsync($"api/albums/{id}");
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                album = JsonConvert.DeserializeObject<Album>(resp);
            }
            return album;
        }
    }
}
