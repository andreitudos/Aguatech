using System.ComponentModel.DataAnnotations;

namespace Aguatech.Web.Data.Entities
{
    public class Marca : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
    }
}
