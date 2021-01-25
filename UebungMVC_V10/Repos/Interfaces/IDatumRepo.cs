using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UebungMVC_V10.Models.DBModels;
using UebungMVC_V10.Models.VModels;

namespace UebungMVC_V10.Repos.Interfaces
{
    public interface IDatumRepo
    {
        Task<Datum> GetDatumByID(int? id);
        Task<List<Datum>> GetAllDatum();
        void Add(Datum datum);
        void Update(Datum datum);
        Task Remove(int? id);
    }
}
