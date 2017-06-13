using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalculadoraIntereses.Models;

namespace CalculadoraIntereses.Controllers
{
    public class PrestarsController : Controller
    {
        private ClienteDb db = new ClienteDb();

        // GET: Prestars
        public async Task<ActionResult> Index(int? buscar = null)
        {
            IEnumerable<Prestar> prestar;

            if (buscar == null)
            {
                prestar = await db.prestar.ToListAsync();
            }
            else
            {
                prestar = await db.prestar.Where(z => z.IdCliente == buscar ).ToListAsync();
            }

            return View(prestar);
        }

        // GET: Prestars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestar prestar = await db.prestar.FindAsync(id);
            if (prestar == null)
            {
                return HttpNotFound();
            }
            return View(prestar);
        }

        // GET: Prestars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prestars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PrestamoID,Plazo,Interes,CantidadPrestada,Cuota,IniciodePrestamo,IdCliente")] Prestar prestar)
        {
            if (ModelState.IsValid)
            {
                double cantidadPagar = 0d;
                double interes = 0d;
                double cuota = 0d;

                cantidadPagar = prestar.CantidadPrestada / (prestar.Plazo * 12);
                interes = (prestar.CantidadPrestada * prestar.Interes / 100) / 12;
                cuota = cantidadPagar + interes;

                prestar.Cuota = cuota;


                db.prestar.Add(prestar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(prestar);
        }

        // GET: Prestars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestar prestar = await db.prestar.FindAsync(id);
            if (prestar == null)
            {
                return HttpNotFound();
            }
            return View(prestar);
        }

        // POST: Prestars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PrestamoID,Plazo,Interes,CantidadPrestada,Cuota,IniciodePrestamo,IdCliente")] Prestar prestar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(prestar);
        }

        // GET: Prestars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestar prestar = await db.prestar.FindAsync(id);
            if (prestar == null)
            {
                return HttpNotFound();
            }
            return View(prestar);
        }

        // POST: Prestars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Prestar prestar = await db.prestar.FindAsync(id);
            db.prestar.Remove(prestar);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
