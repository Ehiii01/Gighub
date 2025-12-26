using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;

           
            var isValid = DateTime.TryParseExact(
                Convert.ToString(value),
                formats: [ "hh:mm tt", "HH:mm", "h:mm tt" ],
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateTime);
            return isValid;
        }
    }
}
