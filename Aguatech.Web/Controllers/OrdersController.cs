using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aguatech.Web.Data;
using Aguatech.Web.Data.Entities;

namespace Aguatech.Web.Controllers
{
   
    public class OrdersController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IProductOrderReposotory productOrderReposotory;
        private readonly IOrderStatusRepository orderStatusRepository;
        private readonly OrderStatus _orderstatus;
        private readonly DataContext _context;

        public OrdersController(DataContext context, IProductRepository productRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository, IProductOrderReposotory productOrderReposotory, IOrderStatusRepository orderStatusRepository)
        {
            this.productRepository = productRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.productOrderReposotory = productOrderReposotory;
            this.orderStatusRepository = orderStatusRepository;

            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Orders.Include(o => o.Customer);
            return View(await dataContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        public ActionResult AddProduct(string barcode)
        {
            ViewBag.ProductID = this.productRepository.GetByBarcode(barcode);

            return View();
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(this.customerRepository.GetAll(), "Id", "Name");
            ViewBag.OrderStatus = new SelectList(this.orderStatusRepository.GetAll(), "Id", "Name");
           // ViewData["OrderStatus"] =  new List<_ordrestatus>;

            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataOrder,CustomerID,OrderStatusID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(this.customerRepository.GetAll(), "Id", "Name");
            ViewData["OrderStatus"] = new SelectList(this.orderStatusRepository.GetAll(), "Id", "Name");
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(this.customerRepository.GetAll(), "Id", "Name");
            ViewData["OrderStatus"] = new SelectList(this.orderStatusRepository.GetAll(), "Id", "Name");
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataOrder,CustomerID,OrderStatusId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["CustomerID"] = new SelectList(_context.Customers, "Id", "Address", order.CustomerID);
            ViewData["OrderStatus"] = new SelectList(this.orderStatusRepository.GetAll(), "Id", "Name");
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
