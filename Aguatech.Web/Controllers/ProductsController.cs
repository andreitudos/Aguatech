﻿namespace Aguatech.Web.Controllers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Aguatech.Web.Models;
    using Data;
    using Data.Entities;
    using Helpers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class ProductsController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IUserHelper userHelper;
        private readonly ICategoryRepository categoryRepository;

        public ProductsController(IProductRepository productRepository, IUserHelper userHelper, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.userHelper = userHelper;
            this.categoryRepository = categoryRepository;
        }

        // public IActionResult Index()
        // {
        //      return View(this.productRepository.GetAll()/*.OrderBy(p=>p.Name)*/);
        //    }

        // GET: Products by categories
        public IActionResult Index(string category)
        {
            return View(this.productRepository.GetByCategory(category));
            //return View(this.productRepository.GetAll()/*.OrderBy(p=>p.Name)*/);
        }

       

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Authorize]
        // GET: Products/Create
        public IActionResult Create(int? id)
        {


            ViewBag.CategoryID = new SelectList(this.categoryRepository.GetAll(), "Id", "Name");

            return View();

        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Barcode,Name,Price,ImageFile,LastPurchase,LastSale,IsAvailable,Stock,CategoryId")] ProductViewModel view)
        {

            if (ModelState.IsValid)
            {
                //Category DropDownList
                ViewBag.CategoryId = new SelectList(this.categoryRepository.GetAll(), "Id", null, view.CategoryId);

                //Guardar a imagem
                var path = string.Empty;
                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Products",
                        file);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Products/{file}";
                }

                var product = this.ToProduct(view, path);

                //Guarda o nome do utilizador na criacção do produto 
                product.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);

                await this.productRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Product ToProduct(ProductViewModel view, string path)
        {
            return new Product
            {
                Id = view.Id,
                Barcode =view.Barcode,
                ImageUrl = path,
                IsAvailable = view.IsAvailable,
                LastPurchase = view.LastPurchase,
                LastSale = view.LastSale,
                Name = view.Name,
                Price = view.Price,
                Stock = view.Stock,
                User = view.User,
                CategoryId = view.CategoryId
            };
        }

        [Authorize]
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.productRepository.GetByIdAsync(id.Value);
            ViewBag.CategoryId = new SelectList(this.categoryRepository.GetAll(), "Id", "Name", product.CategoryId);
            if (product == null)
            {
                return NotFound();
            }

            var view = this.ToProductViewModel(product);
            return View(view);
        }

        private ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Barcode = product.Barcode,
                ImageUrl = product.ImageUrl,
                IsAvailable = product.IsAvailable,
                LastPurchase = product.LastPurchase,
                LastSale = product.LastSale,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                User = product.User,
                CategoryId = product.CategoryId

            };
        }

        [Authorize]
        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Barcode,Name,Price,ImageFile,LastPurchase,LastSale,IsAvailable,Stock,ImageUrl,CategoryId")] ProductViewModel view)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        path = string.Empty;

                        if (view.ImageFile != null && view.ImageFile.Length > 0)
                        {
                            var guid = Guid.NewGuid().ToString();
                            var file = $"{guid}.jpg";

                            path = Path.Combine(
                                Directory.GetCurrentDirectory(),
                                "wwwroot\\images\\Products",
                                file);

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await view.ImageFile.CopyToAsync(stream);
                            }

                            path = $"~/images/Products/{file}";
                        }
                    }
                    var product = this.ToProduct(view, path);

                    product.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await this.productRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.productRepository.ExistsAsync(view.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Edit));
            }
            return View(view);
        }


        [Authorize]
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.productRepository.GetByIdAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await this.productRepository.GetByIdAsync(id);
            await this.productRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
