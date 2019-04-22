
namespace Aguatech.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;

        }

        // GET: Categories
        public IActionResult Index()
        {
            return View(this.categoryRepository.GetAll());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await this.categoryRepository.GetByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageFile")] CategoryViewModel view)
        {
            if (ModelState.IsValid)
            {
                //Guardar a imagem
                var path = string.Empty;
                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Categories",
                        view.ImageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Categories/{view.ImageFile.FileName}";
                }

                var category = this.ToCategory(view, path);


                await this.categoryRepository.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Category ToCategory(CategoryViewModel view, string path)
        {
            return new Category
            {
                Id = view.Id,
                Name = view.Name,
                Description = view.Description,
                ImageUrl = path

            };
        }
        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await this.categoryRepository.GetByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            var view = this.ToCategoryViewModel(category);

            return View(view);
        }

        private CategoryViewModel ToCategoryViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ImageUrl = category.ImageUrl
            };
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageFile,ImageUrl")] CategoryViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Categories",
                            view.ImageFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Categories/{view.ImageFile.FileName}";
                    }
                    else
                    {
                        path = view.ImageUrl;
                    }
                    var category = this.ToCategory(view, path);

                    await this.categoryRepository.UpdateAsync(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.categoryRepository.ExistsAsync(view.Id))
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

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await this.categoryRepository.GetByIdAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            var view = this.ToCategoryViewModel(category);

            return View(view);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await this.categoryRepository.GetByIdAsync(id);
            await this.categoryRepository.DeleteAsync(category);
            return RedirectToAction(nameof(Index));
        }

    }
}
