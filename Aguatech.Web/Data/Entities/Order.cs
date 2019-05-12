using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aguatech.Web.Data.Entities
{
    public class Order:IEntity
    {
        public int Id { get; set; }

        public DateTime DataOrder { get; set; }

        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public int? OrderStatusId { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        [NotMapped]
        public string Name { get; set; }
    }
}
