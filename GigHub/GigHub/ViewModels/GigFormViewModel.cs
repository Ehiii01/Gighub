using GigHub.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public byte Genre { get; set; }

        [ValidateNever]
        public IEnumerable<Genre> Genres { get; set; }
        public DateTime GetDateTime()
        {
            var formatProvider = CultureInfo.InvariantCulture;


           var combinedDateTimeString = string.Format("{0} {1}", Date, Time);

            return DateTime.Parse(combinedDateTimeString, formatProvider);
        }
    }
}
