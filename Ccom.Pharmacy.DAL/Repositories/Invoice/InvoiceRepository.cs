using Ccom.Pharmacy.DAL.Entity;
using Ccom.Pharmacy.DAL.Infrastructure;

namespace Ccom.Pharmacy.DAL.Repositories.Invoice
{
    public class InvoiceRepository : RepositoryBase<InvoiceEntity>, IInvoiceRepository
    {
        public InvoiceRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
