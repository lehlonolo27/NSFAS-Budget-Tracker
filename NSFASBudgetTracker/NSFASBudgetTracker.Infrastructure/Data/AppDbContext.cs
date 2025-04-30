using Microsoft.EntityFrameworkCore;
using NSFASBudgetTracker.Core.Entities;

namespace NSFASBudgetTracker.Infrastructure.Data;

public class AppDbContext: DbContext
{
public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Budget> Budgets { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Food" },
            new Category { Id = 2, Name = "Transport" },
            new Category { Id = 3, Name = "Rent" },
            new Category { Id = 4, Name = "Entertainment" }
        );
    }

}
