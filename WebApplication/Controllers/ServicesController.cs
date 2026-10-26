using Microsoft.AspNetCore.Mvc;
using WebApplication.Domain;
using WebApplication.Infrastructure;

namespace WebApplication.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager _dataManager;
        public ServicesController(DataManager dataManager) { _dataManager = dataManager; }

        public async Task<IActionResult> Index()
        {
            var entities = await _dataManager.ShawarmaPlaces.GetShawarmaPlacesAsync();
            return View(DtoHelper.ShawarmasToDto(entities));
        }

        public async Task<IActionResult> Show(int id)
        {
            var entity = await _dataManager.ShawarmaPlaces.GetShawarmaPlaceByIdAsync(id);
            if (entity == null) return NotFound();
            return View(DtoHelper.ShawarmaToDto(entity));
        }
    }
}