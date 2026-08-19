using System.ComponentModel.DataAnnotations;

namespace BlazorAuto.Client.Validators
{
    public class GeboortedatumValidator:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            if (!(value is DateTime))
                return false;
            return ((DateTime)value) < DateTime.Today;
        }
    }
}
