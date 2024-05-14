using LoanApp.Data;
using LoanApp.Models;
using LoanApp.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Controllers;

public class LoanController : Controller
{
    private readonly LoanContext _context;
    public LoanController(LoanContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Store(LoanViewModel loan)
    {
        int interest = 10;
        decimal amount = loan.AmountCollected * (1 + (interest / 100));
        Console.WriteLine(loan.UserId);
        var loandetail = new LoanDetails()
        {
            UserId = loan.UserId,
            AmountCollected = loan.AmountCollected,
            Interest = interest,
            AmountToPay = amount,
            MonthlyPayment = amount / (loan.Tenure * 12),
            Tenure = Convert.ToInt32(loan.Tenure)
        };

        _context.Loan.Add(loandetail);
        await _context.SaveChangesAsync();
        return RedirectToAction("DashBoard", "User");
    }
    
}