using System.ComponentModel.DataAnnotations;

namespace Eindoefening.Attributes
{
    public class NoWhiteSpaceAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;
            var stringValue = value.ToString();
            return !string.IsNullOrWhiteSpace(stringValue);
        }
    }
}
