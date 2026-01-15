using GigHub.Models;

namespace GigHub.ViewModels;

public class GigsViewModel
{
    public GigsViewModel()
    {
        UpcomingGigs = new List<Gig>();
    }
    public IEnumerable<Gig> UpcomingGigs { get; set; }
    public bool ShowActions { get; set; }
    public string Heading { get; set; }
}