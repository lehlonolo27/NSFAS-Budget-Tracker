namespace NSFASBudgetTracker.Core.Entities;

public class Expense
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int BudgetId { get; set; }
    public Budget Budget { get; set; }

}
