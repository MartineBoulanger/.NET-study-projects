using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterDesignPattern
{
    public class SpellingsControleAdapter
    {
        public string Taal { get; set; } = null!;
        public string Tekst { get; set; } = null!;
        public string[] Fouten { get; set; } = null!;

        public void ControleerSpelling()
        {
            NieuweSpellingsControle controle = new(Taal, Tekst);
            Fouten = controle.Controleer();
        }
        public int AantalFouten() => Fouten.Length;
        public string Fout(int index) => Fouten[index];
    }
}
