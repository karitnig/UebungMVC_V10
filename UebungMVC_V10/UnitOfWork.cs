using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UebungMVC_V10.Models;
using UebungMVC_V10.Repos;

namespace UebungMVC_V10
{
    public class UnitOfWork : IDisposable
    {
        ApplicationDbContext db;

        public UnitOfWork()
        {
            db = new ApplicationDbContext();
        }

        private DatumRepo _datumRepo;

        public DatumRepo DatumRepo
        {
            get
            {
                if (_datumRepo == null) _datumRepo = new DatumRepo(db);
                return _datumRepo;
            }
        }

        public async Task CommitAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}