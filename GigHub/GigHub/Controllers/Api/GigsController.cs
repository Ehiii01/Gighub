using GigHub.Data;
// using System.Data.Entity;
using GigHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GigHub.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GigsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete("cancel/{id}")]
        public IActionResult Cancel([FromRoute] int id)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            //var attendee = _context.Users.FirstOrDefault(a=>a.Id == userId);
            var gig = _context.Gigs
                .Include(g => g.Attendances).ThenInclude(a => a.Attendee)
                .SingleOrDefault(g => g.Id == id && g.ArtistId == userId);

            // if (gig == null)
            // {
            //     return NotFound();
            // }

            if (gig.IsCanceled)
            {
                return NotFound();
            }

            gig.cancel();

            _context.SaveChanges();

            return Ok();
        }
    }
}