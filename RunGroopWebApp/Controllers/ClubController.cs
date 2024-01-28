using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {
  
        private readonly IClubRepository _clubrepository;
        public ClubController(IClubRepository clubrepository)
        {
            _clubrepository = clubrepository;
           
        }
        public async Task<IActionResult>Index()
        {
            IEnumerable<Club> clubs = await _clubrepository.GetAll();
            return View(clubs);
        }

        // GET: ClubController/Details/id
        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubrepository.GetByIdAsync(id);
            return View(club);
        }

        // GET: ClubController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClubController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClubController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClubController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClubController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClubController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
