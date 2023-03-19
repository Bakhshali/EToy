using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
    public interface IPersistence
    {
        Task<int> SaveChangesAsync();
        int SaveChange();
    }
}
