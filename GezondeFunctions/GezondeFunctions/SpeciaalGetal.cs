using System;
using System.Collections.Generic;
using System.Text;
using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;

namespace GezondeFunctions
{
    public class SpeciaalGetal
    {
        public required string Naam { get; set; }
        public decimal Waarde { get; set; }
    }
}
