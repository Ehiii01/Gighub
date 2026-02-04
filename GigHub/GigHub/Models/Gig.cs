using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models;

public class Gig
{
    public int Id { get; set; }
    public bool IsCanceled { get; private set; }
    public ApplicationUser Artist { get; set; }
    [Required] public string ArtistId { get; set; }
    public DateTime DateTime { get; set; }
    [Required] [StringLength(255)] public string Venue { get; set; }
    public Genre Genre { get; set; }
    [Required] public byte GenreId { get; set; }
    public ICollection<Attendance> Attendances { get; }

    public Gig()
    {
        Attendances = new Collection<Attendance>();
    }

    public void cancel()
    {
        IsCanceled = true;
        var notification = Notification.GigCancelled(this);

        // var attendees = _context.Attendances
        //     .Where(a => a.GigId == gig.Id)
        //     .Select(a => a.Attendee)
        //     .ToList();
        foreach (var attendee in Attendances.Select(a => a.Attendee)) attendee.Notify(notification);
    }

    public void Modify(DateTime dateTime, string venue, byte genre)
    {
        var notification = Notification.GigUpdated(this, DateTime, Venue);
        // notification.OriginalDateTime = DateTime;
        // notification.Venue = venue;
        Venue = venue;
        DateTime = dateTime;
        GenreId = genre;
        foreach (var attendee in Attendances.Select(a => a.Attendee)) attendee.Notify(notification);
    }
}