using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Domain;

namespace WebApplication.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public partial class AdminController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            _dataManager = dataManager;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Districts = await _dataManager.Districts.GetDistrictsAsync();
            ViewBag.ShawarmaPlaces = await _dataManager.ShawarmaPlaces.GetShawarmaPlacesAsync();
            ViewBag.Title = "Панель администратора";
            return View();
        }

        private async Task<string> SaveImg(IFormFile file)
        {
            string path = Path.Combine(_hostEnvironment.WebRootPath, "img", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return file.FileName;
        }
    }
}