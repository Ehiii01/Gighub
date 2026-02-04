using GigHub.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Dtos;

public class NotificationDto
{
    //public int Id { get; private set; }
    
    public DateTime DateTime { get; set; }
    
    public NotificationType NotificationType { get; set; }
    
    public DateTime? OriginalDateTime { get; set; }
    // [StringLength(255)] 
    // public string? Venue { get; set; }
    [StringLength(255)] 
    public string OriginalVenue { get; set; }

    public GigDto Gig { get; set; }




    public static NotificationDto GetNotificationResonse(Notification result)
    {

        GigDto gig = GigDto.GetGigResponse(result.Gig);


        var resultData = new NotificationDto
        {
            DateTime = result.DateTime,
            NotificationType = result.NotificationType,
            OriginalDateTime = result.OriginalDateTime,
            OriginalVenue = result.OriginalVenue,
            Gig = gig
        };

        return resultData;
    }
}


