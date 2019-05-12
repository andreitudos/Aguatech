namespace Aguatech.Web.Models
{
    using System.Collections.Generic;
    using Aguatech.Web.Data.Entities;

    public class OrderViewModel
    {
        public Customer Customer { get; set; }

        public ProductOrder Product { get; set; }

        public List<ProductOrder> Products { get; set; }
    }
}
