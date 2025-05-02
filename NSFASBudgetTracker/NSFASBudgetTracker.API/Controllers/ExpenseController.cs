using Microsoft.AspNetCore.Mvc;
using NSFASBudgetTracker.Core.Entities;
using NSFASBudgetTracker.Core.Interfaces;

namespace NSFASBudgetTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController: ControllerBase
{
  private readonly IRepository<Expense> _expenseRepo;

    public ExpenseController(IRepository<Expense> expenseRepo)
    {
        _expenseRepo = expenseRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Expense>>> GetAll()
    {
        var expenses = await _expenseRepo.GetAllAsync();
        return Ok(expenses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetById(int id)
    {
        var expense = await _expenseRepo.GetByIdAsync(id);
        if (expense == null) return NotFound();
        return Ok(expense);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Expense expense)
    {
        await _expenseRepo.AddAsync(expense);
        await _expenseRepo.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = expense.Id }, expense);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var expense = await _expenseRepo.GetByIdAsync(id);
        if (expense == null) return NotFound();

        _expenseRepo.Remove(expense);
        await _expenseRepo.SaveChangesAsync();
        return NoContent();
    }
}
