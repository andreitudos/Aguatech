namespace Aguatech.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Aguatech.Web.Data.Entities;
    using Microsoft.AspNetCore.Http;

    public class ProductViewModel : Product
    {
        [Display(Name ="Image")]
        public IFormFile ImageFile { get; set; }

    }
}
