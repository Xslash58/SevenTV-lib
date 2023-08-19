using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using SevenTV.Types;
using System.Net.Http.Headers;

namespace SevenTV
{
    public class SevenTV
    {
        public const string _baseurl = "https://7tv.io/v3";
        private HttpClient _client;

        public SevenTV()
        {
            _client = new HttpClient();
        }

        public async Task<EmoteSet?> GetEmoteSet(string ID)
        {
            string finalurl = _baseurl + $"/emote-sets/{ID}";
            Uri uri = new Uri(finalurl);

            var responseBody = await GetJSON(uri).ConfigureAwait(false);

            if (responseBody == null)
                return null;

            EmoteSet? emoteset = new EmoteSet();
            emoteset = JsonConvert.DeserializeObject<EmoteSet>(responseBody);

            return emoteset;
        }
        public async Task<Emote?> GetEmote(string ID)
        {
            string finalurl = _baseurl + $"/emotes/{ID}";
            Uri uri = new Uri(finalurl);

            var responseBody = await GetJSON(uri).ConfigureAwait(false);

            if (responseBody == null)
                return null;

            Emote? emote = new Emote();
            emote = JsonConvert.DeserializeObject<Emote>(responseBody);

            return emote;
        }
        public async Task<Connection?> GetConnection(ConnectionType type, string ID)
        {
            string finalurl = _baseurl + $"/users/{type}/{ID}";
            Uri uri = new Uri(finalurl);

            var responseBody = await GetJSON(uri).ConfigureAwait(false);

            if (responseBody == null)
                return null;

            Connection? conn = new Connection();
            conn = JsonConvert.DeserializeObject<Connection>(responseBody);

            return conn;
        }
        public async Task<TwitchUser[]?> GetTwitchUser(string name)
        {
            string finalurl = $"https://api.ivr.fi/v2/twitch/user?login={name}";
            Uri uri = new Uri(finalurl); 
            var responseBody = await GetJSON(uri).ConfigureAwait(false);

            if (responseBody == null)
                return null;

            TwitchUser[]? ttvUser;
            ttvUser = JsonConvert.DeserializeObject<TwitchUser[]>(responseBody);

            return ttvUser;
        }
        public async Task<User?> GetUser(string ID)
        {
            string finalurl = _baseurl + $"/users/{ID}";
            Uri uri = new Uri(finalurl);

            var responseBody = await GetJSON(uri).ConfigureAwait(false);

            if (responseBody == null)
                return null;

            User? user = new User();
            user = JsonConvert.DeserializeObject<User>(responseBody);

            return user;
        }

        private async Task<string?> GetJSON(Uri uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{uri}?time={DateTime.Now}");
            var response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}