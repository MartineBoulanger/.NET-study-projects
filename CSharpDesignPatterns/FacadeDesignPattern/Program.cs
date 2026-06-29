using FacadeDesignPattern;

Persoon persoon = new Persoon(new Beroepsinkomsten(3000m), new Rekening());
if (persoon.Beroepsinkomsten.MaandWedde > 2500 && persoon.Rekening.Saldo >= decimal.Zero && persoon.Leningen.Count == 0)
    Console.WriteLine("Lening goedgekeurd");
else
    Console.WriteLine("Lening afgekeurd");
Console.WriteLine();
LeningVerstrekker verstrekker = new LeningVerstrekker();
if (verstrekker.IsLeningGoedgekeurd(persoon))
    Console.WriteLine("Lening goedgekeurd");
else
    Console.WriteLine("Lening afgekeurd");
Console.WriteLine();
// oefening
Stereoketen keten = new();
keten.Start();
keten.StartRadio();
keten.StartCDSpeler();
keten.Stop();
