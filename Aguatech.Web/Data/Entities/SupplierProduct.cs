namespace Aguatech.Web.Data.Entities
{
    public class SupplierProduct
    {
        public int SupplierProductID { get; set; }
        public int SupplierID { get; set; }
        public int ProductID { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Product Product { get; set; }
    }
}
