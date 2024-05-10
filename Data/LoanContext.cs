using LoanApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanApp.Data;

public class LoanContext : DbContext
{
    public LoanContext(DbContextOptions<LoanContext> options) : base(options)
    {
        
    }
    public DbSet<UserDetails> Users { get; set; }
    public DbSet<LoanDetails> Loan { get; set; }
}