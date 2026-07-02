namespace EindoefeningDesignPatterns.Decorator
{
    public class Kerstboom:IKerstboom
    {
        public decimal Kost() => 30m;
        public string Print() => "Kerstboom: Kerstboom";
    }
}
