using ETickets.Data;
using ETickets.Data.Static;
using ETickets.Data.ViewModels;
using ETickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login() => View(new LoginVM());

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
             

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            var user = await _userManager.FindByEmailAsync(loginVM.EmalAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }

                }
                TempData["Error"] = "Wrong credentails. Please try again!";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong credentails. Please try again!";
            return View(loginVM);
        }

        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            var user = await _userManager.FindByEmailAsync(registerVM.EmalAddress);
            if (user != null)
            {
                TempData["Error"] = "This email is already used. Please try again!";
                return View(registerVM);
            }
            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmalAddress,
                UserName = registerVM.EmalAddress
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegisterCompleted");

        }

        [HttpPost]
        public async Task<IActionResult> Logout(RegisterVM registerVM)
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            return View();
        }
    }
}
