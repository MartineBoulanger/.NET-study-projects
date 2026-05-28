using Microsoft.EntityFrameworkCore;

namespace Tuincentrum.Models
{
    public class SQLLeveranciersRepository:ILeveranciersRepository
    {
        private readonly MvctuinCentrumContext context;
        public SQLLeveranciersRepository(MvctuinCentrumContext context)
        {
            this.context = context;
        }

        public async Task<Leverancier> Add(Leverancier leverancier)
        {
            context.Leveranciers.Add(leverancier);
            await context.SaveChangesAsync();
            return leverancier;
            //throw new NotImplementedException();
        }

        public async Task<Leverancier?> Delete(int id)
        {
            Leverancier? leverancier = await context.Leveranciers.FindAsync(id);
            if (leverancier != null)
            {
                context.Leveranciers.Remove(leverancier);
                await context.SaveChangesAsync();
            }
            return leverancier;
            //throw new NotImplementedException();
        }

        public async Task<Leverancier?> GetLeverancier(int id)
        {
            return await context.Leveranciers.FindAsync(id);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Leverancier>> GetLeveranciers()
        {
            return await context.Leveranciers.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<Leverancier> Update(Leverancier gewijzigdeLeverancier)
        {
            context.Update(gewijzigdeLeverancier);
            await context.SaveChangesAsync();
            return gewijzigdeLeverancier;
            //throw new NotImplementedException();
        }
    }
}
