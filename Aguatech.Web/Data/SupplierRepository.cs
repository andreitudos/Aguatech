using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aguatech.Web.Data.Entities;

namespace Aguatech.Web.Data
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        private readonly DataContext context;
        public SupplierRepository(DataContext context) : base(context)
        {
        }
    }
}
