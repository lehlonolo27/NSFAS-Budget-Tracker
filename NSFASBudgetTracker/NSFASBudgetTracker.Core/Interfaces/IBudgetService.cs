using NSFASBudgetTracker.Core.Entities;


namespace NSFASBudgetTracker.Core.Interfaces;

public interface IBudgetService
{
    Task<IEnumerable<Budget>> GetAllBudgetsAsync();
    Task<Budget?> GetBudgetDetailsAsync(int id);
    Task AddBudgetAsync(Budget budget);
    Task DeleteBudgetAsync(int id);
}
