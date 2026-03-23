namespace BoekBoekenrek
{
    public interface IVoorwerp
    {
        public string Gegevens();
        // moest een property zijn, niet een method! - medium fout
        // zorg ervoor dat je de opdracht goed leest en goed volgt!
        //public decimal Winst(); 
        public decimal Winst { get; }
    }
}
