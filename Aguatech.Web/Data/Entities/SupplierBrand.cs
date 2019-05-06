namespace Aguatech.Web.Data.Entities
{
    public class SupplierBrand
    {
        public int SupplierBrandtId { get; set; }
        public int SupplierID { get; set; }
        public int BrandId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
