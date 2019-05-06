namespace Aguatech.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Supplier : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Tem que introduzir um {0} para o Fornecedor")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Tem que introduzir um {0}")]
        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} carateres", MinimumLength = 9)]
        [Display(Name = "VAT")]
        public string VAT { get; set; }

        [Display(Name = "Nome do Contacto")]
        [Required(ErrorMessage = "Tem que introduzir um {0} para o Fornecedor")]
        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} carateres", MinimumLength = 3)]
        public string ContactFirstName { get; set; }

        [Display(Name = "Apelido do Contacto")]
        [Required(ErrorMessage = "Tem que introduzir um {0} para o Fornecedor")]
        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} carateres", MinimumLength = 3)]
        public string ContactLastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Tem que introduzir um {0}")]
        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} carateres", MinimumLength = 9)]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Tem que introduzir um {0}")]
        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} carateres", MinimumLength = 9)]
        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Tem que introduzir uma {0}")]
        [StringLength(100, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} carateres", MinimumLength = 3)]
        [Display(Name = "Morada")]
        public string Address { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }
       
    }
}
