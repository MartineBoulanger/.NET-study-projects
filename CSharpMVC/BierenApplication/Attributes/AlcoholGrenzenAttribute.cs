using System.ComponentModel.DataAnnotations;

namespace BierenApplication.Attributes
{
    public class AlcoholGrenzenAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
                return true;
            if (!(value is float))
                return false;
            var alcoholwaarde = (float)value;
            return ((alcoholwaarde < 15) && (alcoholwaarde > 0));
        }
    }
}
