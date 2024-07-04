using Microsoft.AspNetCore.Mvc;
using MovieStore_MVC.Models.DTO;
using MovieStore_MVC.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MovieStore_MVC.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly IUserAuthServices _authService;

        public UserAuthController(IUserAuthServices authService)
        {
            _authService = authService;
        }
        //public async Task<IActionResult> Register()
        //{
        //    var model = new Registration
        //    {
        //        Email = "admin@gmail.com",
        //        Username = "admin",
        //        Name = "Aliaa",
        //        Password = "Aliaa@123",
        //        PasswordConfirm = "Aliaa@123",
        //        Role = "Admin"
        //    };
        //   var result = await _authService.RegisterAsync(model);
        //    return Ok(result.Message);
        //}

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _authService.LoginAsync(model);
            if (result.StatusCode == 1)
                return RedirectToAction("Index", "Home");
            else
            {
                TempData["msg"] = "Could not logged in..";
                return RedirectToAction(nameof(Login));
            }
        }
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
