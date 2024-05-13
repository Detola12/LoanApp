using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoanApp.Models;

public class UserViewModel
{
    [Required]
    [DisplayName("First Name")]
    public string FirstName { get; set; }
    [DisplayName("Last Name")]
    public string LastName { get; set; }
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [MaxLength(12)]
    public string Phone { get; set; }
    [Required(ErrorMessage = "Must be greater than 18")]
    public int Age { get; set; }
    [Required]
    public string BVN { get; set; }
}