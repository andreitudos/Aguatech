using System.ComponentModel.DataAnnotations;
using Aguatech.Web.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Aguatech.Web.Models
{
    public class CustomerViewModel : Customer
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
