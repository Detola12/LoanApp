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

    public UserController(LoanContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // [HttpPost]
    // public IActionResult Validate(Login login)
    // {
    //     
    //     
    // }

    [HttpGet]
    public IActionResult Register()
    {
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
                BVN = userModel.BVN,
                Address = userModel.Address,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var tempUser = _context.Users.FirstOrDefault(x => x.Email == userModel.Email);
            var tempId = tempUser.Id;
            return RedirectToAction("Index", "Loan", new { Id = tempId });
        }
        else
        {
            return View();
        }

    }
    
}