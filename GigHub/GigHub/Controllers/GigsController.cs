using GigHub.Data;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController(ApplicationDbContext context)
        {
            _context = context;
        } 

        [Authorize]
        public IActionResult Mine()
        {
            var userName = User.Identity.Name;
            var attendee = _context.Users.FirstOrDefault(a => a.UserName == userName);

            var gigs = _context.Gigs
                .Where(g => g.ArtistId == attendee.Id && g.DateTime > DateTime.Now)
                .Include(g => g.Genre)
                .ToList();

            // var viewModel = new GigsViewModel()
            // {
            //     UpcomingGigs = gigs,c
            //     ShowActions = User.Identity.IsAuthenticated,
            //     Heading = "My Gigs"
            // };

            return View(gigs);
        }

        [Authorize]
        public IActionResult Attending()
        { 
            var userName = User.Identity.Name;
            var attendee = _context.Users.FirstOrDefault(a => a.UserName == userName);


            //var gigs = _context.Attendances.Where(a => a.AttendeeId == currentlyLoggedInUser.Id).Select(a => a.Gig)
            //    .Include(g => g.Artist).Include(g => g.Genre).ToList();


            var gigs = _context.Attendances.Include(a => a.Gig).ThenInclude(g => g.Artist).Include(a => a.Gig)
                .ThenInclude(a => a.Genre)
                .Where(a => a.AttendeeId == attendee.Id).Select(a => a.Gig).ToList();


            var viewModel = new GigsViewModel()
            {
                UpcomingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Gigs I'm Attending"
            };
            return View("Gigs", viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View("GigForm",viewModel);
        }
       
        [Authorize]
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("GigForm", viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();
            return RedirectToAction("Mine", "Gigs");
        }
        
        [Authorize]
        [HttpPost]  
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("GigForm", viewModel);
            }

            var userName = User.Identity.Name;
            var attendee =  _context
                .Users
                .FirstOrDefault(a => a.UserName == userName);
            
            var gig = _context.Gigs.Single(g => g.Id == viewModel.Id && g.ArtistId == attendee.Id);
            gig.Venue = viewModel.Venue;
            gig.DateTime = viewModel.GetDateTime();
            gig.GenreId = viewModel.Genre;
            
            //_context.Gigs.Update(gig);
            _context.SaveChanges();
            return RedirectToAction("Mine", "Gigs");
        }

        public ActionResult Edit(int id)
        {
            var userName = User.Identity.Name;
            var attendee = _context.Users.FirstOrDefault(a => a.UserName == userName);
            var gig = _context.Gigs.Single(g=>g.Id == id && g.ArtistId == attendee.Id);
            
            var viewModel = new GigFormViewModel    
            {
                Heading = "Edit a Gig",
                Id = gig.Id,
                Genres = _context.Genres.ToList(),
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Genre = gig.GenreId,
                Venue = gig.Venue
            };
            return View("GigForm",viewModel);
        }

    }
}