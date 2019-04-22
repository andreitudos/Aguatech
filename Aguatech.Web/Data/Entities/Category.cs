namespace Aguatech.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Deve inserir uma {0}")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(100, ErrorMessage = "A {0} deverá ter entre {2} e {1} carateres", MinimumLength = 3)]
        [Required(ErrorMessage = "Deve inserir uma {0}")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
    }
}
