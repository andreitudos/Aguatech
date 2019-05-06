namespace Aguatech.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DocumentType : IEntity
    {
        
        [Display(Name = "Tipo Documento")]
        public int Id { get; set; }

        [Display(Name = "Documento")]
        public string Name { get; set; }

     //   public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

    }
}
