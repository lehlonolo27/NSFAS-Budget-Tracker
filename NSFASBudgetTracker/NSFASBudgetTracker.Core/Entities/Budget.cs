namespace NSFASBudgetTracker.Core.Entities;

public class Budget
{
    public int Id { get; set; }
    public decimal MonthlyIncome { get; set; }
    public decimal SavingsGoal { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
