namespace Countries.Server.Models
{
    public class Flag
    {
        public int Id { get; set; }
        public byte[] Image { get; set; } = [];
        public Country Country { get; set; }
    }
}
