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
using WAGreenLeaf;

namespace WAGreenLeaf.Controllers
{
    public class MonitorsController : ApiController
    {
        private GreenLeafContext db = new GreenLeafContext();

        // GET: api/Monitors
        public IQueryable<Monitor> GetMonitor()
        {
            return db.Monitor;
        }

        // GET: api/Monitors/5
        [ResponseType(typeof(Monitor))]
        public IHttpActionResult GetMonitor(int id)
        {
            Monitor monitor = db.Monitor.Find(id);
            if (monitor == null)
            {
                return NotFound();
            }

            return Ok(monitor);
        }

        // PUT: api/Monitors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMonitor(int id, Monitor monitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monitor.MonitorID)
            {
                return BadRequest();
            }

            db.Entry(monitor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitorExists(id))
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

        // POST: api/Monitors
        [ResponseType(typeof(Monitor))]
        public IHttpActionResult PostMonitor(Monitor monitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Monitor.Add(monitor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = monitor.MonitorID }, monitor);
        }

        // DELETE: api/Monitors/5
        [ResponseType(typeof(Monitor))]
        public IHttpActionResult DeleteMonitor(int id)
        {
            Monitor monitor = db.Monitor.Find(id);
            if (monitor == null)
            {
                return NotFound();
            }

            db.Monitor.Remove(monitor);
            db.SaveChanges();

            return Ok(monitor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MonitorExists(int id)
        {
            return db.Monitor.Count(e => e.MonitorID == id) > 0;
        }
    }
}