using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interface;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepo;
        public ClubController(IClubRepository clubRepo)
        {
            _clubRepo = clubRepo;
        }

        public async Task<IActionResult> Index()
        {
            var clubs = await _clubRepo.GetAll();
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var club = await _clubRepo.GetById(id);
            return View(club);
        }
    }
}
