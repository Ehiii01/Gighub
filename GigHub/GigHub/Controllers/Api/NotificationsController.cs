using AutoMapper;
using GigHub.Data;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GigHub.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private ApplicationDbContext _context;
        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<NotificationDto>GetNewNotifications()
        {
             var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Include(n => n.Notification)
                 .ThenInclude(n => n.Gig.Artist)
                 .Include(n => n.Notification)
                 .ThenInclude(n => n.Gig.Genre)
                .Select(un => un.Notification)
                .ToList();

            var result = notifications.Select(n => NotificationDto.GetNotificationResonse(n));

            return result;



            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<ApplicationUser, UserDto>();
            //    cfg.CreateMap<Gig, GigDto>();
            //    cfg.CreateMap<UserNotification, NotificationDto>();
            //});

            //return notifications.Select(Mapper.Map<UserNotification, NotificationDto>);

            // Mapper.CreateMap<ApplicationUser, UserDto>();
            // Mapper.CreateMap<Gig, GigDto>();
            // Mapper.CreateMap<UserNotification, NotificationDto>();

            // return notifications.Select(un => new NotificationDto()
            // {
            //     DateTime = un.Notification. DateTime,
            //     Gig =  new GigDto
            //     {
            //         Artist = new UserDto
            //         {
            //             Id = un.Notification.Gig.Artist.Id,
            //             Name = un.Notification.Gig.Artist.Name
            //         },
            //         DateTime = un.Notification.DateTime,
            //         Id = un.Notification.Gig.Id,
            //         IsCancelled = un.Notification.Gig.IsCanceled,
            //         Venue = un.Notification.Gig.Venue,
            //     },
            //     OriginalDateTime =  un.Notification.OriginalDateTime,
            //     OriginalVenue =   un.Notification.OriginalVenue,
            //     NotificationType = un.Notification.NotificationType
            // });
        }
    }
}

