using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Domain;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DataManager _dataManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, DataManager dataManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dataManager = dataManager; // Сохраняем
        }

        // --- ВХОД ---
        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl)
        {
            await _signInManager.SignOutAsync();
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl ?? "";
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);
            if (result.Succeeded)
            {
                // Если вошел админ, кидаем в админку, если обычный юзер - на главную
                if (User.IsInRole("admin")) return RedirectToAction("Index", "Admin");
                return Redirect(returnUrl ?? "/");
            }

            ModelState.AddModelError(string.Empty, "Неверный логин или пароль.");
            return View(model);
        }

        // --- РЕГИСТРАЦИЯ ---
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Создаем нового пользователя
            var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                // Сразу авторизуем после регистрации
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            // Если есть ошибки (например, такой логин уже существует)
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        // --- ВЫХОД ---
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // --- ОШИБКА ДОСТУПА ---
        public IActionResult AccessDenied()
        {
            return View();
        }

        // --- ПРОФИЛЬ ---
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId!);
            var userReviews = await _dataManager.Reviews.GetReviewsByUserIdAsync(userId!);

            var model = new ProfileViewModel
            {
                UserName = user?.UserName,
                Email = user?.Email,
                Reviews = userReviews.Select(r => new ReviewDto
                {
                    Id = r.Id,
                    Text = r.Text,
                    DateCreated = r.DateCreated,
                    ShawarmaPlaceTitle = r.ShawarmaPlace?.Title,
                    ShawarmaPlaceId = r.ShawarmaPlaceId
                }).ToList()
            };

            return View(model);
        }
    }
}