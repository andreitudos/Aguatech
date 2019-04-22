namespace Aguatech.Web.Controllers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Aguatech.Web.Data;
    using Aguatech.Web.Data.Entities;
    using Aguatech.Web.Helpers;
    using Aguatech.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class MarcasController : Controller
    {
        private readonly IMarcaRepository marcaRepository;
        private readonly IUserHelper userHelper;

        public MarcasController(IMarcaRepository marcaRepository, IUserHelper userHelper)
        {
            this.marcaRepository = marcaRepository;
            this.userHelper = userHelper;
        }

        // GET: Marcas
        public IActionResult Index()
        {
            return View(this.marcaRepository.GetAll()/*.OrderBy(p=>p.Name)*/);
        }

        // GET: Marcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await this.marcaRepository.GetByIdAsync(id.Value);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // GET: Marcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ImageFile")] MarcViewModel view)
        {
            if (ModelState.IsValid)
            {
                //Guardar a imagem
                var path = string.Empty;
                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Brands",
                        view.ImageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Brands/{view.ImageFile.FileName}";
                }

                var marc = this.ToMarc(view, path);

                //TODO: Change for the logged user on POST:->Create



                await this.marcaRepository.CreateAsync(marc);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Marca ToMarc(MarcViewModel view, string path)
        {
            return new Marca
            {
                Id = view.Id,
                ImageUrl = path,
                Name = view.Name
            };
        }

        // GET: Marcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await this.marcaRepository.GetByIdAsync(id.Value);
            if (marca == null)
            {
                return NotFound();
            }
            var view = this.ToMarcViewModel(marca);
            return View(view);
        }

        private MarcViewModel ToMarcViewModel(Marca marca)
        {
            return new MarcViewModel
            {
                Id = marca.Id,
                Name = marca.Name,
                ImageUrl = marca.ImageUrl
            };
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageFile,ImageUrl")] MarcViewModel view)
        {

            if (ModelState.IsValid)
            {
                //Guardar a imagem
                var path = string.Empty;
                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Brands",
                        view.ImageFile.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Brands/{view.ImageFile.FileName}";
                }
                else
                {
                    path = view.ImageUrl;
                }
                var marc = this.ToMarc(view, path);

                //TODO: Change for the logged user on POST:->Create



                await this.marcaRepository.UpdateAsync(marc);
                return RedirectToAction(nameof(Edit));
            }
            return View(view);
        }

        // GET: Marcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await this.marcaRepository.GetByIdAsync(id.Value);

            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marca = await this.marcaRepository.GetByIdAsync(id);
            await this.marcaRepository.DeleteAsync(marca);
            return RedirectToAction(nameof(Index));
        }

    }
}

