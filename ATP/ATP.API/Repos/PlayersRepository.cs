using ATP.API.Models;
using ATP.Models;
using Microsoft.EntityFrameworkCore;

namespace ATP.API.Repos
{
    public class PlayersRepository:IPlayersRepository
    {
        private readonly ATPDbContext context;
        public PlayersRepository(ATPDbContext ctx) { this.context = ctx; }
        public async Task<Player> GetPlayer(int id) => await context.Players.FirstOrDefaultAsync(p => p.PlayerId == id);

        public async Task<IEnumerable<Player>> GetPlayers() => await context.Players.OrderByDescending(p => p.Points).ToListAsync();

        public async Task<Player> UpdatePlayer(Player player)
        {
            var response = await context.Players.FirstOrDefaultAsync(p => p.PlayerId == player.PlayerId);
            if (response != null)
            {
                response.Points = player.Points;
                await context.SaveChangesAsync();
                return response;
            }
            return null;
        }

        public async Task<IEnumerable<Player>> GetPlayersOnOne() => await context.Players.Where(p => p.WeeksNumberOne > 0).OrderByDescending(p => p.WeeksNumberOne).ToListAsync();
    }
}
