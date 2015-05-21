using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Infrastructure;

namespace Ccom.Pharmacy.DAL.Repositories.InvoiceItem
{
    public class InvoiceItemRepository : RepositoryBase<InvoiceItemEntity>, IInvoiceItemRepository
    {
        public InvoiceItemRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
