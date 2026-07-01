namespace EindoefeningDesignPatterns.Decorator
{
    public class Kerstboom:IKerstboom
    {
        public decimal Kostprijs() => 30m;
        public string Print() => "Kerstboom: Kerstboom";
    }
}
