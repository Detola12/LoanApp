using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Models;

public class LoginViewModel
{
    [EmailAddress]
    [Required]
    [BindProperty]
    public string Email { get; set; }
    
    [BindProperty]
    [Required]
    public string Password { get; set; }

}