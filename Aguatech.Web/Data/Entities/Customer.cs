namespace Aguatech.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Customer : IEntity
    {
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} carateres", MinimumLength = 3)]
        [Required(ErrorMessage = "Tem que inserir um {0}")]
        [Display(Name = "Primeiro Nome")]
        public string Name { get; set; }

        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} carateres", MinimumLength = 3)]
        [Required(ErrorMessage = "Tem que inserir um {0}")]
        [Display(Name = "Apelido")]
        public string LastName { get; set; }

        [Display(Name = "Nome")]
        [NotMapped]
        public string FullName
        {
            get { return $"{Name} {LastName}"; }
        }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Tem que inserir um {0}")]
        [StringLength(30, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} carateres", MinimumLength = 9)]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Tem que inserir a {0}")]
        [StringLength(100, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} carateres", MinimumLength = 3)]
        [Display(Name = "Morada")]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tem que inserir um {0}")]
        [StringLength(20, ErrorMessage = "O campo {0} deverá conter entre {2} e {1} digitos", MinimumLength = 3)]
        [Display(Name = "Nº Documento")]
        public string Document { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "O {0} e óbrigatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "Tem que selecionar um {0}")]
        [Display(Name = "Tipo de documento")]
        public int DocumentTypeId { get; set; }


        public virtual DocumentType DocumentType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public int? CustomerTypeId { get; set; }

        public virtual CustomerType Type { get; set; }

    }
}
