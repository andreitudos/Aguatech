namespace Aguatech.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CustomerType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public decimal DiscountRate { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

    }
}
