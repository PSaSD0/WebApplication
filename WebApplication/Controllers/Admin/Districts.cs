using Microsoft.AspNetCore.Mvc;
using WebApplication.Domain.Entities;

namespace WebApplication.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> DistrictEdit(int id = 0)
        {
            District entity = id == default ? new District() : await _dataManager.Districts.GetDistrictByIdAsync(id) ?? new District();
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> DistrictEdit(District entity)
        {
            if (!ModelState.IsValid) return View(entity);
            await _dataManager.Districts.SaveDistrictAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DistrictDelete(int id)
        {
            await _dataManager.Districts.DeleteDistrictAsync(id);
            return RedirectToAction("Index");
        }
    }
}