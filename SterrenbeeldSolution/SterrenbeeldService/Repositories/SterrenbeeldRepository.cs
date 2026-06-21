using Microsoft.EntityFrameworkCore;

namespace SterrenbeeldService.Repositories
{
    public class SterrenbeeldRepository(SterrenbeeldContext context):ISterrenbeeldRepository
    {
        public async Task<List<Sterrenbeeld>> GetAllAsync() => await context.Sterrenbeelden.AsNoTracking().ToListAsync();

        public async Task<Sterrenbeeld?> GetSterrenbeeldAsync(int maand, int dag)
        {
            var sterrenbeelden = await GetAllAsync();
            foreach (var s in sterrenbeelden)
            {
                bool inStartMaand = maand == s.StartMaand && dag >= s.StartDag;
                bool inEindMaand = maand == s.EindMaand && dag <= s.EindDag;

                if (s.StartMaand > s.EindMaand)
                {
                    bool inTussenLiggendeMaand = maand > s.StartMaand || maand < s.EindMaand;
                    if (inStartMaand || inTussenLiggendeMaand || inEindMaand)
                        return s;
                }
                else
                {
                    bool inTussenliggendeMaand = maand > s.StartMaand && maand < s.EindMaand;
                    if (inStartMaand || inTussenliggendeMaand || inEindMaand)
                        return s;
                }
            }
            return null;
        }
    }
}
