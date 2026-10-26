using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Domain;
using WebApplication.Domain.Entities;
using WebApplication.Infrastructure;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ServicesController(DataManager dataManager, UserManager<IdentityUser> userManager)
        {
            _dataManager = dataManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var entities = await _dataManager.ShawarmaPlaces.GetShawarmaPlacesAsync();
            return View(DtoHelper.ShawarmasToDto(entities));
        }

        public async Task<IActionResult> Show(int id)
        {
            var entity = await _dataManager.ShawarmaPlaces.GetShawarmaPlaceByIdAsync(id);
            if (entity == null) return NotFound();

            var reviews = await _dataManager.Reviews.GetReviewsByShawarmaIdAsync(id);
            ViewBag.Reviews = reviews;

            return View(DtoHelper.ShawarmaToDto(entity));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddReview(AddReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Show", new { id = model.ShawarmaPlaceId });
            }

            var review = new Review
            {
                ShawarmaPlaceId = model.ShawarmaPlaceId,
                Text = model.Text,
                Rating = model.Rating,
                UserId = _userManager.GetUserId(User)
            };

            await _dataManager.Reviews.SaveReviewAsync(review);
            return RedirectToAction("Show", new { id = model.ShawarmaPlaceId });
        }
    }
}