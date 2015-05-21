using System;

namespace Ccom.Pharmacy.DAL.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        DataBaseContext Get();
    }
}
 