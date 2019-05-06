namespace Aguatech.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Aguatech.Web.Data.Entities;
    using Microsoft.AspNetCore.Http;

    public class SuppplierViewModel : Supplier
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
