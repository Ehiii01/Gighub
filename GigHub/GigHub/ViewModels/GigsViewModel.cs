using GigHub.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GigHub.ViewModels;

public class GigsViewModel
{
    public GigsViewModel()
    {
        UpcomingGigs = new List<Gig>();
    }
    public IEnumerable<Gig> UpcomingGigs { get; set; }
    public bool ShowActions { get; set; }
    [ValidateNever]
    public string Heading { get; set; }
}