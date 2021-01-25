using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UebungMVC_V10.Models;
using UebungMVC_V10.Models.DBModels;
using UebungMVC_V10.Models.VModels;
using UebungMVC_V10.Repos.Interfaces;

namespace UebungMVC_V10.Repos
{
    public class DatumRepo : IDatumRepo
    {
        ApplicationDbContext db;

        public DatumRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Datum datum)
        {
            db.Datums.Add(datum);
        } 

        public async Task<List<Datum>> GetAllDatum()
        {
            return await db.Datums.ToListAsync();
        }

        public Task<Datum> GetDatumByID(int? id)
        {
            return db.Datums.FindAsync(id);
        }

        public async Task Remove(int? id)
        {
            Datum datum1 = await db.Datums.FindAsync(id);
            db.Datums.Remove(datum1);
        } 
        
        public void Update(Datum datum)
        {
            db.Datums.Attach(datum);
            db.Entry(datum).State = System.Data.Entity.EntityState.Modified;
        }
    }
}