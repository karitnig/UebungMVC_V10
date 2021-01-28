using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UebungMVC_V10.Models;
using UebungMVC_V10.Models.DBModels;
using UebungMVC_V10.Models.VModels;

namespace UebungMVC_V10.Controllers
{
    public class DataController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        private readonly UnitOfWork uow;

        public DataController()
        {
            uow = new UnitOfWork();
        }
        // GET: Data
        public async Task<ActionResult> Index()
        {
            List<Datum> datums = new List<Datum>();
            datums = await uow.DatumRepo.GetAllDatum();
            List<DataVM> dataVMs = new List<DataVM>();

            foreach (Datum datum in datums)
            {
                DataVM dataVM = new DataVM(datum);
                dataVMs.Add(dataVM);
            }
            return View(dataVMs);
        }

        // GET: Data/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Datum datum = await uow.DatumRepo.GetDatumByID(id);
            DataVM dataVM = new DataVM(datum);

            if (dataVM == null)
            {
                return HttpNotFound();
            }
            return View(dataVM);
        }

        // GET: Data/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DatumID,AnfangDateTime,EndeDateTime,AbstandDateTimeText")] DataVM datum)
        {
            //TODO:ViewModel einbinden
            if (ModelState.IsValid)
            {
                Datum datum1 = new Datum(datum);
                uow.DatumRepo.Add(datum1);
                await uow.CommitAsync();
                return RedirectToAction("Index");
            }

            return View(datum);
        }

        // GET: Data/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TODO:ViewModel einbinden

            Datum datum = await db.Datums.FindAsync(id);
            DataVM dataVM = new DataVM(datum);

            if (dataVM == null)
            {
                return HttpNotFound();
            }
            return View(dataVM);
        }

        // POST: Data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DatumID,AnfangDateTime,EndeDateTime,AbstandDateTimeText")] DataVM vmData)
        {
            if (ModelState.IsValid)
            {
                //TIPP3000: Konstruktor mit VM befüllen
                Datum datumModel = new Datum(vmData);

                uow.DatumRepo.Update(datumModel);

                await uow.CommitAsync();

                return RedirectToAction("Index");
            }
            return View(vmData);
        }

        // GET: Data/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TODO:ViewModel einbinden
            Datum datum = await uow.DatumRepo.GetDatumByID(id);
            DataVM data = new DataVM(datum);

            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            //TODO: funktioniert nicht richtig

            //ExeptionFehler: Das Objekt kann nicht gelöscht werden, 
            //da es nicht im ObjectStateManager gefunden wurde. 

            await uow.DatumRepo.Remove(id);
            await uow.CommitAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
