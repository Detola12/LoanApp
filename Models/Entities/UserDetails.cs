using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LoanApp.Models.Entities;

[PrimaryKey("Id")]
[Index("Email", IsUnique = true)]
[Index("BVN", IsUnique = true)]
public class UserDetails
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    [StringLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [StringLength(12)]
    public string PhoneNumber { get; set; }
    
    [EmailAddress]
    [Required]
    [StringLength(70)]
    public string Email { get; set; }
    [Required]
    [StringLength(80)]
    public string Address { get; set; }
    [Range(1, 120)]
    public int Age { get; set; }
    [Required]
    [StringLength(15)]
    public string BVN { get; set; }
    [Required]
    [MinLength(6)]
    [StringLength(25)]
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    
    public virtual ICollection<LoanDetails> Loan { get; set; }
}