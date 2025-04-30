using NSFASBudgetTracker.Core.Entities;
namespace NSFASBudgetTracker.Core.Interfaces;

public interface IBudgetRepository: IRepository<Budget>
{
  Task<Budget?> GetBudgetWithExpensesAsync(int id);
}
