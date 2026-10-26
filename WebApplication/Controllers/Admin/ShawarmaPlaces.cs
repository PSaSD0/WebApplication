using Microsoft.AspNetCore.Mvc;
using WebApplication.Domain.Entities;

namespace WebApplication.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ShawarmaEdit(int id = 0)
        {
            ShawarmaPlace entity = id == default ? new ShawarmaPlace() : await _dataManager.ShawarmaPlaces.GetShawarmaPlaceByIdAsync(id) ?? new ShawarmaPlace();
            ViewBag.Districts = await _dataManager.Districts.GetDistrictsAsync();
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ShawarmaEdit(ShawarmaPlace entity, IFormFile? titleImage)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Districts = await _dataManager.Districts.GetDistrictsAsync();
                return View(entity);
            }

            if (titleImage != null)
            {
                entity.Photo = titleImage.FileName;
                await SaveImg(titleImage);
            }

            await _dataManager.ShawarmaPlaces.SaveShawarmaPlaceAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ShawarmaDelete(int id)
        {
            await _dataManager.ShawarmaPlaces.DeleteShawarmaPlaceAsync(id);
            return RedirectToAction("Index");
        }
    }
}