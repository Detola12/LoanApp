using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanApp.Models.Entities;

public class LoanDetails
{
    public LoanDetails()
    {
        
    }
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual UserDetails user { get; set; }
    [Required]
    public decimal AmountCollected { get; set; }
    [Required]
    public int Tenure { get; set; }

    public decimal Interest { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal AmountToPay { get; set; }
    
}
