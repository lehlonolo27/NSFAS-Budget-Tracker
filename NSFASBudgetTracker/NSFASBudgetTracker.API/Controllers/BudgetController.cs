using Microsoft.AspNetCore.Mvc;
using NSFASBudgetTracker.Core.Entities;
using NSFASBudgetTracker.Core.Interfaces;


namespace NSFASBudgetTracker.API;

[ApiController]
[Route("api/[controller]")]
public class BudgetController: ControllerBase
{
private readonly IBudgetService _budgetService;

    public BudgetController(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Budget>>> GetAll()
    {
        var budgets = await _budgetService.GetAllBudgetsAsync();
        return Ok(budgets);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Budget>> GetById(int id)
    {
        var budget = await _budgetService.GetBudgetDetailsAsync(id);
        if (budget == null)
            return NotFound();

        return Ok(budget);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Budget budget)
    {
        await _budgetService.AddBudgetAsync(budget);
        return CreatedAtAction(nameof(GetById), new { id = budget.Id }, budget);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _budgetService.DeleteBudgetAsync(id);
        return NoContent();
    }
}
