using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interface;

namespace RunGroupWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepo;
        public RaceController(IRaceRepository raceRepo)
        {
            _raceRepo = raceRepo;
        }
        public async Task<IActionResult> Index()
        {
            var races = await _raceRepo.GetAll();
            return View(races);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var race = await _raceRepo.GetById(id);
            return View(race);
        }
    }
}
