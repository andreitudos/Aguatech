namespace Aguatech.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Marca : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
    }
}
