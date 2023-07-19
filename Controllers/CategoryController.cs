using Microsoft.AspNetCore.Mvc;
using MSSQLStoreAPI.Models;

namespace MSSQLStoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")] // https://localhost:7132/api/Category
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoryController (AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<Category> GetAll()
    {
        var allCategory = _context.Categories.ToList();
        return Ok(allCategory);
    }

    //Get Category by ID
    [HttpGet("{id}")]
    public ActionResult<Category> GetById(int id)
    {
        var Category = _context.Categories.Where(c => c.Id == id);
        return Ok(Category);
    }

    //Create new Category
    [HttpPost]
    public ActionResult<Category> Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
        return Ok(category.Id);
    }
    
    // Update Category
    [HttpPut]
    public ActionResult Update(Category category)
    {
        if(category == null)
            return NotFound();
        
        _context.Update(category);
        _context.SaveChanges();
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var categoryDelete = _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        if(categoryDelete == null)
            return NotFound();

        _context.Remove(categoryDelete);
        _context.SaveChanges();
        return Ok(categoryDelete);

    }
}
