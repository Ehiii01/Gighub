using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Attendance
    {
        public Gig Gig { get; set; }
        public ApplicationUser Attendee { get; set; }

     
        public int GigId { get; set; }
        public string AttendeeId { get; set; } 
    }
}
   //Attendance is a class that represents the relationship between a user and a gig.