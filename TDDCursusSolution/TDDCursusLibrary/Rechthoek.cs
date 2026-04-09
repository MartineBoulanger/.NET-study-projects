namespace TDDCursusLibrary
{
    public class Rechthoek(int lengte, int breedte)
    {
        public int Omtrek() => 2 * (lengte + breedte);
        public int Oppervlakte() => lengte * breedte;
    }
}
