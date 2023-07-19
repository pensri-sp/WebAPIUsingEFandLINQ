using Microsoft.AspNetCore.Mvc;
using MSSQLStoreAPI.Models;

namespace MSSQLStoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    //property
    private readonly AppDbContext _context;
    //Constructure
    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    //Read
    [HttpGet]
    public ActionResult<Products> GetAll()
    {
        // LINQ
        //var allProducts = _context.Products.ToList();

        // LINQ with Condition
        // var allProducts = _context.Products
        //                 .Where(p => p.Id != 0)
        //                 .OrderByDescending(p => p.UnitPrice)
        //                 .ToList();

        // LINQ with join
        //https://learn.microsoft.com/en-us/ef/core/querying/
        var allProducts = (
            from category in _context.Categories
            join product in _context.Products
            on category.Id equals product.Id
            where category.CategoryStatus == 1
            orderby product.UnitPrice descending 
            select new
            {
                product.Id,
                product.ProductName,
                product.UnitPrice,
                product.UnitStock,
                product.ProductPicture,
                product.CreatedDate,
                product.ModifiedDate,
                category.CatagoryName,
                category.CategoryStatus
            }
        ).ToList();

        return Ok(allProducts);
    }

    [HttpGet("{id}")]
    public ActionResult<Products> GetById(int id)
    {
        //var product = _context.Products.Where(p => p.Id == id);
         var selectedProduct = (
            from category in _context.Categories
            join product in _context.Products
            on category.Id equals product.Id
            where product.Id == id
            orderby product.UnitPrice descending 
            select new
            {
                product.Id,
                product.ProductName,
                product.UnitPrice,
                product.UnitStock,
                product.ProductPicture,
                product.CreatedDate,
                product.ModifiedDate,
                category.CatagoryName,
                category.CategoryStatus
            }
        ).ToList();

        return Ok(selectedProduct);
    }

    [HttpPost]
    public ActionResult<Products> Create(Products product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return Ok(product.Id);
    }

    [HttpPut]
    public ActionResult<Products> Update(Products product)
    {
         if(product == null)
            return NotFound();
        _context.Update(product);
        _context.SaveChanges();
        return Ok(product);
    }

    [HttpDelete]
    public ActionResult<Products> Delete(int id)
    {
        var productToDelete = _context.Products.Where(p => p.Id == id).FirstOrDefault();
        if(productToDelete == null)
            return NotFound();
        _context.Products.Remove(productToDelete);
        _context.SaveChanges();
        return NoContent();
    }

}