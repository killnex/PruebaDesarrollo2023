using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using apiServicioEstudiantes.Models;

namespace apiServicioEstudiantes.Controllers
{
    public class ListadoEstudiantesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ListadoEstudiantes
        public IQueryable<ListadoEstudiantes> GetListadoEstudiantes()
        {
            return db.ListadoEstudiantes;
        }

        // GET: api/ListadoEstudiantes/5
        [ResponseType(typeof(ListadoEstudiantes))]
        public IHttpActionResult GetListadoEstudiantes(int id)
        {
            ListadoEstudiantes listadoEstudiantes = db.ListadoEstudiantes.Find(id);
            if (listadoEstudiantes == null)
            {
                return NotFound();
            }

            return Ok(listadoEstudiantes);
        }

        // PUT: api/ListadoEstudiantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListadoEstudiantes(int id, ListadoEstudiantes listadoEstudiantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listadoEstudiantes.Id)
            {
                return BadRequest();
            }

            db.Entry(listadoEstudiantes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListadoEstudiantesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ListadoEstudiantes
        [ResponseType(typeof(ListadoEstudiantes))]
        public IHttpActionResult PostListadoEstudiantes(ListadoEstudiantes listadoEstudiantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListadoEstudiantes.Add(listadoEstudiantes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = listadoEstudiantes.Id }, listadoEstudiantes);
        }

        // DELETE: api/ListadoEstudiantes/5
        [ResponseType(typeof(ListadoEstudiantes))]
        public IHttpActionResult DeleteListadoEstudiantes(int id)
        {
            ListadoEstudiantes listadoEstudiantes = db.ListadoEstudiantes.Find(id);
            if (listadoEstudiantes == null)
            {
                return NotFound();
            }

            db.ListadoEstudiantes.Remove(listadoEstudiantes);
            db.SaveChanges();

            return Ok(listadoEstudiantes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListadoEstudiantesExists(int id)
        {
            return db.ListadoEstudiantes.Count(e => e.Id == id) > 0;
        }
    }
}