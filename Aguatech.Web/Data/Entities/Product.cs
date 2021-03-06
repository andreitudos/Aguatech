﻿namespace Aguatech.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product : IEntity
    {
        public int Id { get; set; }
      
        [Display(Name = "Barcode")]
        public string Barcode { get; set; }

        [MaxLength(50,ErrorMessage ="The field {0} only can contain {1} charcaters length!")]
        [Required]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode =false)]
        public decimal Price { get; set; }

        [Display(Name="Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Last Purchase")]
        public DateTime? LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }
        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }

        public User User { get; set; }

        public int? CategoryId { get; set; }
 
        public virtual Category Category { get; set; }

      
    }
}
