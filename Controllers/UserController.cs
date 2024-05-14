using LoanApp.Data;
using LoanApp.Models;
using LoanApp.Models.Entities;
using LoanApp.Views.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoanApp.Controllers;

public class UserController : Controller
{
    // GET
    private readonly LoanContext _context;
    private readonly IHttpContextAccessor _accessor;

    public UserController(LoanContext context, IHttpContextAccessor accessor)
    {
        this._context = context;
        _accessor = accessor;
    }

    public IActionResult DashBoard()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        if (_accessor.HttpContext.Session.GetInt32("AuthId").HasValue)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost]
    public IActionResult Validate(LoginViewModel login)
    {
        if (ModelState.IsValid)
        {
            var AuthUser = _context.Users.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            if (AuthUser != null)
            {
                _accessor.HttpContext.Session.SetInt32("AuthId", AuthUser.Id);
                _accessor.HttpContext.Session.SetString("AuthName", AuthUser.FirstName + " " + AuthUser.LastName);
                return RedirectToAction("Index", "Home");
            }

            return View("Login");
        }
        return View("Login");
        
    }

    [HttpGet]
    public IActionResult Register()
    {
        if (_accessor.HttpContext.Session.GetInt32("AuthId").HasValue)
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserViewModel userModel)
    {
        if (ModelState.IsValid)
        {
            var user = new UserDetails()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Age = userModel.Age,
                Email = userModel.Email,
                PhoneNumber = userModel.Phone,
                Password = userModel.Password,
                BVN = userModel.BVN,
                Address = userModel.Address,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
                
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var tempUser = _context.Users.FirstOrDefault(x => x.Email == userModel.Email);
            var tempId = tempUser.Id;
            // HttpContext.Session.SetString("AuthFirstName", user.FirstName);
            // HttpContext.Session.SetString("AuthLastName", user.LastName);
            // HttpContext.Session.SetInt32("AuthId", tempId);
            if (!_accessor.HttpContext.Session.GetInt32("AuthId").HasValue)
            {
                _accessor.HttpContext.Session.SetInt32("AuthId", tempId);
                _accessor.HttpContext.Session.SetString("AuthName", user.FirstName + " " + user.LastName);
            }
            
            return RedirectToAction("Index", "Loan");
        }
        else
        {
            ModelState.AddModelError("Error", "Something Went Wrong");
            return View();
        }

    }
    
}