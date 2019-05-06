namespace Aguatech.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class BrandViewModel
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
