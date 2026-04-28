using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using SevenTV.Types.Rest;

namespace SevenTV.Clients
{
    public class RestClient
    {
        public const string _baseurl = "https://7tv.io/v3";
        private HttpClient _client;

        internal RestClient(string? token = null, string? userAgent = null)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.UserAgent.ParseAdd(string.IsNullOrEmpty(userAgent) ? "SevenTV-lib/1.0.0" : userAgent);

            if (!string.IsNullOrEmpty(token))
                _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
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

        /// <summary>
        /// Sends a presence update to the 7TV API, which can be used to update the user's cosmetics.
        /// This is typically used to trigger the display of user cosmetics on specific platforms
        /// </summary>
        /// <param name="userId">The unique 7TV user identifier.</param>
        /// <param name="targetPlatform">The platform where the user is currently active.</param>
        /// <param name="targetPlatformId">The platform-specific ID of the channel/room the user is in.</param>
        /// <param name="passive">If <see langword="true"/> it will emit presence data to the current user only. Defaults to <see langword="false"/>.</param>
        /// <param name="sessionId">An optional eventapi session ID, needed for passive presences.</param>
        /// <returns><see langword="true"/> if the presence was successfully updated; otherwise, <see langword="false"/>.</returns>
        public async Task<bool> SendPresence(string userId, ConnectionType targetPlatform, string targetPlatformId, bool passive = false, string? sessionId = null)
        {
            string finalurl = _baseurl + $"/users/{userId}/presences";
            var request = new HttpRequestMessage(HttpMethod.Post, $"{finalurl}");

            var content = new StringContent($@"
{{
    ""kind"": 1,
    ""passive"": {(passive ? "true" : "false")},
    {(!string.IsNullOrEmpty(sessionId) ? $"\"session_id\": \"{sessionId}\"," : "")}
    ""data"": {{
        ""platform"": ""{targetPlatform.ToString().ToUpper()}"",
        ""id"": ""{targetPlatformId}""
    }}
}}", null, "application/json");
            request.Content = content;

            var response = await _client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        private async Task<string?> GetJSON(Uri uri)
        {
            string timeFix = uri.ToString().Contains("?") ? "&time" : "?time";
            var request = new HttpRequestMessage(HttpMethod.Get, $"{uri}{timeFix}={DateTime.Now}");
            var response = await _client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}