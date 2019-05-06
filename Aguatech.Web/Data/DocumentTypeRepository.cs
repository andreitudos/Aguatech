using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aguatech.Web.Data.Entities;

namespace Aguatech.Web.Data
{
    public class DocumentTypeRepository : GenericRepository<DocumentType>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(DataContext context) : base(context)
        {
        }
    }
}
