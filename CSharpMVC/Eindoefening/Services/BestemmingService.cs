using System.Text.Json;

namespace Eindoefening.Services
{
    public class BestemmingService
    {
        private const string SessionKey = "Bestemmingen";

        // DI voor session gebruik
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BestemmingService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<string> GetAll()
        {
            // Check of er session data is
            var sessionData = _httpContextAccessor?.HttpContext?.Session.GetString(SessionKey);
            if (sessionData == null) return new List<string>();

            // omzetten naar een lijst voor de view
            var bestemmingen = JsonSerializer.Deserialize<List<string>>(sessionData);
            if (bestemmingen == null) return new List<string>();

            return bestemmingen;
        }

        public void Remove(string bestemming)
        {
            if (!string.IsNullOrEmpty(bestemming))
            {
                var bestemmingen = GetAll();
                bestemmingen.Remove(bestemming);
                Opslaan(bestemmingen);
            }
        }

        public void Add(string bestemming)
        {
            if (!string.IsNullOrEmpty(bestemming))
            {             
                var bestemmingen = GetAll();
                bestemmingen.Add(bestemming);
                Opslaan(bestemmingen);
            }
        }

        public void Opslaan(List<string> bestemmingen)
        {
            // als lijst bestemmingen null is wordt hele session gecleared -- zie HomeController action ClearBestemmingen
            if (bestemmingen == null)
                _httpContextAccessor?.HttpContext?.Session.Clear();
            var sessionData = JsonSerializer.Serialize(bestemmingen);
            _httpContextAccessor?.HttpContext?.Session.SetString(SessionKey, sessionData);
        }
    }
}
