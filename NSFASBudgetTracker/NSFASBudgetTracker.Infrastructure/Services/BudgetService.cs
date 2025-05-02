using NSFASBudgetTracker.Core.Entities;
using NSFASBudgetTracker.Core.Interfaces;

namespace NSFASBudgetTracker.Infrastructure.Services;

public class BudgetService: IBudgetService
{
   private readonly IBudgetRepository _budgetRepository;

    public BudgetService(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public async Task<IEnumerable<Budget>> GetAllBudgetsAsync()
    {
        return await _budgetRepository.GetAllAsync();
    }

    public async Task<Budget?> GetBudgetDetailsAsync(int id)
    {
        return await _budgetRepository.GetBudgetWithExpensesAsync(id);
    }

    public async Task AddBudgetAsync(Budget budget)
    {
        await _budgetRepository.AddAsync(budget);
        await _budgetRepository.SaveChangesAsync();
    }

    public async Task DeleteBudgetAsync(int id)
    {
        var budget = await _budgetRepository.GetByIdAsync(id);
        if (budget != null)
        {
            _budgetRepository.Remove(budget);
            await _budgetRepository.SaveChangesAsync();
        }
    }

}
