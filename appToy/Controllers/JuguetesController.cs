using appToy.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace appToy.Controllers
{
    public class JuguetesController : ApiController
    {
        private JugetesdbContext db = new JugetesdbContext();

        public IQueryable<Juguete> GetJuguete()
        {
            return db.Juguete;
        }
        [ResponseType(typeof(Juguete))]
        public IHttpActionResult GetJuguete(int id)
        {
            Juguete juguete = db.Juguete.Find(id);
            if (juguete == null)
            {
                return NotFound();
            }

            return Ok(juguete);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutJuguete(int id, Juguete juguete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != juguete.Id)
            {
                return BadRequest();
            }

            db.Entry(juguete).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JugueteExists(id))
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

        [ResponseType(typeof(Juguete))]
        public IHttpActionResult PostJuguete(Juguete juguete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Juguete.Add(juguete);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = juguete.Id }, juguete);
        }

        [ResponseType(typeof(Juguete))]
        public IHttpActionResult DeleteJuguete(int id)
        {
            Juguete juguete = db.Juguete.Find(id);
            if (juguete == null)
            {
                return NotFound();
            }

            db.Juguete.Remove(juguete);
            db.SaveChanges();

            return Ok(juguete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JugueteExists(int id)
        {
            return db.Juguete.Count(e => e.Id == id) > 0;
        }
    }
}