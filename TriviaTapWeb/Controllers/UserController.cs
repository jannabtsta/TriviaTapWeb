using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TriviaTapWeb.Models;

namespace TriviaTapWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserTransactionServices _userTransactionServices;
        private readonly UserData userData;
        private readonly TriviaDBContext _context;

        public UserController(TriviaDBContext context)
        {
            _userTransactionServices = new UserTransactionServices(context);
            userData = new UserData(context);
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Check if the username already exists
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.username == user.username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Username already exists");
                    return View(user);
                }

                // Add user to the database
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Redirect to login or another page after successful registration
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = userData.GetUser(username, password);
            if (user != null)
            {
                if (user.isAdmin)
                {
                    // Admin login, redirect to admin panel
                    return RedirectToAction("IndexAsAdmin", "Quiz");
                }
                else
                {
                    // Normal user login
                    return RedirectToAction("Index", "Quiz");
                }
            }

            ViewBag.LoginError = "Invalid username or password.";
            return View();
        }
        // GET: UserController
        public ActionResult Home()
        {
            return View();
        }


        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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
