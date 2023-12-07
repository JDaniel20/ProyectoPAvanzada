using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PrograAvanzadaP.Models;

namespace PrograAvanzadaP.Controllers
{
    public class RecetasController : Controller
    {
        private PrograAvanzadaEntities db = new PrograAvanzadaEntities();

        // GET: Recetas
        public ActionResult Index()
        {
			var recetas = db.Recetas.Include(r => r.Categoria).Include(r => r.Imagenes_x_Recetas); 

			var userId = ObtenerIdUsuarioActual();
			var esEstudiante = User.IsInRole("Estudiante");

			if (esEstudiante)
			{
				recetas = recetas.Where(r => r.IdUsuario == userId);
			}

			return View(recetas.ToList());
        }

        // GET: Recetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

		//Obtener el ID del usuario actual

		public string ObtenerIdUsuarioActual()
		{ 
            var userId = User.Identity.GetUserId();
			return userId;
		}

		// GET: Recetas/Create
		public ActionResult Create()
        {

			Receta NuevaReceta = new Receta
			{
				IdUsuario = ObtenerIdUsuarioActual(),
                FechaCreacion = DateTime.Now,
                IdUsuarioModificacion = ObtenerIdUsuarioActual(),
                fechaModificacion = DateTime.Now

			};


			ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "NombreCategoria");
            return View(NuevaReceta);
        }

        // POST: Recetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReceta,NombreReceta,IdCategoria,Duracion,Porciones,Ingredientes,Instrucciones,Estado,IdUsuario,FechaCreacion,IdUsuarioModificacion,fechaModificacion")] Receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Recetas.Add(receta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "NombreCategoria", receta.IdCategoria);
            return View(receta);
        }

        // GET: Recetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "NombreCategoria", receta.IdCategoria);
            return View(receta);
        }

        // POST: Recetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReceta,NombreReceta,IdCategoria,Duracion,Porciones,Ingredientes,Instrucciones,Estado,IdUsuario,FechaCreacion,IdUsuarioModificacion,fechaModificacion")] Receta receta)
        {
            if (ModelState.IsValid)
            {
				receta.IdUsuarioModificacion = ObtenerIdUsuarioActual();
				receta.fechaModificacion = DateTime.Now;

				db.Entry(receta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.Categorias, "IdCategoria", "NombreCategoria", receta.IdCategoria);
            return View(receta);
        }

        // GET: Recetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        // POST: Recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receta receta = db.Recetas.Find(id);
            db.Recetas.Remove(receta);
            db.SaveChanges();
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
