using System.ComponentModel.DataAnnotations;

namespace GigHub.Models;

public class Notification
{
    public int Id { get; private set; }
    
    public DateTime DateTime { get; private set; }
    
    public NotificationType NotificationType { get; private set; }
    
    public DateTime? OriginalDateTime { get; private set; }

    [StringLength(255)] 
    public string OriginalVenue { get; private set; } 
    
    [Required]
    public Gig Gig { get; private set; }

    protected Notification()
    {
        
    }

    private Notification(NotificationType notificationType, Gig gig) 
    {
        if (gig == null)
            throw new ArgumentNullException(nameof(gig));
        
        NotificationType = notificationType;
        Gig = gig;
       DateTime = DateTime.Now;
       OriginalVenue = gig.Venue;
    }

    public static Notification GigCreated(Gig gig)
    {
        return new Notification(NotificationType.GigCreated, gig);
    }
 
    public static Notification GigUpdated(Gig newGig, DateTime originalDateTime, string originalVenue )
    {
        var notification = new Notification(NotificationType.GigUpdated, newGig);
        notification.OriginalDateTime = originalDateTime;
        notification.OriginalVenue = originalVenue;
        return notification;
    }

    public static Notification GigCancelled(Gig gig)
    {
        return new Notification(NotificationType.GigCancelled, gig);
    }
}