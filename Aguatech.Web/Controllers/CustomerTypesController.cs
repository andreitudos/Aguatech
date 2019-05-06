namespace Aguatech.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Aguatech.Web.Data;
    using Aguatech.Web.Data.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    public class CustomerTypesController : Controller
    {
        private readonly DataContext _context;

        public CustomerTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: CustomerTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerType.ToListAsync());
        }

        // GET: CustomerTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerType == null)
            {
                return NotFound();
            }

            return View(customerType);
        }

        // GET: CustomerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DiscountRate")] CustomerType customerType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerType);
        }

        // GET: CustomerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerType.FindAsync(id);
            if (customerType == null)
            {
                return NotFound();
            }
            return View(customerType);
        }

        // POST: CustomerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DiscountRate")] CustomerType customerType)
        {
            if (id != customerType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerTypeExists(customerType.Id))
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
            return View(customerType);
        }

        // GET: CustomerTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerType = await _context.CustomerType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerType == null)
            {
                return NotFound();
            }

            return View(customerType);
        }

        // POST: CustomerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerType = await _context.CustomerType.FindAsync(id);
            _context.CustomerType.Remove(customerType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerTypeExists(int id)
        {
            return _context.CustomerType.Any(e => e.Id == id);
        }
    }
}
