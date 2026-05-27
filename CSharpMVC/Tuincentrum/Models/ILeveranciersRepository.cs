namespace Tuincentrum.Models
{
    public interface ILeveranciersRepository
    {
        Task<Leverancier?> GetLeverancier(int id);
        Task<IEnumerable<Leverancier>> GetLeveranciers();
        Task<Leverancier> Add(Leverancier leverancier);
        Task<Leverancier> Update(Leverancier gewijzigdeLeverancier);
        Task<Leverancier> Delete(int id);
    }
}
