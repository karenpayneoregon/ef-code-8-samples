using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthWindWithControllersApp.Data;
using NorthWindWithControllersApp.Models;

namespace NorthWindWithControllersApp.Controllers;

public class ProductsController : Controller
{
    private readonly Context _context;

    public ProductsController(Context context)
    {
        _context = context;
    }

    // GET: Products
    public async Task<IActionResult> Index()
    {
        var context = _context.Products.Include(p => p.Category).Include(p => p.Supplier);
        return View(await context.ToListAsync());
    }

    // GET: Products/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var products = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(m => m.ProductID == id);
        if (products == null)
        {
            return NotFound();
        }

        return View(products);
    }

    // GET: Products/Create
    public IActionResult Create()
    {
        ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
        ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "CompanyName");
        return View();
    }

    // POST: Products/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,DiscontinuedDate")] Products products)
    {
        if (ModelState.IsValid)
        {
            _context.Add(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", products.CategoryID);
        ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "CompanyName", products.SupplierID);
        return View(products);
    }

    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var products = await _context.Products.FindAsync(id);
        if (products == null)
        {
            return NotFound();
        }
        ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", products.CategoryID);
        ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "CompanyName", products.SupplierID);
        return View(products);
    }

    // POST: Products/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued,DiscontinuedDate")] Products products)
    {
        if (id != products.ProductID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(products);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(products.ProductID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", products.CategoryID);
        ViewData["SupplierID"] = new SelectList(_context.Suppliers, "SupplierID", "CompanyName", products.SupplierID);
        return View(products);
    }

    // GET: Products/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var products = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(m => m.ProductID == id);
        if (products == null)
        {
            return NotFound();
        }

        return View(products);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var products = await _context.Products.FindAsync(id);
        if (products != null)
        {
            _context.Products.Remove(products);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductsExists(int id)
    {
        return _context.Products.Any(e => e.ProductID == id);
    }
}