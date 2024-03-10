using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthWindWithControllersApp.Data;
using NorthWindWithControllersApp.Models;

namespace NorthWindWithControllersApp.Controllers;

public class EmployeesController : Controller
{
    private readonly Context _context;

    public EmployeesController(Context context)
    {
        _context = context;
    }

    // GET: Employees
    public async Task<IActionResult> Index()
    {
        var context = _context.Employees.Include(e => e.ContactTypeIdentifierNavigation).Include(e => e.CountryIdentifierNavigation).Include(e => e.ReportsToNavigationEmployee);
        return View(await context.ToListAsync());
    }

    // GET: Employees/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employees = await _context.Employees
            .Include(e => e.ContactTypeIdentifierNavigation)
            .Include(e => e.CountryIdentifierNavigation)
            .Include(e => e.ReportsToNavigationEmployee)
            .FirstOrDefaultAsync(m => m.EmployeeID == id);
        if (employees == null)
        {
            return NotFound();
        }

        return View(employees);
    }

    // GET: Employees/Create
    public IActionResult Create()
    {
        ViewData["ContactTypeIdentifier"] = new SelectList(_context.ContactType, "ContactTypeIdentifier", "ContactTypeIdentifier");
        ViewData["CountryIdentifier"] = new SelectList(_context.Countries, "CountryIdentifier", "CountryIdentifier");
        ViewData["ReportsToNavigationEmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirstName");
        return View();
    }

    // POST: Employees/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EmployeeID,LastName,FirstName,ContactTypeIdentifier,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,CountryIdentifier,HomePhone,Extension,Notes,ReportsTo,ReportsToNavigationEmployeeID")] Employees employees)
    {
        if (ModelState.IsValid)
        {
            _context.Add(employees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ContactTypeIdentifier"] = new SelectList(_context.ContactType, "ContactTypeIdentifier", "ContactTypeIdentifier", employees.ContactTypeIdentifier);
        ViewData["CountryIdentifier"] = new SelectList(_context.Countries, "CountryIdentifier", "CountryIdentifier", employees.CountryIdentifier);
        ViewData["ReportsToNavigationEmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirstName", employees.ReportsToNavigationEmployeeID);
        return View(employees);
    }

    // GET: Employees/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employees = await _context.Employees.FindAsync(id);
        if (employees == null)
        {
            return NotFound();
        }
        ViewData["ContactTypeIdentifier"] = new SelectList(_context.ContactType, "ContactTypeIdentifier", "ContactTypeIdentifier", employees.ContactTypeIdentifier);
        ViewData["CountryIdentifier"] = new SelectList(_context.Countries, "CountryIdentifier", "CountryIdentifier", employees.CountryIdentifier);
        ViewData["ReportsToNavigationEmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirstName", employees.ReportsToNavigationEmployeeID);
        return View(employees);
    }

    // POST: Employees/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,LastName,FirstName,ContactTypeIdentifier,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,CountryIdentifier,HomePhone,Extension,Notes,ReportsTo,ReportsToNavigationEmployeeID")] Employees employees)
    {
        if (id != employees.EmployeeID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(employees);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(employees.EmployeeID))
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
        ViewData["ContactTypeIdentifier"] = new SelectList(_context.ContactType, "ContactTypeIdentifier", "ContactTypeIdentifier", employees.ContactTypeIdentifier);
        ViewData["CountryIdentifier"] = new SelectList(_context.Countries, "CountryIdentifier", "CountryIdentifier", employees.CountryIdentifier);
        ViewData["ReportsToNavigationEmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "FirstName", employees.ReportsToNavigationEmployeeID);
        return View(employees);
    }

    // GET: Employees/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employees = await _context.Employees
            .Include(e => e.ContactTypeIdentifierNavigation)
            .Include(e => e.CountryIdentifierNavigation)
            .Include(e => e.ReportsToNavigationEmployee)
            .FirstOrDefaultAsync(m => m.EmployeeID == id);
        if (employees == null)
        {
            return NotFound();
        }

        return View(employees);
    }

    // POST: Employees/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var employees = await _context.Employees.FindAsync(id);
        if (employees != null)
        {
            _context.Employees.Remove(employees);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EmployeesExists(int id)
    {
        return _context.Employees.Any(e => e.EmployeeID == id);
    }
}