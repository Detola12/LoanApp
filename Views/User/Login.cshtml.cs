using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoanApp.Views.User;

public class Login : PageModel
{
    [EmailAddress]
    [Required]
    [BindProperty]
    public string Email { get; set; }
    
    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        
    }
}