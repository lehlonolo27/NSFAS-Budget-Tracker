using Microsoft.EntityFrameworkCore;
using NSFASBudgetTracker.Core.Entities;
using NSFASBudgetTracker.Core.Interfaces;
using NSFASBudgetTracker.Infrastructure.Data;

namespace NSFASBudgetTracker.Infrastructure.Repositories;

public class BudgetRepository: GenericRepository<Budget>, IBudgetRepository
{
    public BudgetRepository(AppDbContext context) : base(context) {}

    public async Task<Budget?> GetBudgetWithExpensesAsync(int id)
    {
        return await _context.Budgets
            .Include(b => b.Expenses)
                .ThenInclude(e => e.Category)
            .FirstOrDefaultAsync(b => b.Id == id);
    }
}
