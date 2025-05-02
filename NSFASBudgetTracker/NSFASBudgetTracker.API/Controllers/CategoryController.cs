using Microsoft.AspNetCore.Mvc;
using NSFASBudgetTracker.Core.Entities;
using NSFASBudgetTracker.Core.Interfaces;

namespace NSFASBudgetTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController: ControllerBase
{
  private readonly IRepository<Category> _categoryRepo;

    public CategoryController(IRepository<Category> categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        var categories = await _categoryRepo.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        var category = await _categoryRepo.GetByIdAsync(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Category category)
    {
        await _categoryRepo.AddAsync(category);
        await _categoryRepo.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var category = await _categoryRepo.GetByIdAsync(id);
        if (category == null) return NotFound();

        _categoryRepo.Remove(category);
        await _categoryRepo.SaveChangesAsync();
        return NoContent();
    }
}
