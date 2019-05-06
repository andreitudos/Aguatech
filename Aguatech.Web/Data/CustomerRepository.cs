using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aguatech.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aguatech.Web.Data
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly DataContext context;
        public CustomerRepository( DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
