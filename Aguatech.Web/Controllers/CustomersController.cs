using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aguatech.Web.Data;
using Aguatech.Web.Data.Entities;
using Aguatech.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Aguatech.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IDocumentTypeRepository documentTypeRepository;
        private readonly ICustomerTypeRepository customerTypeRepository;

        public CustomersController(ICustomerRepository customerRepository, IDocumentTypeRepository documentTypeRepository, ICustomerTypeRepository customerTypeRepository)
        {
            this.customerRepository = customerRepository;
            this.customerTypeRepository = customerTypeRepository;
            this.documentTypeRepository = documentTypeRepository;

        }

        // GET: Customers
        //public async Task<IActionResult> Index()
        //{
        //    var dataContext = _context.Customers.Include(c => c.DocumentType);
        //    return View(await dataContext.ToListAsync());
        //}

        public IActionResult Index()
        {
            return View(this.customerRepository.GetAll());
            //return View(this.productRepository.GetAll()/*.OrderBy(p=>p.Name)*/);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await this.customerRepository.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewBag.DocumentTypeId = new SelectList(this.documentTypeRepository.GetAll(), "Id", "Name");
            ViewBag.CustomerTypeId = new SelectList(this.customerTypeRepository.GetAll(), "Id", "Name");

            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Phone,Address,Email,Document,DocumentTypeId,CustomertypeId")] CustomerViewModel view)
        {
            if (ModelState.IsValid)
            {
                //Category DropDownList
                ViewBag.DocumentTypeId = new SelectList(this.documentTypeRepository.GetAll(), "Id", null, view.DocumentTypeId);
                ViewBag.CustomerTypeId = new SelectList(this.customerTypeRepository.GetAll(), "Id", null, view.CustomerTypeId);

                //Guardar a imagem
                var path = string.Empty;
                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Customers",
                        file);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Customers/{file}";
                }

                var customer = this.ToCustomer(view, path);

                ////Guarda o nome do utilizador na criacção do produto 
                //product.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);

                await this.customerRepository.CreateAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await this.customerRepository.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }
            ViewBag.DocumentTypeId = new SelectList(this.documentTypeRepository.GetAll(), "Id", "Name", customer.DocumentTypeId);
            ViewBag.CustomerTypeId = new SelectList(this.customerTypeRepository.GetAll(), "Id", "Name", customer.CustomerTypeId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Phone,Address,Email,Document,DocumentTypeId,CustomerTypeId")] CustomerViewModel view)
        {
            if (ModelState.IsValid)
            {
                //Category DropDownList
                ViewBag.DocumentTypeId = new SelectList(this.documentTypeRepository.GetAll(), "Id", null, view.DocumentTypeId);

                //Guardar a imagem
                var path = string.Empty;
                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Customers",
                        file);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Customers/{file}";
                }

                var customer = this.ToCustomer(view, path);

                ////Guarda o nome do utilizador na criacção do produto 
                //product.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);

                await this.customerRepository.UpdateAsync(customer);
                return RedirectToAction(nameof(Edit));
            }
            return View(view);
        }

        private Customer ToCustomer(CustomerViewModel view, string path)
        {
            return new Customer
            {
                Id = view.Id,
                ImageUrl = path,
                Name = view.Name,
                LastName = view.LastName,
                Address = view.Address,
                DocumentTypeId = view.DocumentTypeId,
                Email = view.Email,
                Phone = view.Phone,
                Document = view.Document,
                CustomerTypeId = view.CustomerTypeId
            };
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await this.customerRepository.GetByIdAsync(id.Value);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await this.customerRepository.GetByIdAsync(id);
            await this.customerRepository.DeleteAsync(customer);
            return RedirectToAction(nameof(Index));
        }

    }
}
