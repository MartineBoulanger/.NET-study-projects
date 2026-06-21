namespace SterrenbeeldService.Repositories
{
    public interface ISterrenbeeldRepository
    {
        Task<List<Sterrenbeeld>> GetAllAsync();
        Task<Sterrenbeeld?> GetSterrenbeeldAsync(int maand, int dag);
    }
}
