using GigHub.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            DateTime dateTime;

            var isValid = DateTime.TryParseExact(
                Convert.ToString(value),
               formats:["d MMMM yyyy","dd MMM yyyy", "d MMM yyyy"],
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateTime);
            return isValid && dateTime > DateTime.Now;
        }
    }
}
