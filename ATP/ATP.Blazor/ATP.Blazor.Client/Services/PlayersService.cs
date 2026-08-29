using ATP.Models;
using System.Net;
using System.Net.Http.Json;

namespace ATP.Blazor.Client.Services
{
    public class PlayersService
    {
        private readonly HttpClient httpClient;
        public PlayersService(HttpClient client) { this.httpClient = client; }

        public async Task<IEnumerable<Player>> GetPlayersAsync()
        {
            var response = await httpClient.GetAsync("players");
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return await response.Content.ReadFromJsonAsync<List<Player>>() ?? [];
                default:
                    return [];
            }
        }

        public async Task<Player> GetPlayerAsync(int id)
        {
            var response = await httpClient.GetAsync($"players/{id}");
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return await response.Content.ReadFromJsonAsync<Player>();
                default:
                    return null;
            }
        }

        public async Task<Player> UpdatePlayerAsync(Player player)
        {
            HttpResponseMessage message = await httpClient.PutAsJsonAsync<Player>($"players/{player.PlayerId}", player);
            if (message.IsSuccessStatusCode)
                return player;
            else
                return null;
        }

        public async Task<IEnumerable<Player>> GetPlayersOnOneAsync()
        {
            var response = await httpClient.GetAsync("playersonone");
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return await response.Content.ReadFromJsonAsync<List<Player>>() ?? [];
                default:
                    return [];
            }
        }
    }
}
