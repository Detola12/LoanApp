using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoanApp.Models.Entities;

namespace LoanApp.Models;

public class LoanViewModel
{
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual UserDetails user { get; set; }
    [Required]
    public decimal AmountCollected { get; set; }
    [Required]
    public int Tenure { get; set; }
}