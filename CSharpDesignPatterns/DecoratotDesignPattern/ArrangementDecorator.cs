namespace DecoratorDesignPattern
{
    public abstract class ArrangementDecorator(IArrangement gedecoreerdeArrangement) : IArrangement
    {
        protected IArrangement GedecoreerdeArrangement { get; set; } = gedecoreerdeArrangement;
        public abstract string Taak { get; }
    }

    public class Bungalow : IArrangement
    {
        public string Taak => "kuis de bungalow";
    }

    public class MetBarbeque(IArrangement gedecoreerdeArrangement) : ArrangementDecorator(gedecoreerdeArrangement)
    {
        public override string Taak => base.GedecoreerdeArrangement.Taak + ", plaats een BBQ bij de bungalow";
    }

    public class MetFietsen(IArrangement gedecoreerdeArrangement) : ArrangementDecorator(gedecoreerdeArrangement)
    {
        public override string Taak => base.GedecoreerdeArrangement.Taak + ", plaats fietsen bij de bungalow";
    }
}
