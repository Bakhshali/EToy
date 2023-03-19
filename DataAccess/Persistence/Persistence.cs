using DataAccess.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
    public class Persistence : IPersistence
    {
        private readonly AppDbContext _context;

        public Persistence(AppDbContext context)
        {
            _context = context;
        }
        public int SaveChange()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
