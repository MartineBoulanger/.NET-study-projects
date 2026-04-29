using System.Text.Json;

namespace Eindoefening.Services
{
    public class BestemmingService
    {
        private const string SessionKey = "Bestemmingen";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BestemmingService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<string> GetAll()
        {
            var sessionData = _httpContextAccessor?.HttpContext?.Session.GetString(SessionKey);
            if (sessionData == null) return new List<string>();

            var bestemmingen = JsonSerializer.Deserialize<List<string>>(sessionData);
            if (bestemmingen == null) return new List<string>();

            return bestemmingen;
        }

        public void Remove(string bestemming)
        {
            var bestemmingen = GetAll();
            bestemmingen.Remove(bestemming);
            Opslaan(bestemmingen);
        }

        public void Add(string bestemming)
        {
            var bestemmingen = GetAll();
            bestemmingen.Add(bestemming);
            Opslaan(bestemmingen);
        }

        public void Opslaan(List<string> lijst)
        {
            // als lijst null is wordt hele session gecleared -- zie HomController action ClearBestemmingen
            if (lijst == null)
                _httpContextAccessor?.HttpContext?.Session.Clear();
            var sessionData = JsonSerializer.Serialize(lijst);
            _httpContextAccessor?.HttpContext?.Session.SetString(SessionKey, sessionData);
        }
    }
}
