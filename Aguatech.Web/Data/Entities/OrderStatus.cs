using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aguatech.Web.Data.Entities
{
    public class OrderStatus : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Description")]
        public string Name { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
