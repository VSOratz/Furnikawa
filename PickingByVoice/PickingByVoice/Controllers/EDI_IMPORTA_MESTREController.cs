using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using PickingByVoice.Models;

namespace PickingByVoice.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using PickingByVoice.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<EDI_IMPORTA_MESTRE>("EDI_IMPORTA_MESTRE");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EDI_IMPORTA_MESTREController : ODataController
    {
        private ControleContext db = new ControleContext();

        // GET: odata/EDI_IMPORTA_MESTRE
        [EnableQuery]
        public IQueryable<EDI_IMPORTA_MESTRE> GetEDI_IMPORTA_MESTRE()
        {
            return db.EDI_IMPORTA_MESTRE;
        }

        // GET: odata/EDI_IMPORTA_MESTRE(5)
        [EnableQuery]
        public SingleResult<EDI_IMPORTA_MESTRE> GetEDI_IMPORTA_MESTRE([FromODataUri] int key)
        {
            return SingleResult.Create(db.EDI_IMPORTA_MESTRE.Where(eDI_IMPORTA_MESTRE => eDI_IMPORTA_MESTRE.ID_IMPORTAMESTRE == key));
        }

        // PUT: odata/EDI_IMPORTA_MESTRE(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<EDI_IMPORTA_MESTRE> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EDI_IMPORTA_MESTRE eDI_IMPORTA_MESTRE = db.EDI_IMPORTA_MESTRE.Find(key);
            if (eDI_IMPORTA_MESTRE == null)
            {
                return NotFound();
            }

            patch.Put(eDI_IMPORTA_MESTRE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EDI_IMPORTA_MESTREExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(eDI_IMPORTA_MESTRE);
        }

        // POST: odata/EDI_IMPORTA_MESTRE
        public IHttpActionResult Post(EDI_IMPORTA_MESTRE eDI_IMPORTA_MESTRE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EDI_IMPORTA_MESTRE.Add(eDI_IMPORTA_MESTRE);
            db.SaveChanges();

            return Created(eDI_IMPORTA_MESTRE);
        }

        // PATCH: odata/EDI_IMPORTA_MESTRE(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<EDI_IMPORTA_MESTRE> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EDI_IMPORTA_MESTRE eDI_IMPORTA_MESTRE = db.EDI_IMPORTA_MESTRE.Find(key);
            if (eDI_IMPORTA_MESTRE == null)
            {
                return NotFound();
            }

            patch.Patch(eDI_IMPORTA_MESTRE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EDI_IMPORTA_MESTREExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(eDI_IMPORTA_MESTRE);
        }

        // DELETE: odata/EDI_IMPORTA_MESTRE(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            EDI_IMPORTA_MESTRE eDI_IMPORTA_MESTRE = db.EDI_IMPORTA_MESTRE.Find(key);
            if (eDI_IMPORTA_MESTRE == null)
            {
                return NotFound();
            }

            db.EDI_IMPORTA_MESTRE.Remove(eDI_IMPORTA_MESTRE);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool EDI_IMPORTA_MESTREExists(int key)
        {
            return db.EDI_IMPORTA_MESTRE.Count(e => e.ID_IMPORTAMESTRE == key) > 0;
        }
    }
}
