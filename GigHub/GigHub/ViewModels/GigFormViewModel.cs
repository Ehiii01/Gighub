using GigHub.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq.Expressions;
using GigHub.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public int Id { get; set; }
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

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<GigsController, ActionResult>> update =
                    (c => c.Update(this));
                
                Expression<Func<GigsController, ActionResult>> create =
                    (c => c.Create(this));
                
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
                // return (Id !=0) ? "Update" : "Create";
            }
        }


        public DateTime GetDateTime()
        {
            var formatProvider = CultureInfo.InvariantCulture;


           var combinedDateTimeString = string.Format("{0} {1}", Date, Time);

            return DateTime.Parse(combinedDateTimeString, formatProvider);
        }
    }
}
