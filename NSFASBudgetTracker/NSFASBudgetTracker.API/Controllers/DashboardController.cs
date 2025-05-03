using Microsoft.AspNetCore.Mvc;
using NSFASBudgetTracker.Core.Entities;
using NSFASBudgetTracker.Core.Interfaces;

namespace NSFASBudgetTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IRepository<Budget> _budgetRepo;
    private readonly IRepository<Expense> _expenseRepo;
    private readonly IRepository<Category> _categoryRepo;

    public DashboardController(IRepository<Budget> budgetRepo, IRepository<Expense> expenseRepo, IRepository<Category> categoryRepo)
    {
        _budgetRepo = budgetRepo;
        _expenseRepo = expenseRepo;
        _categoryRepo = categoryRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetDashboardSummary()
    {
        var budgets = await _budgetRepo.GetAllAsync();
        var expenses = await _expenseRepo.GetAllAsync();
        var categories = await _categoryRepo.GetAllAsync();

        var summary = new SummaryData
        {
            TotalBudget = budgets.Sum(b => b.MonthlyIncome),
            TotalExpenses = expenses.Sum(e => e.Amount),
            CategorySummaries = categories.Select(c => new CategorySummary
            {
                Category = c.Name,
                Amount = expenses.Where(e => e.CategoryId == c.Id).Sum(e => e.Amount)
            }).ToList()
        };

        return Ok(summary);
    }
}

public class SummaryData
{
    public decimal TotalBudget { get; set; }
    public decimal TotalExpenses { get; set; }
    public List<CategorySummary> CategorySummaries { get; set; } = new();
}

public class CategorySummary
{
    public string Category { get; set; }
    public decimal Amount { get; set; }
}
