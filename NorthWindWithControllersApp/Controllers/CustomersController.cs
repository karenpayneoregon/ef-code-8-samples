using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthWindWithControllersApp.Data;
using NorthWindWithControllersApp.Models;

namespace NorthWindWithControllersApp.Controllers;

public class CustomersController : Controller
{
    private readonly Context _context;

    public CustomersController(Context context)
    {
        _context = context;
    }

    // GET: Customers
    public async Task<IActionResult> Index()
    {
        var context = _context.Customers.Include(c => c.Contact).Include(c => c.ContactTypeIdentifierNavigation).Include(c => c.CountryIdentifierNavigation);
        return View(await context.ToListAsync());
    }

    // GET: Customers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customers = await _context.Customers
            .Include(c => c.Contact)
            .Include(c => c.ContactTypeIdentifierNavigation)
            .Include(c => c.CountryIdentifierNavigation)
            .FirstOrDefaultAsync(m => m.CustomerIdentifier == id);
        if (customers == null)
        {
            return NotFound();
        }

        return View(customers);
    }

    // GET: Customers/Create
    public IActionResult Create()
    {
        ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "ContactId");
        ViewData["ContactTypeIdentifier"] = new SelectList(_context.ContactType, "ContactTypeIdentifier", "ContactTypeIdentifier");
        ViewData["CountryIdentifier"] = new SelectList(_context.Countries, "CountryIdentifier", "CountryIdentifier");
        return View();
    }

    // POST: Customers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CustomerIdentifier,CompanyName,ContactId,Street,City,Region,PostalCode,CountryIdentifier,Phone,Fax,ContactTypeIdentifier,ModifiedDate")] Customers customers)
    {
        if (ModelState.IsValid)
        {
            _context.Add(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "ContactId", customers.ContactId);
        ViewData["ContactTypeIdentifier"] = new SelectList(_context.ContactType, "ContactTypeIdentifier", "ContactTypeIdentifier", customers.ContactTypeIdentifier);
        ViewData["CountryIdentifier"] = new SelectList(_context.Countries, "CountryIdentifier", "CountryIdentifier", customers.CountryIdentifier);
        return View(customers);
    }

    // GET: Customers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customers = await _context.Customers.FindAsync(id);
        if (customers == null)
        {
            return NotFound();
        }
        ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "ContactId", customers.ContactId);
        ViewData["ContactTypeIdentifier"] = new SelectList(_context.ContactType, "ContactTypeIdentifier", "ContactTypeIdentifier", customers.ContactTypeIdentifier);
        ViewData["CountryIdentifier"] = new SelectList(_context.Countries, "CountryIdentifier", "CountryIdentifier", customers.CountryIdentifier);
        return View(customers);
    }

    // POST: Customers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CustomerIdentifier,CompanyName,ContactId,Street,City,Region,PostalCode,CountryIdentifier,Phone,Fax,ContactTypeIdentifier,ModifiedDate")] Customers customers)
    {
        if (id != customers.CustomerIdentifier)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(customers);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(customers.CustomerIdentifier))
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
        ViewData["ContactId"] = new SelectList(_context.Contacts, "ContactId", "ContactId", customers.ContactId);
        ViewData["ContactTypeIdentifier"] = new SelectList(_context.ContactType, "ContactTypeIdentifier", "ContactTypeIdentifier", customers.ContactTypeIdentifier);
        ViewData["CountryIdentifier"] = new SelectList(_context.Countries, "CountryIdentifier", "CountryIdentifier", customers.CountryIdentifier);
        return View(customers);
    }

    // GET: Customers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customers = await _context.Customers
            .Include(c => c.Contact)
            .Include(c => c.ContactTypeIdentifierNavigation)
            .Include(c => c.CountryIdentifierNavigation)
            .FirstOrDefaultAsync(m => m.CustomerIdentifier == id);
        if (customers == null)
        {
            return NotFound();
        }

        return View(customers);
    }

    // POST: Customers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var customers = await _context.Customers.FindAsync(id);
        if (customers != null)
        {
            _context.Customers.Remove(customers);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CustomersExists(int id)
    {
        return _context.Customers.Any(e => e.CustomerIdentifier == id);
    }
}