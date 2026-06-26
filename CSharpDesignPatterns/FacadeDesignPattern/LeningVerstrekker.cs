namespace FacadeDesignPattern
{
    public class LeningVerstrekker
    {
        public bool IsLeningGoedgekeurd(Persoon persoon)
        {
            return persoon.Beroepsinkomsten.MaandWedde > 2500 && persoon.Rekening.Saldo >= decimal.Zero && persoon.Leningen.Count == 0;
        }
    }
}
