using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using RunGroopWebApp.ViewModels;

namespace RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {
  
        private readonly IClubRepository _clubrepository;
        private readonly IPhotoService _photoService;
        public ClubController(IClubRepository clubrepository, IPhotoService photoService)
        {
            _clubrepository = clubrepository;
            _photoService = photoService;

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
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClubController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateClubViewModel clubVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(clubVM.Image);


                var club = new Club
                {
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    Image = result.Url.ToString(),
                    Address = new Address
                    {
                        Street = clubVM.Address.Street,
                        City = clubVM.Address.City,
                        State = clubVM.Address.State,
                    }
                };
                _clubrepository.Add(club);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("","Photo Upload failed");
            }
           return View(clubVM);
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
