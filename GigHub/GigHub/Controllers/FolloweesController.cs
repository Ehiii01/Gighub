using GigHub.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GigHub.Controllers;

public class FolloweesController : Controller
{
    private readonly ApplicationDbContext _context;
    
    public FolloweesController(ApplicationDbContext context)
    {
        _context = context;
    }
    [Authorize]
    //[HttpPost]
    public IActionResult Index()
    {
       var userName = User.Identity.Name;
       var follower = _context.Users.FirstOrDefault(u => u.UserName == userName);

        var artists = _context.Followings
           .Where(f => f.FollowerId == follower.Id)
           .Select(f => f.Followee)
           .ToList();
       return View(artists);
    }
}