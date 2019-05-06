using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aguatech.Web.Data.Entities
{
    public class OrderDetail : IEntity
    {
    
        public int Id { get; set; }

        public int OrderID { get; set; }
        public int ProductID { get; set; }

        [StringLength(30, ErrorMessage = "A {0} deverá ter entre {2} e {1} carateres", MinimumLength = 3)]
        [Required(ErrorMessage = "Deve inserir uma {0}")]
        [Display(Name = "Descrição do Produto")]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Insira um  {0}")]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Insira um  {0}")]
        [Display(Name = "Quantidade")]
        public float Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        [NotMapped]
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
