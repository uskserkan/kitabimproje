using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;

public class AccountController : Controller
{

    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {

        var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            return RedirectToAction("Index", "Home");

        }

        ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre.";
        return View();

    }

    [HttpGet]
    public IActionResult Register()
    {

        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {

        if (ModelState.IsValid)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        else
        {
            return View();
        }
    }
}





