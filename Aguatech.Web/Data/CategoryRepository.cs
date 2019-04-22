using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aguatech.Web.Data.Entities;

namespace Aguatech.Web.Data
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {

        }
    }
}
