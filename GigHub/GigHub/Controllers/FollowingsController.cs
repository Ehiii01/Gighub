using GigHub.Data;
using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Logging;

namespace GigHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowingsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public FollowingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Follow(FollowingDto dto)
        {
            var userName = User.Identity.Name;
            var followee = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (_context.Followings.Any(f => f.FolloweeId == userName && f.FolloweeId == dto.FolloweeId))
                return BadRequest("Following already exists");

            var following = new Following
            {
                FollowerId = followee.Id,
                FolloweeId = dto.FolloweeId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();
            return Ok();
        }
    }
}