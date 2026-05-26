namespace Scopes.Models
{
    public class MijnService : IService
    {
        public string Id { get; set; }
        public string Pad { get; set; }
        public MijnService()
        {
            Id = Guid.NewGuid().ToString();
            Pad = "init/";
        }
    }
}
