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
    builder.EntitySet<EDI_IMPORTA_ITEM>("EDI_IMPORTA_ITEM");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class EDI_IMPORTA_ITEMController : ODataController
    {
        private ControleContext db = new ControleContext();

        // GET: odata/EDI_IMPORTA_ITEM
        [EnableQuery]
        public IQueryable<EDI_IMPORTA_ITEM> GetEDI_IMPORTA_ITEM()
        {
            return db.EDI_IMPORTA_ITEM;
        }

        // GET: odata/EDI_IMPORTA_ITEM(5)
        [EnableQuery]
        public SingleResult<EDI_IMPORTA_ITEM> GetEDI_IMPORTA_ITEM([FromODataUri] int key)
        {
            return SingleResult.Create(db.EDI_IMPORTA_ITEM.Where(eDI_IMPORTA_ITEM => eDI_IMPORTA_ITEM.ID_IMPORTAITEM == key));
        }

        // PUT: odata/EDI_IMPORTA_ITEM(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<EDI_IMPORTA_ITEM> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EDI_IMPORTA_ITEM eDI_IMPORTA_ITEM = db.EDI_IMPORTA_ITEM.Find(key);
            if (eDI_IMPORTA_ITEM == null)
            {
                return NotFound();
            }

            patch.Put(eDI_IMPORTA_ITEM);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EDI_IMPORTA_ITEMExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(eDI_IMPORTA_ITEM);
        }

        // POST: odata/EDI_IMPORTA_ITEM
        public IHttpActionResult Post(EDI_IMPORTA_ITEM eDI_IMPORTA_ITEM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EDI_IMPORTA_ITEM.Add(eDI_IMPORTA_ITEM);
            db.SaveChanges();

            return Created(eDI_IMPORTA_ITEM);
        }

        // PATCH: odata/EDI_IMPORTA_ITEM(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<EDI_IMPORTA_ITEM> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EDI_IMPORTA_ITEM eDI_IMPORTA_ITEM = db.EDI_IMPORTA_ITEM.Find(key);
            if (eDI_IMPORTA_ITEM == null)
            {
                return NotFound();
            }

            patch.Patch(eDI_IMPORTA_ITEM);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EDI_IMPORTA_ITEMExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(eDI_IMPORTA_ITEM);
        }

        // DELETE: odata/EDI_IMPORTA_ITEM(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            EDI_IMPORTA_ITEM eDI_IMPORTA_ITEM = db.EDI_IMPORTA_ITEM.Find(key);
            if (eDI_IMPORTA_ITEM == null)
            {
                return NotFound();
            }

            db.EDI_IMPORTA_ITEM.Remove(eDI_IMPORTA_ITEM);
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

        public bool EDI_IMPORTA_ITEMExists(int key)
        {
            return db.EDI_IMPORTA_ITEM.Count(x => x.NRLISTA == key) > 0;
        }
    }
}
