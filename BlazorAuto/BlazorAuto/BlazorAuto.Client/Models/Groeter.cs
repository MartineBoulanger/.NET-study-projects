using Microsoft.JSInterop;

namespace BlazorAuto.Client.Models
{
    public class Groeter
    {
        public Groeter(string naam)
        {
            Naam = naam;
        }

        public string Naam { get; set; }

        [JSInvokable]
        public string Begroet() => $"Hallo, {Naam}!";
    }
}
