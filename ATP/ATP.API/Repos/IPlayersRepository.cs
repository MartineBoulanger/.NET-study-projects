using ATP.Models;

namespace ATP.API.Repos
{
    public interface IPlayersRepository
    {
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player> GetPlayer(int id);
        Task<Player> UpdatePlayer(Player player);
        Task<IEnumerable<Player>> GetPlayersOnOne();
    }
}
