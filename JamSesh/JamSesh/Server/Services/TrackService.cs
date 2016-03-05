using JamSesh.Server.Services.Contracts;
using JamSesh69.Enum;
using JamSesh69.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace JamSesh.Server.Services
{
    public class TrackService : ITrackService
    {
        private readonly string clientID = ConfigurationManager.AppSettings["ClientId"];
        public TrackService()
        {

        }

        public IEnumerable<Song> GetSearchList(string query)
        {
            List<Song> songs = new List<Song>();
            string baseUrl = "http://api.soundcloud.com/";
            string urlParameters = "tracks?q=" + query + "&client_id=" + clientID;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    var dataObjects = response.Content.ReadAsAsync<IEnumerable<dynamic>>().Result;
                    foreach (var d in dataObjects)
                    {
                        var song = new Song(d.title.Value, Enums.SongType.Soundcloud, d.stream_url.Value);
                        songs.Add(song);
                    }
                }
            }

            return songs;
        }
    }
}